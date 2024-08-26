using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
public class EnumToString
{
    public IEnumerable<int> Values => [0, 1, 2, 3, 1000, int.MaxValue];

    [ParamsSource(nameof(Values))] public int Permissions;

    [Benchmark(Baseline = true)]
    public string BuiltInToString() => ((Permissions)Permissions).ToString();

    [Benchmark]
    public string FastEnumToString() => ((Permissions)Permissions).FastToString();

    [Benchmark]
    public string EnumsNetAsString() => ((Permissions)Permissions).AsString();

    [Benchmark]
    public string NetEscapadesToString() => ((PermissionsNetEscapades)Permissions).ToStringFast();

    [Benchmark]
    public string RaiqubToString() => ((PermissionsRaiqub)Permissions).ToStringFast();
}
