```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8246/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 1600 3.20GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.203
  [Host]    : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
  MediumRun : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Valar | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**     | **17.7561 ns** | **0.2292 ns** | **0.3287 ns** | **17.6630 ns** |  **1.00** |    **0.03** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0     |  3.5614 ns | 0.0152 ns | 0.0228 ns |  3.5600 ns |  0.20 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 0     |  3.6571 ns | 0.0072 ns | 0.0101 ns |  3.6584 ns |  0.21 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | 0     | 22.4841 ns | 0.0343 ns | 0.0481 ns | 22.5021 ns |  1.27 |    0.02 | 0.0057 |      24 B |        1.00 |
| RaiqubToString       | 0     |  0.6050 ns | 0.1946 ns | 0.2853 ns |  0.8714 ns |  0.03 |    0.02 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Manwe** | **16.5629 ns** | **0.0311 ns** | **0.0415 ns** | **16.5794 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Manwe |  1.4328 ns | 0.0028 ns | 0.0037 ns |  1.4316 ns |  0.09 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Manwe |  1.2094 ns | 0.0181 ns | 0.0265 ns |  1.2064 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Manwe |  1.0647 ns | 0.0006 ns | 0.0009 ns |  1.0648 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Manwe |  0.3147 ns | 0.0018 ns | 0.0025 ns |  0.3146 ns |  0.02 |    0.00 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Orome** | **16.1856 ns** | **0.2351 ns** | **0.3218 ns** | **15.9327 ns** |  **1.00** |    **0.03** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Orome |  1.4336 ns | 0.0032 ns | 0.0046 ns |  1.4359 ns |  0.09 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Orome |  1.1979 ns | 0.0138 ns | 0.0207 ns |  1.1952 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Orome |  0.5056 ns | 0.0007 ns | 0.0009 ns |  0.5059 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Orome |  0.3064 ns | 0.0023 ns | 0.0032 ns |  0.3041 ns |  0.02 |    0.00 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**  | **24.5372 ns** | **0.0575 ns** | **0.0824 ns** | **24.5595 ns** |  **1.00** |    **0.00** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000  | 11.8304 ns | 0.0322 ns | 0.0430 ns | 11.8482 ns |  0.48 |    0.00 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000  |  9.7427 ns | 0.0769 ns | 0.1128 ns |  9.7162 ns |  0.40 |    0.00 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000  | 25.8667 ns | 0.0355 ns | 0.0474 ns | 25.8600 ns |  1.05 |    0.00 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000  |  9.5459 ns | 0.0328 ns | 0.0460 ns |  9.5639 ns |  0.39 |    0.00 | 0.0076 |      32 B |        0.57 |
