```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method            | Elf       | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------ |---------- |-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **BuiltInParse**      | **0**         |  **14.092 ns** | **0.0950 ns** | **0.1362 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | 0         |  10.113 ns | 0.1324 ns | 0.1982 ns |  0.72 |    0.02 |         - |          NA |
| EnumsNetParse     | 0         |  13.221 ns | 1.0329 ns | 1.5140 ns |  0.94 |    0.11 |         - |          NA |
| NetEscapadesParse | 0         |  12.523 ns | 0.1352 ns | 0.2024 ns |  0.89 |    0.02 |         - |          NA |
| RaiqubParse       | 0         |   8.948 ns | 0.0174 ns | 0.0250 ns |  0.64 |    0.01 |         - |          NA |
|                   |           |            |           |           |       |         |           |             |
| **BuiltInParse**      | **1000**      |  **17.552 ns** | **0.0592 ns** | **0.0830 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | 1000      |  14.647 ns | 0.1684 ns | 0.2520 ns |  0.83 |    0.01 |         - |          NA |
| EnumsNetParse     | 1000      |  15.446 ns | 0.2096 ns | 0.3006 ns |  0.88 |    0.02 |         - |          NA |
| NetEscapadesParse | 1000      |  17.396 ns | 0.2157 ns | 0.3229 ns |  0.99 |    0.02 |         - |          NA |
| RaiqubParse       | 1000      |  11.993 ns | 0.1449 ns | 0.2124 ns |  0.68 |    0.01 |         - |          NA |
|                   |           |            |           |           |       |         |           |             |
| **BuiltInParse**      | **Aredhel**   | **155.198 ns** | **0.9888 ns** | **1.4494 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Aredhel   |  16.344 ns | 0.3097 ns | 0.4342 ns |  0.11 |    0.00 |         - |          NA |
| EnumsNetParse     | Aredhel   |  23.796 ns | 0.1843 ns | 0.2701 ns |  0.15 |    0.00 |         - |          NA |
| NetEscapadesParse | Aredhel   |   4.154 ns | 0.0123 ns | 0.0168 ns |  0.03 |    0.00 |         - |          NA |
| RaiqubParse       | Aredhel   |  30.648 ns | 0.1663 ns | 0.2438 ns |  0.20 |    0.00 |         - |          NA |
|                   |           |            |           |           |       |         |           |             |
| **BuiltInParse**      | **Galadriel** |  **24.391 ns** | **0.1304 ns** | **0.1870 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Galadriel |  17.397 ns | 0.0476 ns | 0.0667 ns |  0.71 |    0.01 |         - |          NA |
| EnumsNetParse     | Galadriel |  27.588 ns | 1.8840 ns | 2.5788 ns |  1.13 |    0.10 |         - |          NA |
| NetEscapadesParse | Galadriel |   4.981 ns | 0.0165 ns | 0.0236 ns |  0.20 |    0.00 |         - |          NA |
| RaiqubParse       | Galadriel |  15.842 ns | 0.0658 ns | 0.0943 ns |  0.65 |    0.01 |         - |          NA |
