```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method            | UserRole             | Mean       | Error      | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------ |--------------------- |-----------:|-----------:|----------:|------:|--------:|----------:|------------:|
| **BuiltInParse**      | **0**                    |  **14.001 ns** |  **0.0906 ns** | **0.0050 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | 0                    |  10.014 ns |  1.8782 ns | 0.1029 ns |  0.72 |    0.01 |         - |          NA |
| EnumsNetParse     | 0                    |  46.890 ns |  1.4149 ns | 0.0776 ns |  3.35 |    0.00 |         - |          NA |
| NetEscapadesParse | 0                    |  12.358 ns |  0.7729 ns | 0.0424 ns |  0.88 |    0.00 |         - |          NA |
| RaiqubParse       | 0                    |   9.892 ns |  3.8879 ns | 0.2131 ns |  0.71 |    0.01 |         - |          NA |
|                   |                      |            |            |           |       |         |           |             |
| **BuiltInParse**      | **1000**                 |  **17.547 ns** |  **0.2791 ns** | **0.0153 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | 1000                 |  15.577 ns | 10.1293 ns | 0.5552 ns |  0.89 |    0.03 |         - |          NA |
| EnumsNetParse     | 1000                 |  57.488 ns |  3.2699 ns | 0.1792 ns |  3.28 |    0.01 |         - |          NA |
| NetEscapadesParse | 1000                 |  13.750 ns |  3.5915 ns | 0.1969 ns |  0.78 |    0.01 |         - |          NA |
| RaiqubParse       | 1000                 |  17.224 ns |  7.3088 ns | 0.4006 ns |  0.98 |    0.02 |         - |          NA |
|                   |                      |            |            |           |       |         |           |             |
| **BuiltInParse**      | **Finance**              |  **31.519 ns** |  **4.2551 ns** | **0.2332 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Finance              |  15.900 ns |  1.2769 ns | 0.0700 ns |  0.50 |    0.00 |         - |          NA |
| EnumsNetParse     | Finance              |  55.958 ns | 17.7279 ns | 0.9717 ns |  1.78 |    0.03 |         - |          NA |
| NetEscapadesParse | Finance              |   3.683 ns |  1.6504 ns | 0.0905 ns |  0.12 |    0.00 |         - |          NA |
| RaiqubParse       | Finance              |  27.491 ns |  0.7636 ns | 0.0419 ns |  0.87 |    0.01 |         - |          NA |
|                   |                      |            |            |           |       |         |           |             |
| **BuiltInParse**      | **Norma(...)odian [21]** |  **57.972 ns** |  **0.1959 ns** | **0.0107 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | Norma(...)odian [21] |         NA |         NA |        NA |     ? |       ? |        NA |           ? |
| EnumsNetParse     | Norma(...)odian [21] | 104.368 ns |  3.5294 ns | 0.1935 ns |  1.80 |    0.00 |         - |          NA |
| NetEscapadesParse | Norma(...)odian [21] |         NA |         NA |        NA |     ? |       ? |        NA |           ? |
| RaiqubParse       | Norma(...)odian [21] |  59.976 ns |  2.1213 ns | 0.1163 ns |  1.03 |    0.00 |         - |          NA |

Benchmarks with issues:
  SmallFlagsEnumParse.FastEnumParse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [UserRole=Norma(...)odian [21]]
  SmallFlagsEnumParse.NetEscapadesParse: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [UserRole=Norma(...)odian [21]]
