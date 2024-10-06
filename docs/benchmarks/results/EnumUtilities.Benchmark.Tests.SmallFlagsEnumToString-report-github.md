```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.402
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | UserRole             | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 | **19.1148 ns** | **0.4327 ns** | **0.6206 ns** | **19.2761 ns** |  **1.00** |    **0.05** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |  2.0306 ns | 0.0332 ns | 0.0487 ns |  2.0098 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 | 10.1247 ns | 0.0661 ns | 0.0969 ns | 10.1027 ns |  0.53 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |  0.5979 ns | 0.0086 ns | 0.0124 ns |  0.5933 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |  1.5882 ns | 1.0655 ns | 1.5618 ns |  3.0292 ns |  0.08 |    0.08 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Norma(...)odian [21]** | **40.7145 ns** | **0.5689 ns** | **0.8515 ns** | **40.6010 ns** |  **1.00** |    **0.03** | **0.0210** |      **88 B** |        **1.00** |
| FastEnumToString     | Norma(...)odian [21] |  4.1197 ns | 0.0378 ns | 0.0541 ns |  4.1236 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Norma(...)odian [21] | 88.4588 ns | 1.7050 ns | 2.4991 ns | 88.1528 ns |  2.17 |    0.07 | 0.0650 |     272 B |        3.09 |
| NetEscapadesToString | Norma(...)odian [21] | 40.2000 ns | 0.7233 ns | 1.0373 ns | 40.1987 ns |  0.99 |    0.03 | 0.0210 |      88 B |        1.00 |
| RaiqubToString       | Norma(...)odian [21] | 26.8832 ns | 0.2570 ns | 0.3518 ns | 26.8011 ns |  0.66 |    0.02 | 0.0153 |      64 B |        0.73 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Finance**              | **17.5430 ns** | **0.2216 ns** | **0.3317 ns** | **17.3545 ns** |  **1.00** |    **0.03** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Finance              |  2.0256 ns | 0.0409 ns | 0.0574 ns |  1.9936 ns |  0.12 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Finance              | 10.6250 ns | 0.0748 ns | 0.1096 ns | 10.6391 ns |  0.61 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | Finance              |  0.6002 ns | 0.0071 ns | 0.0104 ns |  0.5971 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Finance              |  3.0593 ns | 0.0289 ns | 0.0415 ns |  3.0409 ns |  0.17 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**                 | **31.7633 ns** | **0.5174 ns** | **0.7585 ns** | **31.5629 ns** |  **1.00** |    **0.03** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000                 | 12.9321 ns | 0.2368 ns | 0.3396 ns | 12.8832 ns |  0.41 |    0.01 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000                 | 28.3015 ns | 0.5274 ns | 0.7393 ns | 28.5094 ns |  0.89 |    0.03 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000                 | 36.0344 ns | 1.0062 ns | 1.4430 ns | 35.3920 ns |  1.14 |    0.05 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000                 | 17.9861 ns | 0.1850 ns | 0.2711 ns | 17.9528 ns |  0.57 |    0.02 | 0.0076 |      32 B |        0.57 |
