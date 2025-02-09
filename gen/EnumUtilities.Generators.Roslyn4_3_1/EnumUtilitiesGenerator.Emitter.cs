using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Raiqub.Generators.EnumUtilities.CodeWriters;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.T4CodeWriter;

namespace Raiqub.Generators.EnumUtilities;

public partial class EnumUtilitiesGenerator
{
    private static readonly CodeWriterDispatcher<EnumToGenerate> s_dispatcher =
        new(
            HandleCodeWriterException,
            sb => new EnumInfoWriter(sb),
            sb => new EnumExtensionsWriter(sb),
            sb => new EnumFactoryWriter(sb),
            sb => new EnumValidationWriter(sb),
            sb => new EnumJsonConverterWriter(sb));

    private static void Emit(
        SourceProductionContext context,
        (ImmutableArray<EnumDeclarationSyntax> Types, Compilation Compilation) data)
    {
        Emit((CSharpCompilation)data.Compilation, context, data.Types);
    }

    private static void Emit(
        CSharpCompilation compilation,
        SourceProductionContext context,
        ImmutableArray<EnumDeclarationSyntax> types)
    {
        if (types.IsDefaultOrEmpty)
        {
            return;
        }

        var typesToGenerate = GetTypesToGenerate(compilation, context, types);

        s_dispatcher.GenerateSources(typesToGenerate, context);
    }

    private static List<EnumToGenerate> GetTypesToGenerate(
        Compilation compilation,
        SourceProductionContext context,
        ImmutableArray<EnumDeclarationSyntax> types)
    {
        var enumGeneratorAttribute = compilation.GetTypeByMetadataName(EnumGeneratorAttributeName);
        if (enumGeneratorAttribute is null)
        {
            return new List<EnumToGenerate>();
        }

        return types
            .Select(
                t =>
                {
                    try
                    {
                        return ModelExtensions.GetDeclaredSymbol(
                                compilation.GetSemanticModel(t.SyntaxTree),
                                t,
                                context.CancellationToken)
                            .Map(EnumToGenerate.FromSymbol);
                    }
                    catch (Exception e)
                    {
                        context.ReportDiagnostic(
                            Diagnostic.Create(
                                DiagnosticDescriptors.UnexpectedErrorParsingCode,
                                t.GetLocation(),
                                e.ToString().Replace("\n", " ")));
                        return null;
                    }
                })
            .WhereNotNull()
            .ToList();
    }

    private static Diagnostic HandleCodeWriterException(Exception exception, EnumToGenerate model)
    {
        return Diagnostic.Create(
            DiagnosticDescriptors.UnexpectedErrorGenerating,
            model.DefaultLocations,
            exception.ToString().Replace("\n", " "));
    }
}
