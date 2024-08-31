using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[MediumRunJob]
public class SmallFlagsEnumToString
{
    public IEnumerable<UserRole> Values =>
    [
        0, (UserRole)4, (UserRole)3, (UserRole)1000,
    ];

    [ParamsSource(nameof(Values))] public UserRole UserRole;

    [Benchmark(Baseline = true)]
    public string BuiltInToString() => UserRole.ToString();

    [Benchmark]
    public string FastEnumToString() => UserRole.FastToString();

    [Benchmark]
    public string EnumsNetAsString() => UserRole.AsString();

    [Benchmark]
    public string NetEscapadesToString() => UserRoleNetEscapades.ToStringFast(UserRole);

    [Benchmark]
    public string RaiqubToString() => UserRoleExtensions.ToStringFast(UserRole);
}
