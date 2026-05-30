```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8246/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 1600 3.20GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.203
  [Host]    : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
  MediumRun : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Elf       | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**         | **20.7477 ns** | **0.2299 ns** | **0.3440 ns** | **20.6757 ns** |  **1.00** |    **0.02** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0         |  3.5168 ns | 0.0081 ns | 0.0108 ns |  3.5263 ns |  0.17 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 0         |  3.6667 ns | 0.0007 ns | 0.0010 ns |  3.6667 ns |  0.18 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | 0         | 26.3042 ns | 3.1106 ns | 4.4612 ns | 25.5509 ns |  1.27 |    0.21 | 0.0057 |      24 B |        1.00 |
| RaiqubToString       | 0         |  0.8265 ns | 0.2134 ns | 0.2992 ns |  1.0820 ns |  0.04 |    0.01 |      - |         - |        0.00 |
|                      |           |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Galadriel** | **16.7456 ns** | **0.3517 ns** | **0.4930 ns** | **16.8754 ns** |  **1.00** |    **0.04** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Galadriel |  1.2510 ns | 0.0252 ns | 0.0370 ns |  1.2342 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Galadriel |  1.2313 ns | 0.0293 ns | 0.0429 ns |  1.2185 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Galadriel |  0.5991 ns | 0.0068 ns | 0.0097 ns |  0.5943 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Galadriel |  0.5249 ns | 0.0054 ns | 0.0079 ns |  0.5228 ns |  0.03 |    0.00 |      - |         - |        0.00 |
|                      |           |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Aredhel**   | **18.7110 ns** | **0.2231 ns** | **0.3199 ns** | **18.7415 ns** |  **1.00** |    **0.02** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Aredhel   |  1.2241 ns | 0.0075 ns | 0.0105 ns |  1.2236 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Aredhel   |  1.2231 ns | 0.0132 ns | 0.0193 ns |  1.2252 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Aredhel   |  0.5767 ns | 0.0295 ns | 0.0442 ns |  0.5930 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Aredhel   |  0.5232 ns | 0.0007 ns | 0.0009 ns |  0.5235 ns |  0.03 |    0.00 |      - |         - |        0.00 |
|                      |           |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**      | **27.2108 ns** | **0.0231 ns** | **0.0317 ns** | **27.2060 ns** |  **1.00** |    **0.00** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000      | 11.8960 ns | 0.0537 ns | 0.0736 ns | 11.8715 ns |  0.44 |    0.00 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000      |  9.7946 ns | 0.1025 ns | 0.1437 ns |  9.7795 ns |  0.36 |    0.01 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000      | 28.4338 ns | 0.0882 ns | 0.1208 ns | 28.4311 ns |  1.04 |    0.00 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000      |  8.9448 ns | 0.0300 ns | 0.0440 ns |  8.9267 ns |  0.33 |    0.00 | 0.0076 |      32 B |        0.57 |
