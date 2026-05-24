namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class SignedFlagsCompilationTests
{
    [Fact]
    public void SignedNegativeFlagsEnumCanBeGenerated()
    {
        var value = SignedNegativePermissions.All;
        Assert.Equal(value.ToString(), value.ToStringFast());
        Assert.Equal(value.ToString().Length, value.GetStringLength());
    }

    [Fact]
    public void ToStringFastForSignedNegativeFlagsEnumZeroReturnsNumeric()
    {
        Assert.Equal("0", ((SignedNegativePermissions)0).ToStringFast());
    }

    [Fact]
    public void GetStringLengthForSignedNegativeFlagsEnumZeroReturnsOne()
    {
        Assert.Equal(1, ((SignedNegativePermissions)0).GetStringLength());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void ToStringFastForSignedNegativeFlagsEnumUndefinedValueMatchesToString(int raw)
    {
        var value = (SignedNegativePermissions)raw;
        Assert.Equal(value.ToString(), value.ToStringFast());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void GetStringLengthForSignedNegativeFlagsEnumUndefinedValueMatchesToStringLength(int raw)
    {
        var value = (SignedNegativePermissions)raw;
        Assert.Equal(value.ToString().Length, value.GetStringLength());
    }

    [Flags]
    [EnumGenerator]
    public enum SignedNegativePermissions
    {
        All = -1,
    }
}
