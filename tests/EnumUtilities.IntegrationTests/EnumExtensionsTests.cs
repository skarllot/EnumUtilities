using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class EnumExtensionsTests
{
    [Theory]
    [InlineData(Colours.Red)]
    [InlineData(Colours.Green)]
    [InlineData(Colours.Green | Colours.Blue)]
    [InlineData((Colours)15)]
    [InlineData((Colours)0)]
    public void FastToStringIsSameAsToStringUsingFlagEnum(Colours value)
    {
        string expected = value.ToString();
        string actual = value.ToStringFast();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(HumanStates.Idle)]
    [InlineData(HumanStates.Working)]
    [InlineData(HumanStates.Sleeping)]
    [InlineData(HumanStates.Eating)]
    [InlineData(HumanStates.Dead)]
    [InlineData((HumanStates)0)]
    [InlineData((HumanStates)100)]
    public void FastToStringIsSameAsToString(HumanStates value)
    {
        string expected = value.ToString();
        string actual = value.ToStringFast();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(HumanStates.Idle)]
    [InlineData(HumanStates.Working)]
    [InlineData(HumanStates.Sleeping)]
    [InlineData(HumanStates.Eating)]
    [InlineData(HumanStates.Dead)]
    [InlineData((HumanStates)0)]
    [InlineData((HumanStates)(-1))]
    [InlineData((HumanStates)10)]
    [InlineData((HumanStates)(-10))]
    [InlineData((HumanStates)100)]
    public void IsDefinedIsSameAsEnumIsDefined(HumanStates value)
    {
        bool expected = Enum.IsDefined(value);
        bool actual = value.IsDefined();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green, Colours.Red)]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green, Colours.Blue)]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green, Colours.Green)]
    [InlineData(Colours.Red | Colours.Blue, Colours.Red)]
    [InlineData(Colours.Red | Colours.Blue, Colours.Blue)]
    [InlineData(Colours.Red | Colours.Blue, Colours.Green)]
    [InlineData(Colours.Red | Colours.Green, Colours.Red)]
    [InlineData(Colours.Red | Colours.Green, Colours.Blue)]
    [InlineData(Colours.Red | Colours.Green, Colours.Green)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Red)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Blue)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Green)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Green | Colours.Blue)]
    [InlineData(Colours.Blue | Colours.Green, Colours.Green | Colours.Red)]
    [InlineData(Colours.Blue, Colours.Red)]
    [InlineData(Colours.Blue, Colours.Red | Colours.Green)]
    [InlineData(Colours.Blue, Colours.Blue)]
    [InlineData((Colours)0, Colours.Red)]
    [InlineData((Colours)0, Colours.Blue)]
    [InlineData((Colours)0, Colours.Green)]
    [InlineData(Colours.Red, (Colours)0)]
    [InlineData(Colours.Blue, (Colours)0)]
    [InlineData(Colours.Green, (Colours)0)]
    public void HasFlagIsSameAsEnumHasFlag(Colours value, Colours flag)
    {
        bool expected = value.HasFlag(flag);
        bool actual = value.HasFlagFast(flag);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green)]
    [InlineData(Colours.Red | Colours.Blue)]
    [InlineData(Colours.Red | Colours.Green)]
    [InlineData(Colours.Blue | Colours.Green)]
    [InlineData((Colours)0)]
    [InlineData(Colours.Red)]
    [InlineData(Colours.Blue)]
    [InlineData(Colours.Green)]
    public void StringWriteAsToString(Colours value)
    {
        string expected = value.ToString();

        int stringCount = value.GetStringCount();
        Span<char> buffer = stackalloc char[stringCount];
        bool isSuccess = value.TryWriteString(buffer, out int charsWritten);

        Assert.Equal(expected.Length, stringCount);
        Assert.Equal(expected.Length, charsWritten);
        Assert.Equal(expected, buffer.ToString());
        Assert.True(isSuccess);

        buffer.Clear();
        buffer = stackalloc char[stringCount * 2];
        isSuccess = value.TryWriteString(buffer, out charsWritten);

        Assert.Equal(expected.Length, charsWritten);
        Assert.Equal(expected, buffer[..charsWritten].ToString());
        Assert.True(isSuccess);

        buffer.Clear();
        buffer = stackalloc char[stringCount / 2];
        isSuccess = value.TryWriteString(buffer, out charsWritten);

        Assert.Equal(0, charsWritten);
        Assert.False(isSuccess);
    }

    [Theory]
    [InlineData(Colours.Red | Colours.Blue | Colours.Green)]
    [InlineData(Colours.Red | Colours.Blue)]
    [InlineData(Colours.Red | Colours.Green)]
    [InlineData(Colours.Blue | Colours.Green)]
    [InlineData((Colours)0)]
    [InlineData(Colours.Red)]
    [InlineData(Colours.Blue)]
    [InlineData(Colours.Green)]
    public void Utf8WriteAsToStringAndEncoding(Colours value)
    {
        string expected = value.ToString();
        byte[] expectedBytes = System.Text.Encoding.UTF8.GetBytes(expected);

        int byteCount = value.GetUtf8ByteCount();
        Span<byte> buffer = stackalloc byte[byteCount];
        bool isSuccess = value.TryWriteUtf8Bytes(buffer, out int bytesWritten);

        Assert.Equal(expectedBytes.Length, byteCount);
        Assert.Equal(expectedBytes.Length, bytesWritten);
        Assert.Equal(expectedBytes, buffer.ToArray());
        Assert.True(isSuccess);

        buffer.Clear();
        buffer = stackalloc byte[byteCount * 2];
        isSuccess = value.TryWriteUtf8Bytes(buffer, out bytesWritten);

        Assert.Equal(expectedBytes.Length, bytesWritten);
        Assert.Equal(expectedBytes, buffer[..bytesWritten].ToArray());
        Assert.True(isSuccess);

        buffer.Clear();
        buffer = stackalloc byte[byteCount / 2];
        isSuccess = value.TryWriteUtf8Bytes(buffer, out bytesWritten);

        Assert.Equal(0, bytesWritten);
        Assert.False(isSuccess);
    }
}
