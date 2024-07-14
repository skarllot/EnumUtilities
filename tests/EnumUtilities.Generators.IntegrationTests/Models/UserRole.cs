namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[Flags]
[EnumGenerator]
public enum UserRole : ulong
{
    None = 0,
    NormalUser = 1UL << 0,
    Custodian = 1UL << 1,
    Finance = 1UL << 2,
    SuperUser = Custodian | Finance,
    All = Custodian | Finance | NormalUser
}
