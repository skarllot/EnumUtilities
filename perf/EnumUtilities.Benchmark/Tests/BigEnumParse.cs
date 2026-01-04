using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[MediumRunJob]
public class BigEnumParse
{
    public IEnumerable<string> Values => ["0", "Galadriel", "Aredhel", "1000"];

    [ParamsSource(nameof(Values))]
    public string Elf = string.Empty;

    [Benchmark(Baseline = true)]
    public Elf BuiltInParse() => Enum.Parse<Elf>(Elf);

    [Benchmark]
    public Elf FastEnumParse() => FastEnum.Parse<Elf>(Elf);

    [Benchmark]
    public Elf EnumsNetParse() => Enums.Parse<Elf>(Elf);

    [Benchmark]
    public Elf NetEscapadesParse() => ElfNetEscapades.Parse(Elf);

    [Benchmark]
    public Elf RaiqubParse() => ElfFactory.Parse(Elf);
}
