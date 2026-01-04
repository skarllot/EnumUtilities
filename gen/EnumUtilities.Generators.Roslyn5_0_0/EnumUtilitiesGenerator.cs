using System.Collections.Immutable;
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
        sb => new EnumInfoWriter(sb),
        sb => new EnumExtensionsWriter(sb),
        sb => new EnumFactoryWriter(sb),
        sb => new EnumValidationWriter(sb),
        sb => new EnumJsonConverterWriter(sb)
    );

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var rootNamespace = context.AnalyzerConfigOptionsProvider.Select(
            (c, _) => c.GlobalOptions.TryGetValue("build_property.RootNamespace", out var ns) ? ns : null
        );

        var providerForEnumGenerator = context
            .SyntaxProvider.ForAttributeWithMetadataName(
                EnumGeneratorAttributeName,
                IsSyntaxTargetForGeneration,
                GetSemanticTargetForGeneration
            )
            .WithTrackingName(TrackingNames.ExtractForEnumGeneratorAttribute)
            .WhereNotNull()
            .WithTrackingName(TrackingNames.RemoveNulls)
            .Combine(rootNamespace)
            .Select((x, _) => x.Right != null ? x.Left with { RootNamespace = x.Right } : x.Left)
            .WithTrackingName(TrackingNames.FillRootNamespace)
            .Collect();

        var providerForJsonConverterGenerator = context
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
            .Combine(rootNamespace)
            .Select((x, _) => x.Right != null ? x.Left with { RootNamespace = x.Right } : x.Left)
            .WithTrackingName(TrackingNames.FillRootNamespace)
            .Collect();

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
