using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Raiqub.Generators.EnumUtilities;

public partial class EnumUtilitiesGenerator
{
    private const string EnumGeneratorAttributeName = "Raiqub.Generators.EnumUtilities.EnumGeneratorAttribute";

    private static bool IsSyntaxTargetForGeneration(SyntaxNode node, CancellationToken cancellationToken)
    {
        return node is EnumDeclarationSyntax { AttributeLists.Count: > 0 };
    }

    private static EnumDeclarationSyntax? GetSemanticTargetForGeneration(
        GeneratorSyntaxContext context,
        CancellationToken cancellationToken)
    {
        var semanticModel = context.SemanticModel;
        var syntax = (EnumDeclarationSyntax)context.Node;

        if (HasEnumGeneratorAttribute(semanticModel, syntax, cancellationToken) is false)
        {
            return null;
        }

        return syntax;
    }

    private static bool HasEnumGeneratorAttribute(
        SemanticModel semanticModel,
        MemberDeclarationSyntax syntax,
        CancellationToken cancellationToken)
    {
        foreach (var attributeList in syntax.AttributeLists)
        {
            foreach (var attribute in attributeList.Attributes)
            {
                if (semanticModel.GetSymbolInfo(attribute, cancellationToken).Symbol is not IMethodSymbol ctorSymbol)
                {
                    continue;
                }

                var attributeSymbol = ctorSymbol.ContainingType;
                string attributeName = attributeSymbol.ToDisplayString();

                if (attributeName == EnumGeneratorAttributeName)
                {
                    return true;
                }
            }
        }

        return false;
    }
}