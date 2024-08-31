using NetEscapades.EnumGenerators;
using Raiqub.Generators.EnumUtilities;

namespace EnumUtilities.Benchmark.Models;

[Flags]
[EnumExtensions(ExtensionClassName = "UserRoleNetEscapades")]
[EnumGenerator]
public enum UserRole
{
    None = 0,
    NormalUser = 1 << 0,
    Custodian = 1 << 1,
    Finance = 1 << 2,
    SuperUser = Custodian | Finance,
    All = Custodian | Finance | NormalUser
}
