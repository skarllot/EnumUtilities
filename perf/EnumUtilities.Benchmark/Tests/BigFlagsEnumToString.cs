using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[ShortRunJob]
public class BigFlagsEnumToString
{
    public IEnumerable<Permissions> Values =>
    [
        0, (Permissions)1, (Permissions)2, (Permissions)3, (Permissions)1000, (Permissions)int.MaxValue,
    ];

    [ParamsSource(nameof(Values))] public Permissions Permissions;

    [Benchmark(Baseline = true)]
    public string BuiltInToString() => Permissions.ToString();

    [Benchmark]
    public string FastEnumToString() => Permissions.FastToString();

    [Benchmark]
    public string EnumsNetAsString() => Permissions.AsString();

    [Benchmark]
    public string NetEscapadesToString() => PermissionsNetEscapades.ToStringFast(Permissions);

    [Benchmark]
    public string RaiqubToString() => PermissionsExtensions.ToStringFast(Permissions);
}
