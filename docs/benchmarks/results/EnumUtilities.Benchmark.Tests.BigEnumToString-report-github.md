```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method               | Elf       | Mean       | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------- |-----------:|----------:|----------:|------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**         | **21.5545 ns** | **4.2486 ns** | **0.2329 ns** |  **1.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0         |  2.9632 ns | 0.0699 ns | 0.0038 ns |  0.14 |      - |         - |        0.00 |
| EnumsNetAsString     | 0         |  3.1461 ns | 0.0923 ns | 0.0051 ns |  0.15 |      - |         - |        0.00 |
| NetEscapadesToString | 0         | 21.7728 ns | 3.7777 ns | 0.2071 ns |  1.01 | 0.0057 |      24 B |        1.00 |
| RaiqubToString       | 0         |  1.1417 ns | 0.1926 ns | 0.0106 ns |  0.05 |      - |         - |        0.00 |
|                      |           |            |           |           |       |        |           |             |
| **BuiltInToString**      | **Galadriel** | **16.3335 ns** | **0.5744 ns** | **0.0315 ns** |  **1.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Galadriel |  1.2306 ns | 0.2139 ns | 0.0117 ns |  0.08 |      - |         - |        0.00 |
| EnumsNetAsString     | Galadriel |  1.4325 ns | 0.0132 ns | 0.0007 ns |  0.09 |      - |         - |        0.00 |
| NetEscapadesToString | Galadriel |  0.5460 ns | 0.3976 ns | 0.0218 ns |  0.03 |      - |         - |        0.00 |
| RaiqubToString       | Galadriel |  1.0713 ns | 0.2626 ns | 0.0144 ns |  0.07 |      - |         - |        0.00 |
|                      |           |            |           |           |       |        |           |             |
| **BuiltInToString**      | **1000**      | **29.3836 ns** | **3.2597 ns** | **0.1787 ns** |  **1.00** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000      | 10.3279 ns | 1.1353 ns | 0.0622 ns |  0.35 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000      | 12.4110 ns | 1.6927 ns | 0.0928 ns |  0.42 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000      | 31.1392 ns | 5.2550 ns | 0.2880 ns |  1.06 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000      | 14.9375 ns | 1.2246 ns | 0.0671 ns |  0.51 | 0.0076 |      32 B |        0.57 |
