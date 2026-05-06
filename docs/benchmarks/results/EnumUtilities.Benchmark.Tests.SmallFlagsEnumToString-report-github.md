```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8246/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 1600 3.20GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.203
  [Host]    : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
  MediumRun : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | UserRole             | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 | **15.3704 ns** | **0.0610 ns** | **0.0895 ns** | **15.3822 ns** | **1.000** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |  1.5957 ns | 0.0463 ns | 0.0694 ns |  1.5992 ns | 0.104 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |  5.3884 ns | 0.0734 ns | 0.1099 ns |  5.4188 ns | 0.351 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |  0.5235 ns | 0.0038 ns | 0.0055 ns |  0.5217 ns | 0.034 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |  0.0392 ns | 0.0035 ns | 0.0053 ns |  0.0371 ns | 0.003 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Norma(...)odian [21]** | **36.7798 ns** | **0.0473 ns** | **0.0679 ns** | **36.7629 ns** | **1.000** |    **0.00** | **0.0210** |      **88 B** |        **1.00** |
| FastEnumToString     | Norma(...)odian [21] |  3.6829 ns | 0.4511 ns | 0.6613 ns |  3.0729 ns | 0.100 |    0.02 |      - |         - |        0.00 |
| EnumsNetAsString     | Norma(...)odian [21] | 82.2975 ns | 0.7031 ns | 0.9624 ns | 82.2921 ns | 2.238 |    0.03 | 0.0650 |     272 B |        3.09 |
| NetEscapadesToString | Norma(...)odian [21] | 38.3062 ns | 0.3985 ns | 0.5455 ns | 38.3497 ns | 1.042 |    0.01 | 0.0210 |      88 B |        1.00 |
| RaiqubToString       | Norma(...)odian [21] |  0.0426 ns | 0.0055 ns | 0.0077 ns |  0.0427 ns | 0.001 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Finance**              | **16.3556 ns** | **0.0869 ns** | **0.1218 ns** | **16.4315 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Finance              |  1.6576 ns | 0.0491 ns | 0.0735 ns |  1.6883 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Finance              |  5.3537 ns | 0.0472 ns | 0.0707 ns |  5.3364 ns |  0.33 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Finance              |  0.5192 ns | 0.0106 ns | 0.0155 ns |  0.5221 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Finance              |  0.3275 ns | 0.1628 ns | 0.2386 ns |  0.4963 ns |  0.02 |    0.01 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**                 | **29.0040 ns** | **1.3880 ns** | **1.9457 ns** | **30.7938 ns** |  **1.00** |    **0.09** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000                 |  9.6716 ns | 0.0858 ns | 0.1230 ns |  9.6791 ns |  0.33 |    0.02 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000                 | 31.3108 ns | 0.6787 ns | 0.9061 ns | 32.1376 ns |  1.08 |    0.08 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000                 | 33.8962 ns | 0.0471 ns | 0.0676 ns | 33.8905 ns |  1.17 |    0.08 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000                 | 10.3950 ns | 0.0682 ns | 0.0957 ns | 10.4768 ns |  0.36 |    0.02 | 0.0076 |      32 B |        0.57 |
