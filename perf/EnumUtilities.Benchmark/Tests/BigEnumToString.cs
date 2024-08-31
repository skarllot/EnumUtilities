using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[ShortRunJob]
public class BigEnumToString
{
    public IEnumerable<Elf> Values => [0, (Elf)1, (Elf)1000];

    [ParamsSource(nameof(Values))] public Elf Elf;

    [Benchmark(Baseline = true)]
    public string BuiltInToString() => Elf.ToString();

    [Benchmark]
    public string FastEnumToString() => Elf.FastToString();

    [Benchmark]
    public string EnumsNetAsString() => Elf.AsString();

    [Benchmark]
    public string NetEscapadesToString() => ElfNetEscapades.ToStringFast(Elf);

    [Benchmark]
    public string RaiqubToString() => ElfExtensions.ToStringFast(Elf);
}
