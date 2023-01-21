using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Raiqub.Generators.EnumUtilities.Common;

public static class CodeAnalysisExtensions
{
    public static IncrementalValuesProvider<TSource> WhereNotNull<TSource>(
        this IncrementalValuesProvider<TSource?> source)
    {
        return source.Where(static it => it is not null)!;
    }

    public static string GetNamespace(this BaseTypeDeclarationSyntax syntax)
    {
        var nameSpace = string.Empty;
        var potentialNamespaceParent = syntax.Parent;

        while (potentialNamespaceParent != null &&
               potentialNamespaceParent is not NamespaceDeclarationSyntax &&
               potentialNamespaceParent is not FileScopedNamespaceDeclarationSyntax)
        {
            potentialNamespaceParent = potentialNamespaceParent.Parent;
        }

        if (potentialNamespaceParent is BaseNamespaceDeclarationSyntax namespaceParent)
        {
            nameSpace = namespaceParent.Name.ToString();

            // Keep moving "out" of the namespace declarations until we 
            // run out of nested namespace declarations
            while (true)
            {
                if (namespaceParent.Parent is not NamespaceDeclarationSyntax parent)
                {
                    break;
                }

                nameSpace = $"{namespaceParent.Name}.{nameSpace}";
                namespaceParent = parent;
            }
        }

        return nameSpace;
    }

    public static AttributeData? WhereClassNameIs(this AttributeData attribute, string name)
    {
        return attribute.AttributeClass?.Name == name
            ? attribute
            : null;
    }

    public static object? GetConstructorArgument(this AttributeData attribute, int position)
    {
        return attribute.ConstructorArguments[position].Value;
    }

    public static object? GetNamedArgument(this AttributeData attribute, string argName)
    {
        foreach (var namedArgument in attribute.NamedArguments)
        {
            if (namedArgument.Key == argName)
                return namedArgument.Value.Value;
        }

        return null;
    }
}