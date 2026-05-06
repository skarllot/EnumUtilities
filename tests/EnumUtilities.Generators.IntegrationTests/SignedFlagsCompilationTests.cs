namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class SignedFlagsCompilationTests
{
    [Fact]
    public void ToStringFastForSignedNegativeFlagsEnumReturnsName()
    {
        Assert.Equal("All", SignedNegativePermissions.All.ToStringFast());
    }

    [Fact]
    public void ToStringFastForSignedNegativeFlagsEnumZeroReturnsNumeric()
    {
        Assert.Equal("0", ((SignedNegativePermissions)0).ToStringFast());
    }

    [Fact]
    public void GetStringLengthForSignedNegativeFlagsEnumReturnsNameLength()
    {
        Assert.Equal("All".Length, SignedNegativePermissions.All.GetStringLength());
    }

    [Fact]
    public void GetStringLengthForSignedNegativeFlagsEnumZeroReturnsOne()
    {
        Assert.Equal(1, ((SignedNegativePermissions)0).GetStringLength());
    }
}

[Flags]
[EnumGenerator]
public enum SignedNegativePermissions
{
    All = -1,
}
