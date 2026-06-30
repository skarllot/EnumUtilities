using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Testing;
using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Common;

public class CSharpUtilsTest
{
    [Theory]
    [InlineData("int", "")]
    [InlineData("uint", "U")]
    [InlineData("long", "L")]
    [InlineData("ulong", "UL")]
    [InlineData("nuint", "U")]
    public void GetNumericSuffixFromCSharpKeyword_ReturnsExpectedSuffix(string keyword, string expected)
    {
        var actual = CSharpUtils.GetNumericSuffixFromCSharpKeyword(keyword);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("sbyte", "SByte")]
    [InlineData("byte", "Byte")]
    [InlineData("short", "Int16")]
    [InlineData("ushort", "UInt16")]
    [InlineData("int", "Int32")]
    [InlineData("uint", "UInt32")]
    [InlineData("long", "Int64")]
    [InlineData("ulong", "UInt64")]
    [InlineData("nint", "IntPtr")]
    [InlineData("nuint", "UIntPtr")]
    [InlineData("CustomType", "CustomType")]
    public void GetTypeNameFromCSharpKeyword_ReturnsExpectedTypeName(string keyword, string expected)
    {
        var actual = CSharpUtils.GetTypeNameFromCSharpKeyword(keyword);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("public int Value { get; set; }", "int")]
    [InlineData("public System.Int32 Value { get; set; }", "int")]
    [InlineData("public System.UInt16 Value { get; set; }", "ushort")]
    [InlineData("public string? Value { get; set; }", "string?")]
    [InlineData("public System.String? Value { get; set; }", "string?")]
    [InlineData("public int? Value { get; set; }", "int?")]
    [InlineData("public System.Int32? Value { get; set; }", "int?")]
    [InlineData("public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int?>> Value { get; set; }", "Dictionary<string, List<int?>>")]
    [InlineData("public Outer.Inner Value { get; set; }", "Inner")]
    [InlineData("public Outer.@event Value { get; set; }", "@event")]
    public async Task ToCSharpTypeName_ReturnsExpectedTypeName(string propertyDeclaration, string expected)
    {
        var typeSymbol = await GetPropertyTypeSymbol(propertyDeclaration);

        var actual = typeSymbol.ToCSharpTypeName();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LiteralHelpers_ReturnExpectedCSharpLiterals()
    {
        Assert.Equal("null", CSharpUtils.ToQuotedStringOrNullLiteral(null));
        Assert.Equal("\"text\"", "text".ToQuotedStringOrNullLiteral());
        Assert.Equal("\"quoted\"", "quoted".ToQuotedStringLiteral());
        Assert.Equal("'x'", 'x'.ToQuotedCharLiteral());
    }

    private static async Task<ITypeSymbol> GetPropertyTypeSymbol(string propertyDeclaration)
    {
        string source = $$"""
            #nullable enable

            public class TestTarget
            {
                {{propertyDeclaration}}
            }

            public class Outer
            {
                public class Inner
                {
                }

                public class @event
                {
                }
            }
            """;

        var compilation = CSharpCompilation.Create(
            "TestAssembly",
            syntaxTrees: [CSharpSyntaxTree.ParseText(source)],
            references: await ReferenceAssemblies.Net.Net80.ResolveAsync(LanguageNames.CSharp, CancellationToken.None),
            options: new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                nullableContextOptions: NullableContextOptions.Enable
            )
        );

        var syntaxTree = compilation.SyntaxTrees.Single();
        var semanticModel = compilation.GetSemanticModel(syntaxTree);
        var propertyDeclarationSyntax = (await syntaxTree.GetRootAsync())
            .DescendantNodes()
            .OfType<PropertyDeclarationSyntax>()
            .Single(static x => x.Identifier.ValueText == "Value");

        return semanticModel.GetDeclaredSymbol(propertyDeclarationSyntax)?.Type
            ?? throw new InvalidOperationException("Property type symbol not found");
    }
}
