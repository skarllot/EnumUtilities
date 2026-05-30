using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Common;

public class CSharpExtensionsTest
{
    [Theory]
    [InlineData("int", "")]
    [InlineData("uint", "u")]
    [InlineData("long", "l")]
    [InlineData("ulong", "ul")]
    [InlineData("nuint", "u")]
    public void GetNumericSuffixFromCSharpKeyword_ReturnsExpectedSuffix(string keyword, string expected)
    {
        var actual = CSharpExtensions.GetNumericSuffixFromCSharpKeyword(keyword);

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
        var actual = CSharpExtensions.GetTypeNameFromCSharpKeyword(keyword);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LiteralHelpers_ReturnExpectedCSharpLiterals()
    {
        Assert.Equal("null", CSharpExtensions.ToQuotedStringOrNullLiteral(null));
        Assert.Equal("\"text\"", "text".ToQuotedStringOrNullLiteral());
        Assert.Equal("\"quoted\"", "quoted".ToQuotedStringLiteral());
        Assert.Equal("'x'", 'x'.ToQuotedCharLiteral());
    }
}
