using BenchmarkDotNet.Attributes;
using EnumsNET;
using EnumUtilities.Benchmark.Models;
using FastEnumUtility;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[MediumRunJob]
public class BigFlagsEnumParse
{
    public IEnumerable<string> Values =>
    [
        "0", "Restore", "Read, Write", "Delete, Create, View, Share, Copy, Move",
        "Read, Write, Execute, Delete, Modify, Create, View, Share, Copy, Move, Rename, Download, Upload, Sync, " +
        "Archive, Restore, Print, Preview, Search, Tag, Annotate, Comment, Approve, Reject, Publish, Subscribe, " +
        "Unsubscribe, Manage, Edit, Lock, Unlock",
    ];

    [ParamsSource(nameof(Values))] public string Permissions = string.Empty;

    [Benchmark(Baseline = true)]
    public Permissions BuiltInParse() => Enum.Parse<Permissions>(Permissions);

    [Benchmark]
    public Permissions FastEnumParse() => FastEnum.Parse<Permissions>(Permissions);

    [Benchmark]
    public Permissions EnumsNetParse() => Enums.Parse<Permissions>(Permissions);

    [Benchmark]
    public Permissions NetEscapadesParse() => PermissionsNetEscapades.Parse(Permissions);

    [Benchmark]
    public Permissions RaiqubParse() => PermissionsFactory.Parse(Permissions);
}
