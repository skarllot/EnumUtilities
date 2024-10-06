using BenchmarkDotNet.Attributes;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[MediumRunJob]
public class SpanAndStringComparison
{
    public static ReadOnlySpan<char> Value => "FullControl";

    [Benchmark]
    public bool WithSequenceEqual() => Value.SequenceEqual("FullControl");

    [Benchmark]
    public bool WithIsExpression() => Value is "FullControl";

    [Benchmark]
    public bool WithEqualsOrdinal() => Value.Equals("FullControl", StringComparison.Ordinal);

    [Benchmark]
    public bool WithEqualsOrdinalIgnoreCase() => Value.Equals("FullControl", StringComparison.OrdinalIgnoreCase);
}
