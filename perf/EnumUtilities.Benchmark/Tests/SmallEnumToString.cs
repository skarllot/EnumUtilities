using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[MediumRunJob]
public class SmallEnumToString
{
    public IEnumerable<Valar> Values =>
    [
        0, (Valar)1, (Valar)8, (Valar)1000,
    ];

    [ParamsSource(nameof(Values))] public Valar Valar;

    [Benchmark(Baseline = true)]
    public string BuiltInToString() => Valar.ToString();

    [Benchmark]
    public string FastEnumToString() => Valar.FastToString();

    [Benchmark]
    public string EnumsNetAsString() => Valar.AsString();

    [Benchmark]
    public string NetEscapadesToString() => ValarNetEscapades.ToStringFast(Valar);

    [Benchmark]
    public string RaiqubToString() => ValarExtensions.ToStringFast(Valar);
}
