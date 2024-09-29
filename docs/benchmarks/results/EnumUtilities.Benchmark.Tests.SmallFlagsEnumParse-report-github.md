```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method            | UserRole             | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------ |--------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|------------:|
| **BuiltInParse**      | **0**                    |  **14.022 ns** | **0.0230 ns** | **0.0307 ns** |  **14.017 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | 0                    |  10.012 ns | 0.1077 ns | 0.1612 ns |  10.057 ns |  0.71 |    0.01 |         - |          NA |
| EnumsNetParse     | 0                    |  50.657 ns | 2.8684 ns | 4.2044 ns |  47.094 ns |  3.61 |    0.29 |         - |          NA |
| NetEscapadesParse | 0                    |  12.302 ns | 0.1605 ns | 0.2402 ns |  12.362 ns |  0.88 |    0.02 |         - |          NA |
| RaiqubParse       | 0                    |   9.005 ns | 0.0818 ns | 0.1173 ns |   8.968 ns |  0.64 |    0.01 |         - |          NA |
|                   |                      |            |           |           |            |       |         |           |             |
| **BuiltInParse**      | **1000**                 |  **17.456 ns** | **0.0863 ns** | **0.1238 ns** |  **17.389 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | 1000                 |  15.580 ns | 0.1854 ns | 0.2717 ns |  15.551 ns |  0.89 |    0.02 |         - |          NA |
| EnumsNetParse     | 1000                 |  54.989 ns | 2.8136 ns | 4.0352 ns |  51.950 ns |  3.15 |    0.23 |         - |          NA |
| NetEscapadesParse | 1000                 |  13.685 ns | 0.1206 ns | 0.1730 ns |  13.650 ns |  0.78 |    0.01 |         - |          NA |
| RaiqubParse       | 1000                 |  11.706 ns | 0.0142 ns | 0.0190 ns |  11.701 ns |  0.67 |    0.00 |         - |          NA |
|                   |                      |            |           |           |            |       |         |           |             |
| **BuiltInParse**      | **Finance**              |  **31.276 ns** | **0.0901 ns** | **0.1292 ns** |  **31.251 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Finance              |  17.342 ns | 0.3175 ns | 0.4554 ns |  17.383 ns |  0.55 |    0.01 |         - |          NA |
| EnumsNetParse     | Finance              |  56.770 ns | 1.1868 ns | 1.7397 ns |  57.285 ns |  1.82 |    0.06 |         - |          NA |
| NetEscapadesParse | Finance              |   3.586 ns | 0.0131 ns | 0.0180 ns |   3.582 ns |  0.11 |    0.00 |         - |          NA |
| RaiqubParse       | Finance              |  23.580 ns | 0.0616 ns | 0.0922 ns |  23.575 ns |  0.75 |    0.00 |         - |          NA |
|                   |                      |            |           |           |            |       |         |           |             |
| **BuiltInParse**      | **Norma(...)odian [21]** |  **54.871 ns** | **0.5531 ns** | **0.8108 ns** |  **55.448 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| FastEnumParse     | Norma(...)odian [21] |         NA |        NA |        NA |         NA |     ? |       ? |        NA |           ? |
| EnumsNetParse     | Norma(...)odian [21] | 111.366 ns | 3.7530 ns | 5.3824 ns | 115.807 ns |  2.03 |    0.10 |         - |          NA |
| NetEscapadesParse | Norma(...)odian [21] |         NA |        NA |        NA |         NA |     ? |       ? |        NA |           ? |
| RaiqubParse       | Norma(...)odian [21] |  51.310 ns | 1.1999 ns | 1.6821 ns |  52.648 ns |  0.94 |    0.03 |         - |          NA |

Benchmarks with issues:
  SmallFlagsEnumParse.FastEnumParse: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10) [UserRole=Norma(...)odian [21]]
  SmallFlagsEnumParse.NetEscapadesParse: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10) [UserRole=Norma(...)odian [21]]
