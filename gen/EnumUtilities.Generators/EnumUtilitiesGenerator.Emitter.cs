using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Raiqub.Generators.EnumUtilities.CodeWriters;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities;

public partial class EnumUtilitiesGenerator
{
    private static readonly CodeWriterDispatcher<EnumToGenerate> s_dispatcher =
        new(
            sb => new EnumInfoWriter(sb),
            sb => new EnumExtensionsWriter(sb),
            sb => new EnumFactoryWriter(sb),
            sb => new EnumValidationWriter(sb),
            sb => new EnumJsonConverterWriter(sb));

    private static void Emit(
        SourceProductionContext context,
        (ImmutableArray<EnumDeclarationSyntax> Types, Compilation Compilation) data)
    {
        Emit(data.Compilation, context, data.Types);
    }

    private static void Emit(
        Compilation compilation,
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
                        return compilation
                            .GetSemanticModel(t.SyntaxTree)
                            .GetDeclaredSymbol(t, context.CancellationToken)
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
}
