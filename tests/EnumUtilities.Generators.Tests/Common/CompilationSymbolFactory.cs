using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Common;

public static class CompilationSymbolFactory
{
    public static async Task<INamedTypeSymbol> GetEnumSymbol(string enumSourceCode)
    {
        var compilation = CSharpCompilation.Create(
            "TestAssembly",
            syntaxTrees: [CSharpSyntaxTree.ParseText(enumSourceCode)],
            references: await ResolveReferenceAssemblies()
        );

        var syntaxTree = compilation.SyntaxTrees.First();
        var semanticModel = compilation.GetSemanticModel(syntaxTree);

        var enumDeclaration = (await syntaxTree.GetRootAsync())
            .DescendantNodes()
            .OfType<Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax>()
            .First();

        return semanticModel.GetDeclaredSymbol(enumDeclaration)
            ?? throw new InvalidOperationException("Enum symbol not found");
    }

    private static async Task<IEnumerable<MetadataReference>> ResolveReferenceAssemblies() =>
        [
            .. await ReferenceAssemblies.Net.Net80.ResolveAsync(LanguageNames.CSharp, CancellationToken.None),
            MetadataReference.CreateFromFile(typeof(EnumGeneratorAttribute).Assembly.Location),
        ];
}
