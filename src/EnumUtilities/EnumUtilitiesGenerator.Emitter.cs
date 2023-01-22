using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;
using Stubble.Core;
using Stubble.Core.Builders;

namespace Raiqub.Generators.EnumUtilities;

public partial class EnumUtilitiesGenerator
{
    private static readonly StubbleVisitorRenderer _stubble = new StubbleBuilder().Build();

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

        var typesToGenerate = GetTypesToGenerate(compilation, types, context.CancellationToken);

        foreach (var enumToGenerate in typesToGenerate)
        {
            AddExtensionsSource(enumToGenerate, context);
            AddFactorySource(enumToGenerate, context);
            AddValidationSource(enumToGenerate, context);
        }
    }

    private static List<EnumToGenerate> GetTypesToGenerate(
        Compilation compilation,
        ImmutableArray<EnumDeclarationSyntax> types,
        CancellationToken cancellationToken)
    {
        var typesToGenerate = new List<EnumToGenerate>();

        var enumGeneratorAttribute = compilation.GetTypeByMetadataName(EnumGeneratorAttributeName);
        if (enumGeneratorAttribute is null)
        {
            return typesToGenerate;
        }

        typesToGenerate.AddRange(
            types
                .Select(
                    t => compilation
                        .GetSemanticModel(t.SyntaxTree)
                        .GetDeclaredSymbol(t, cancellationToken)
                        .Map(EnumToGenerate.FromSymbol))
                .WhereNotNull());

        return typesToGenerate;
    }

    private static void AddExtensionsSource(EnumToGenerate type, SourceProductionContext context)
    {
        string filename = type.Namespace + "." + type.Name + "Extensions.g.cs";
        string fileContent = _stubble.Render(ResourceProvider.EnumExtensions, type);
        context.AddSource(filename, SourceText.From(fileContent, Encoding.UTF8));
    }

    private static void AddFactorySource(EnumToGenerate type, SourceProductionContext context)
    {
        string filename = type.Namespace + "." + type.Name + "Factory.g.cs";
        string fileContent = _stubble.Render(ResourceProvider.EnumFactory, type);
        context.AddSource(filename, SourceText.From(fileContent, Encoding.UTF8));
    }

    private static void AddValidationSource(EnumToGenerate type, SourceProductionContext context)
    {
        string filename = type.Namespace + "." + type.Name + "Validation.g.cs";
        string fileContent = _stubble.Render(ResourceProvider.EnumValidation, type);
        context.AddSource(filename, SourceText.From(fileContent, Encoding.UTF8));
    }
}