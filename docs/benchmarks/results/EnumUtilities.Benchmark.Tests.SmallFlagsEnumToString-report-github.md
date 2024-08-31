```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | UserRole             | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 | **17.7612 ns** | **0.0634 ns** | **0.0930 ns** | **17.7200 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |  1.9513 ns | 0.0079 ns | 0.0116 ns |  1.9547 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 | 10.5482 ns | 0.2287 ns | 0.3280 ns | 10.4963 ns |  0.59 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |  0.5763 ns | 0.0018 ns | 0.0024 ns |  0.5754 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |  3.0419 ns | 0.0160 ns | 0.0224 ns |  3.0414 ns |  0.17 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Norma(...)odian [21]** | **38.6200 ns** | **0.2814 ns** | **0.4211 ns** | **38.5593 ns** |  **1.00** |    **0.02** | **0.0210** |      **88 B** |        **1.00** |
| FastEnumToString     | Norma(...)odian [21] |  4.0180 ns | 0.0459 ns | 0.0687 ns |  4.0378 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Norma(...)odian [21] | 84.1761 ns | 1.2723 ns | 1.8649 ns | 83.0579 ns |  2.18 |    0.05 | 0.0650 |     272 B |        3.09 |
| NetEscapadesToString | Norma(...)odian [21] | 39.0868 ns | 0.0515 ns | 0.0756 ns | 39.0901 ns |  1.01 |    0.01 | 0.0210 |      88 B |        1.00 |
| RaiqubToString       | Norma(...)odian [21] | 31.6976 ns | 0.1746 ns | 0.2559 ns | 31.8447 ns |  0.82 |    0.01 | 0.0153 |      64 B |        0.73 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Finance**              | **16.4793 ns** | **0.0516 ns** | **0.0740 ns** | **16.4590 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Finance              |  1.9427 ns | 0.0081 ns | 0.0119 ns |  1.9384 ns |  0.12 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Finance              |  9.9714 ns | 0.1723 ns | 0.2579 ns |  9.9170 ns |  0.61 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | Finance              |  0.5779 ns | 0.0011 ns | 0.0015 ns |  0.5780 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Finance              |  3.0293 ns | 0.0108 ns | 0.0151 ns |  3.0292 ns |  0.18 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**                 | **30.0111 ns** | **0.0510 ns** | **0.0732 ns** | **30.0155 ns** |  **1.00** |    **0.00** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000                 | 12.4452 ns | 0.0353 ns | 0.0518 ns | 12.4528 ns |  0.41 |    0.00 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000                 | 27.2778 ns | 0.5823 ns | 0.8351 ns | 27.2444 ns |  0.91 |    0.03 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000                 | 31.6890 ns | 0.7693 ns | 1.1033 ns | 30.9733 ns |  1.06 |    0.04 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000                 | 17.8523 ns | 0.0177 ns | 0.0253 ns | 17.8537 ns |  0.59 |    0.00 | 0.0076 |      32 B |        0.57 |
