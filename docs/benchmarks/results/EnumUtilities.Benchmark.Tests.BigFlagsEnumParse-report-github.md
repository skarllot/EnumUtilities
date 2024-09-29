```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method            | Permissions          | Mean         | Error       | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------ |--------------------- |-------------:|------------:|-----------:|------:|--------:|----------:|------------:|
| **BuiltInParse**      | **0**                    |    **13.969 ns** |   **0.4105 ns** |  **0.0225 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | 0                    |     9.465 ns |   0.2312 ns |  0.0127 ns |  0.68 |    0.00 |         - |          NA |
| EnumsNetParse     | 0                    |    52.358 ns |   9.0714 ns |  0.4972 ns |  3.75 |    0.03 |         - |          NA |
| NetEscapadesParse | 0                    |    10.033 ns |   0.4162 ns |  0.0228 ns |  0.72 |    0.00 |         - |          NA |
| RaiqubParse       | 0                    |     9.750 ns |   0.1218 ns |  0.0067 ns |  0.70 |    0.00 |         - |          NA |
|                   |                      |              |             |            |       |         |           |             |
| **BuiltInParse**      | **Delet(...) Move [39]** |   **309.103 ns** |  **25.2595 ns** |  **1.3846 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Delet(...) Move [39] |           NA |          NA |         NA |     ? |       ? |        NA |           ? |
| EnumsNetParse     | Delet(...) Move [39] |   287.777 ns |  23.8002 ns |  1.3046 ns |  0.93 |    0.01 |         - |          NA |
| NetEscapadesParse | Delet(...) Move [39] |           NA |          NA |         NA |     ? |       ? |        NA |           ? |
| RaiqubParse       | Delet(...) Move [39] |   268.626 ns |   4.8155 ns |  0.2640 ns |  0.87 |    0.00 |         - |          NA |
|                   |                      |              |             |            |       |         |           |             |
| **BuiltInParse**      | **Read, Write**          |    **64.462 ns** |  **18.2779 ns** |  **1.0019 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| FastEnumParse     | Read, Write          |           NA |          NA |         NA |     ? |       ? |        NA |           ? |
| EnumsNetParse     | Read, Write          |    98.956 ns |  14.7615 ns |  0.8091 ns |  1.54 |    0.02 |         - |          NA |
| NetEscapadesParse | Read, Write          |           NA |          NA |         NA |     ? |       ? |        NA |           ? |
| RaiqubParse       | Read, Write          |    59.020 ns |   2.5150 ns |  0.1379 ns |  0.92 |    0.01 |         - |          NA |
|                   |                      |              |             |            |       |         |           |             |
| **BuiltInParse**      | **Read(...)lock [245]**  | **2,810.899 ns** | **183.4545 ns** | **10.0558 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | Read(...)lock [245]  |           NA |          NA |         NA |     ? |       ? |        NA |           ? |
| EnumsNetParse     | Read(...)lock [245]  | 1,649.241 ns |  98.5935 ns |  5.4042 ns |  0.59 |    0.00 |         - |          NA |
| NetEscapadesParse | Read(...)lock [245]  |           NA |          NA |         NA |     ? |       ? |        NA |           ? |
| RaiqubParse       | Read(...)lock [245]  | 1,524.217 ns | 148.1772 ns |  8.1221 ns |  0.54 |    0.00 |         - |          NA |
|                   |                      |              |             |            |       |         |           |             |
| **BuiltInParse**      | **Restore**              |    **80.103 ns** |  **15.8450 ns** |  **0.8685 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Restore              |    16.460 ns |   2.3405 ns |  0.1283 ns |  0.21 |    0.00 |         - |          NA |
| EnumsNetParse     | Restore              |    55.256 ns |   1.7769 ns |  0.0974 ns |  0.69 |    0.01 |         - |          NA |
| NetEscapadesParse | Restore              |     3.881 ns |   1.0668 ns |  0.0585 ns |  0.05 |    0.00 |         - |          NA |
| RaiqubParse       | Restore              |    41.228 ns | 195.0600 ns | 10.6919 ns |  0.51 |    0.12 |         - |          NA |

Benchmarks with issues:
  BigFlagsEnumParse.FastEnumParse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Permissions=Delet(...) Move [39]]
  BigFlagsEnumParse.NetEscapadesParse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Permissions=Delet(...) Move [39]]
  BigFlagsEnumParse.FastEnumParse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Permissions=Read, Write]
  BigFlagsEnumParse.NetEscapadesParse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Permissions=Read, Write]
  BigFlagsEnumParse.FastEnumParse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Permissions=Read(...)lock [245]]
  BigFlagsEnumParse.NetEscapadesParse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [Permissions=Read(...)lock [245]]
