using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[MediumRunJob]
public class SmallEnumParse
{
    public IEnumerable<string> Values =>
    [
        "0", "Manwe", "Orome", "1000",
    ];

    [ParamsSource(nameof(Values))] public string Valar = string.Empty;

    [Benchmark(Baseline = true)]
    public Valar BuiltInParse() => Enum.Parse<Valar>(Valar);

    [Benchmark]
    public Valar FastEnumParse() => FastEnum.Parse<Valar>(Valar);

    [Benchmark]
    public Valar EnumsNetParse() => Enums.Parse<Valar>(Valar);

    [Benchmark]
    public Valar NetEscapadesParse() => ValarNetEscapades.Parse(Valar);

    [Benchmark]
    public Valar RaiqubParse() => ValarFactory.Parse(Valar);
}
