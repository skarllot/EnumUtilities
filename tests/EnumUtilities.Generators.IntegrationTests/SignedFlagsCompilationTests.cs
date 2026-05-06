namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

public class SignedFlagsCompilationTests
{
    [Fact]
    public void SignedNegativeFlagsEnumCanBeGenerated()
    {
        Assert.Equal(SignedNegativePermissions.All, SignedNegativePermissions.All);
    }
}

[Flags]
[EnumGenerator]
public enum SignedNegativePermissions
{
    All = -1,
}
