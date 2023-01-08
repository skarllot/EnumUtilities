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
    private static readonly StubbleVisitorRenderer Stubble = new StubbleBuilder().Build();

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

        foreach (var type in types)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var semanticModel = compilation.GetSemanticModel(type.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(type) is not INamedTypeSymbol typeSymbol)
            {
                continue;
            }

            var enumMembers = typeSymbol.GetMembers();
            var enumValues = new List<EnumValue>(enumMembers.Length);

            foreach (var member in enumMembers)
            {
                if (member is IFieldSymbol { ConstantValue: not null } field)
                {
                    enumValues.Add(new EnumValue(member.Name, field.ConstantValue));
                }
            }

            if (enumValues.Count == 0)
            {
                continue;
            }

            typesToGenerate.Add(
                new EnumToGenerate(
                    type.GetNamespace(),
                    typeSymbol.Name,
                    typeSymbol.EnumUnderlyingType?.Name ?? "int",
                    enumValues));
        }

        return typesToGenerate;
    }

    private static void AddExtensionsSource(EnumToGenerate type, SourceProductionContext context)
    {
        string filename = type.Name + "Extensions.g.cs";
        string fileContent = Stubble.Render(ResourceProvider.EnumExtensions, type);
        context.AddSource(filename, SourceText.From(fileContent, Encoding.UTF8));
    }

    private static void AddFactorySource(EnumToGenerate type, SourceProductionContext context)
    {
        string filename = type.Name + "Factory.g.cs";
        string fileContent = Stubble.Render(ResourceProvider.EnumFactory, type);
        context.AddSource(filename, SourceText.From(fileContent, Encoding.UTF8));
    }

    private static void AddValidationSource(EnumToGenerate type, SourceProductionContext context)
    {
        string filename = type.Name + "Validation.g.cs";
        string fileContent = Stubble.Render(ResourceProvider.EnumValidation, type);
        context.AddSource(filename, SourceText.From(fileContent, Encoding.UTF8));
    }
}