```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.402
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Elf       | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**         | **22.5497 ns** | **0.5939 ns** | **0.8705 ns** | **22.2127 ns** |  **1.00** |    **0.05** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0         |  2.8814 ns | 0.0507 ns | 0.0711 ns |  2.8769 ns |  0.13 |    0.01 |      - |         - |        0.00 |
| EnumsNetAsString     | 0         |  3.2005 ns | 0.0897 ns | 0.1343 ns |  3.1692 ns |  0.14 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | 0         | 23.6147 ns | 0.6926 ns | 1.0366 ns | 23.3105 ns |  1.05 |    0.06 | 0.0057 |      24 B |        1.00 |
| RaiqubToString       | 0         |  1.1136 ns | 0.0399 ns | 0.0585 ns |  1.1042 ns |  0.05 |    0.00 |      - |         - |        0.00 |
|                      |           |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Galadriel** | **17.8062 ns** | **0.4506 ns** | **0.6744 ns** | **17.9230 ns** |  **1.00** |    **0.05** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Galadriel |  1.1964 ns | 0.0613 ns | 0.0838 ns |  1.1702 ns |  0.07 |    0.01 |      - |         - |        0.00 |
| EnumsNetAsString     | Galadriel |  1.3942 ns | 0.0218 ns | 0.0292 ns |  1.3933 ns |  0.08 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Galadriel |  0.5302 ns | 0.0167 ns | 0.0235 ns |  0.5234 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Galadriel |  1.0603 ns | 0.0301 ns | 0.0441 ns |  1.0709 ns |  0.06 |    0.00 |      - |         - |        0.00 |
|                      |           |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Aredhel**   | **19.4398 ns** | **0.5728 ns** | **0.8215 ns** | **19.1657 ns** |  **1.00** |    **0.06** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Aredhel   |  1.1834 ns | 0.0423 ns | 0.0606 ns |  1.1547 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Aredhel   |  1.4383 ns | 0.0378 ns | 0.0554 ns |  1.4201 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Aredhel   |  0.8025 ns | 0.1880 ns | 0.2696 ns |  0.6311 ns |  0.04 |    0.01 |      - |         - |        0.00 |
| RaiqubToString       | Aredhel   |  1.0795 ns | 0.0120 ns | 0.0160 ns |  1.0742 ns |  0.06 |    0.00 |      - |         - |        0.00 |
|                      |           |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**      | **30.5595 ns** | **0.7356 ns** | **1.0783 ns** | **30.5367 ns** |  **1.00** |    **0.05** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000      | 10.5993 ns | 0.2819 ns | 0.4219 ns | 10.4117 ns |  0.35 |    0.02 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000      | 12.8773 ns | 0.2627 ns | 0.3683 ns | 12.7960 ns |  0.42 |    0.02 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000      | 31.9137 ns | 0.4518 ns | 0.6479 ns | 31.7924 ns |  1.05 |    0.04 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000      | 15.8590 ns | 0.3727 ns | 0.5578 ns | 15.7718 ns |  0.52 |    0.03 | 0.0076 |      32 B |        0.57 |
