```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Elf       | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**         | **21.8449 ns** | **0.1919 ns** | **0.2627 ns** |  **1.00** |    **0.02** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0         |  2.8746 ns | 0.0515 ns | 0.0770 ns |  0.13 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 0         |  3.1202 ns | 0.0261 ns | 0.0366 ns |  0.14 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | 0         | 21.1394 ns | 0.1022 ns | 0.1498 ns |  0.97 |    0.01 | 0.0057 |      24 B |        1.00 |
| RaiqubToString       | 0         |  1.0632 ns | 0.0109 ns | 0.0163 ns |  0.05 |    0.00 |      - |         - |        0.00 |
|                      |           |            |           |           |       |         |        |           |             |
| **BuiltInToString**      | **Galadriel** | **16.1126 ns** | **0.0646 ns** | **0.0947 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Galadriel |  1.1632 ns | 0.0239 ns | 0.0350 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Galadriel |  1.3902 ns | 0.0274 ns | 0.0402 ns |  0.09 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Galadriel |  0.5385 ns | 0.0135 ns | 0.0198 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Galadriel |  1.0580 ns | 0.0050 ns | 0.0073 ns |  0.07 |    0.00 |      - |         - |        0.00 |
|                      |           |            |           |           |       |         |        |           |             |
| **BuiltInToString**      | **Aredhel**   | **18.8738 ns** | **0.0841 ns** | **0.1206 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Aredhel   |  1.1784 ns | 0.0149 ns | 0.0223 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Aredhel   |  1.3896 ns | 0.0261 ns | 0.0383 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Aredhel   |  0.5147 ns | 0.0048 ns | 0.0068 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Aredhel   |  1.0474 ns | 0.0003 ns | 0.0004 ns |  0.06 |    0.00 |      - |         - |        0.00 |
|                      |           |            |           |           |       |         |        |           |             |
| **BuiltInToString**      | **1000**      | **29.1128 ns** | **0.3477 ns** | **0.4875 ns** |  **1.00** |    **0.02** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000      | 10.2551 ns | 0.1284 ns | 0.1922 ns |  0.35 |    0.01 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000      | 12.2631 ns | 0.0311 ns | 0.0465 ns |  0.42 |    0.01 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000      | 31.1824 ns | 0.4499 ns | 0.6453 ns |  1.07 |    0.03 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000      | 14.9208 ns | 0.0542 ns | 0.0760 ns |  0.51 |    0.01 | 0.0076 |      32 B |        0.57 |
