using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[ShortRunJob]
public class SmallFlagsEnumParse
{
    public IEnumerable<string> Values =>
    [
        "0", "Finance", "NormalUser, Custodian", "1000",
    ];

    [ParamsSource(nameof(Values))] public string UserRole = string.Empty;

    [Benchmark(Baseline = true)]
    public UserRole BuiltInParse() => Enum.Parse<UserRole>(UserRole);

    [Benchmark]
    public UserRole FastEnumParse() => FastEnum.Parse<UserRole>(UserRole);

    [Benchmark]
    public UserRole EnumsNetParse() => Enums.Parse<UserRole>(UserRole);

    [Benchmark]
    public UserRole NetEscapadesParse() => UserRoleNetEscapades.Parse(UserRole);

    [Benchmark]
    public UserRole RaiqubParse() => UserRoleFactory.Parse(UserRole);
}
