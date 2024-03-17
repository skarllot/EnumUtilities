using System.Text;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class CodePointTests
{
    [Theory]
    [InlineData("$", 1)]
    [InlineData("a", 1)]
    [InlineData("á", 2)]
    [InlineData("\u00a3", 2)]
    [InlineData("И", 2)]
    [InlineData("ह", 3)]
    [InlineData("\u20ac", 3)]
    [InlineData("한", 3)]
    [InlineData("\ud800\udf48", 4)]
    [InlineData("😊", 4)]
    public void ShouldGetFirstCharacter(string c, int len)
    {
        Span<byte> buffer = stackalloc byte[16];
        int bytes = Encoding.UTF8.GetBytes(c, buffer);

        bool success = CodePoint.TryGetFirstCodePoint(buffer, out CodePoint rune);

        uint expectedValue = (uint)char.ConvertToUtf32(c, 0);
        rune.EncodeToUtf16(out char h, out char? l);

        Assert.True(success);
        Assert.Equal(expectedValue, rune.Value);
        Assert.Equal(c[0], h);
        Assert.Equal(len, rune.Utf8SequenceLength);
        Assert.Equal(bytes, rune.Utf8SequenceLength);

        if (l != null)
        {
            Assert.Equal(c[1], l.Value);
        }
    }
}
