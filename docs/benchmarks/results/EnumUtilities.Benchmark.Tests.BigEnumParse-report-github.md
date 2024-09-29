```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method            | Elf       | Mean       | Error      | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------ |---------- |-----------:|-----------:|----------:|------:|--------:|----------:|------------:|
| **BuiltInParse**      | **0**         |  **14.149 ns** |  **2.0112 ns** | **0.1102 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | 0         |  10.017 ns |  0.3115 ns | 0.0171 ns |  0.71 |    0.00 |         - |          NA |
| EnumsNetParse     | 0         |  12.705 ns |  0.9405 ns | 0.0516 ns |  0.90 |    0.01 |         - |          NA |
| NetEscapadesParse | 0         |  12.545 ns |  3.2984 ns | 0.1808 ns |  0.89 |    0.01 |         - |          NA |
| RaiqubParse       | 0         |   9.745 ns |  0.4941 ns | 0.0271 ns |  0.69 |    0.00 |         - |          NA |
|                   |           |            |            |           |       |         |           |             |
| **BuiltInParse**      | **1000**      |  **17.533 ns** |  **0.1701 ns** | **0.0093 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | 1000      |  14.923 ns |  2.6570 ns | 0.1456 ns |  0.85 |    0.01 |         - |          NA |
| EnumsNetParse     | 1000      |  15.276 ns |  2.7916 ns | 0.1530 ns |  0.87 |    0.01 |         - |          NA |
| NetEscapadesParse | 1000      |  16.272 ns |  2.3683 ns | 0.1298 ns |  0.93 |    0.01 |         - |          NA |
| RaiqubParse       | 1000      |  15.145 ns |  6.6080 ns | 0.3622 ns |  0.86 |    0.02 |         - |          NA |
|                   |           |            |            |           |       |         |           |             |
| **BuiltInParse**      | **Aredhel**   | **160.192 ns** |  **7.6723 ns** | **0.4205 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | Aredhel   |  16.750 ns |  1.7082 ns | 0.0936 ns |  0.10 |    0.00 |         - |          NA |
| EnumsNetParse     | Aredhel   |  23.360 ns |  0.5812 ns | 0.0319 ns |  0.15 |    0.00 |         - |          NA |
| NetEscapadesParse | Aredhel   |   4.193 ns |  1.0858 ns | 0.0595 ns |  0.03 |    0.00 |         - |          NA |
| RaiqubParse       | Aredhel   |  32.072 ns | 12.1268 ns | 0.6647 ns |  0.20 |    0.00 |         - |          NA |
|                   |           |            |            |           |       |         |           |             |
| **BuiltInParse**      | **Galadriel** |  **24.453 ns** |  **2.3232 ns** | **0.1273 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Galadriel |  17.364 ns |  0.6128 ns | 0.0336 ns |  0.71 |    0.00 |         - |          NA |
| EnumsNetParse     | Galadriel |  27.680 ns |  0.0943 ns | 0.0052 ns |  1.13 |    0.01 |         - |          NA |
| NetEscapadesParse | Galadriel |   4.960 ns |  0.0369 ns | 0.0020 ns |  0.20 |    0.00 |         - |          NA |
| RaiqubParse       | Galadriel |  18.577 ns |  1.0747 ns | 0.0589 ns |  0.76 |    0.00 |         - |          NA |
