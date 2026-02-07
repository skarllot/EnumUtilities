using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Raiqub.Generators.EnumUtilities.CodeWriters;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.T4CodeWriter;

namespace Raiqub.Generators.EnumUtilities;

[Generator(LanguageNames.CSharp)]
public class EnumUtilitiesGenerator : IIncrementalGenerator
{
    private const string BaseAttributeNamespace = "Raiqub.Generators.EnumUtilities";
    private const string EnumGeneratorAttributeName = $"{BaseAttributeNamespace}.EnumGeneratorAttribute";
    private const string JsonConverterGeneratorAttribute = $"{BaseAttributeNamespace}.JsonConverterGeneratorAttribute";

    private static readonly CodeWriterDispatcher<EnumToGenerate> s_dispatcher = new(
        HandleCodeWriterException,
        sb => new EnumExtensionsWriter(sb),
        sb => new EnumFactoryWriter(sb),
        sb => new EnumValidationWriter(sb),
        sb => new EnumJsonConverterWriter(sb)
    );

    private static readonly EnumInfoWriter s_enumInfoWriter = new();

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var rootNamespace = context.AnalyzerConfigOptionsProvider.Select(
            (c, _) => c.GlobalOptions.TryGetValue("build_property.RootNamespace", out var ns) ? ns : null
        );

        var csharpVersion = context.CompilationProvider.Select((c, _) => ((CSharpCompilation)c).LanguageVersion);

        var enumsWithVersion = context
            .SyntaxProvider.ForAttributeWithMetadataName(
                EnumGeneratorAttributeName,
                IsSyntaxTargetForGeneration,
                GetSemanticTargetForGeneration
            )
            .WithTrackingName(TrackingNames.ExtractForEnumGeneratorAttribute)
            .WhereNotNull()
            .WithTrackingName(TrackingNames.RemoveNulls)
            .Combine(csharpVersion);

        var oldCsharpVersionEnums = enumsWithVersion.Where(t => t.Right < LanguageVersion.CSharp10).Collect();

        var providerForEnumGenerator = enumsWithVersion
            .Where(t => t.Right >= LanguageVersion.CSharp10)
            .Select((x, _) => x.Left)
            .WithTrackingName(TrackingNames.IgnoreOldCsharpVersion)
            .Combine(rootNamespace)
            .Select((x, _) => x.Right != null ? x.Left with { RootNamespace = x.Right } : x.Left)
            .WithTrackingName(TrackingNames.FillRootNamespace)
            .Collect();

        var jsonConverterEnumsWithVersion = context
            .SyntaxProvider.ForAttributeWithMetadataName(
                JsonConverterGeneratorAttribute,
                IsSyntaxTargetForGeneration,
                GetSemanticTargetForGeneration
            )
            .WithTrackingName(TrackingNames.ExtractForJsonConverterGeneratorAttribute)
            .WhereNotNull()
            .WithTrackingName(TrackingNames.RemoveNulls)
            .Where(x => (x.SelectedGenerators & SelectedGenerators.MainGenerator) == 0)
            .WithTrackingName(TrackingNames.SkipGeneratedByMainGenerator)
            .Combine(csharpVersion);

        var oldCsharpVersionJsonConverterEnums = jsonConverterEnumsWithVersion
            .Where(t => t.Right < LanguageVersion.CSharp10)
            .Collect();

        var providerForJsonConverterGenerator = jsonConverterEnumsWithVersion
            .Where(t => t.Right >= LanguageVersion.CSharp10)
            .Select((x, _) => x.Left)
            .WithTrackingName(TrackingNames.IgnoreOldCsharpVersion)
            .Combine(rootNamespace)
            .Select((x, _) => x.Right != null ? x.Left with { RootNamespace = x.Right } : x.Left)
            .WithTrackingName(TrackingNames.FillRootNamespace)
            .Collect();

        context.RegisterImplementationSourceOutput(oldCsharpVersionEnums, ReportCSharpVersionDiagnostic);
        context.RegisterImplementationSourceOutput(oldCsharpVersionJsonConverterEnums, ReportCSharpVersionDiagnostic);
        context.RegisterImplementationSourceOutput(providerForEnumGenerator, Emit);
        context.RegisterImplementationSourceOutput(providerForJsonConverterGenerator, Emit);
    }

    private static bool IsSyntaxTargetForGeneration(SyntaxNode node, CancellationToken cancellationToken)
    {
        return node is EnumDeclarationSyntax { AttributeLists.Count: > 0 } enumNode
            && !enumNode.Modifiers.Any(SyntaxKind.PrivateKeyword);
    }

    private static EnumToGenerate? GetSemanticTargetForGeneration(
        GeneratorAttributeSyntaxContext context,
        CancellationToken cancellationToken
    )
    {
        return EnumToGenerate.FromSymbol(context.TargetSymbol);
    }

    private static void Emit(SourceProductionContext context, ImmutableArray<EnumToGenerate> enumsToGenerate)
    {
        if (enumsToGenerate.IsDefaultOrEmpty)
        {
            return;
        }

        s_dispatcher.GenerateSources(enumsToGenerate, context);

        var sb = new StringBuilder(1024);
        foreach (var model in enumsToGenerate)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            try
            {
                s_enumInfoWriter.GenerateCompilationSource(context, sb, model);
            }
            catch (Exception e)
            {
                context.ReportDiagnostic(HandleCodeWriterException(e, model));
            }
        }
    }

    private static void ReportCSharpVersionDiagnostic(
        SourceProductionContext context,
        ImmutableArray<(EnumToGenerate Enum, LanguageVersion Version)> enumsWithVersion
    )
    {
        foreach (var (enumToGenerate, version) in enumsWithVersion)
        {
            var diagnostic = Diagnostic.Create(
                DiagnosticDescriptors.CSharpVersionNotSupported,
                enumToGenerate.DefaultLocations,
                version.ToDisplayString()
            );
            context.ReportDiagnostic(diagnostic);
        }
    }

    private static Diagnostic HandleCodeWriterException(Exception exception, EnumToGenerate model)
    {
        return Diagnostic.Create(
            DiagnosticDescriptors.UnexpectedErrorGenerating,
            model.DefaultLocations,
            exception.ToString().Replace("\n", " ")
        );
    }
}
