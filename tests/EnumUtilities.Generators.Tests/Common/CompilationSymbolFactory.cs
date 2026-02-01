using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Common;

public static class CompilationSymbolFactory
{
    public static INamedTypeSymbol GetEnumSymbol(string enumSourceCode)
    {
        var compilation = CSharpCompilation.Create(
            "TestAssembly",
            syntaxTrees: [CSharpSyntaxTree.ParseText(enumSourceCode)],
            references: AppDomain
                .CurrentDomain.GetAssemblies()
                .Append(typeof(EnumGeneratorAttribute).Assembly)
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                .Select(a => MetadataReference.CreateFromFile(a.Location))
        );

        var syntaxTree = compilation.SyntaxTrees.First();
        var semanticModel = compilation.GetSemanticModel(syntaxTree);

        var enumDeclaration = syntaxTree
            .GetRoot()
            .DescendantNodes()
            .OfType<Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax>()
            .First();

        return semanticModel.GetDeclaredSymbol(enumDeclaration)
            ?? throw new InvalidOperationException("Enum symbol not found");
    }
}
