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
| **BuiltInToString**      | **None**                 | **19.9233 ns** | **0.3463 ns** | **0.5183 ns** | **19.8098 ns** |  **1.00** |    **0.04** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |  2.0298 ns | 0.0385 ns | 0.0576 ns |  2.0054 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 | 10.1277 ns | 0.1159 ns | 0.1586 ns | 10.1027 ns |  0.51 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |  0.6990 ns | 0.1844 ns | 0.2703 ns |  0.5969 ns |  0.04 |    0.01 |      - |         - |        0.00 |
| RaiqubToString       | None                 |  3.1517 ns | 0.0344 ns | 0.0515 ns |  3.1372 ns |  0.16 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Norma(...)odian [21]** | **41.2541 ns** | **1.0701 ns** | **1.6017 ns** | **40.3107 ns** |  **1.00** |    **0.05** | **0.0210** |      **88 B** |        **1.00** |
| FastEnumToString     | Norma(...)odian [21] |  4.1921 ns | 0.0911 ns | 0.1336 ns |  4.1692 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Norma(...)odian [21] | 96.9764 ns | 1.6947 ns | 2.5365 ns | 96.2342 ns |  2.35 |    0.11 | 0.0650 |     272 B |        3.09 |
| NetEscapadesToString | Norma(...)odian [21] | 41.3143 ns | 1.0621 ns | 1.5232 ns | 40.7374 ns |  1.00 |    0.05 | 0.0210 |      88 B |        1.00 |
| RaiqubToString       | Norma(...)odian [21] | 28.2099 ns | 0.7528 ns | 1.1035 ns | 27.7924 ns |  0.68 |    0.04 | 0.0153 |      64 B |        0.73 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Finance**              | **17.4765 ns** | **0.3285 ns** | **0.4711 ns** | **17.3328 ns** |  **1.00** |    **0.04** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Finance              |  2.0170 ns | 0.0353 ns | 0.0506 ns |  1.9934 ns |  0.12 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Finance              | 11.0520 ns | 0.2927 ns | 0.4291 ns | 11.2337 ns |  0.63 |    0.03 |      - |         - |        0.00 |
| NetEscapadesToString | Finance              |  0.5987 ns | 0.0109 ns | 0.0153 ns |  0.5941 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Finance              |  3.1775 ns | 0.0610 ns | 0.0855 ns |  3.1492 ns |  0.18 |    0.01 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**                 | **32.1257 ns** | **0.5378 ns** | **0.7539 ns** | **31.9608 ns** |  **1.00** |    **0.03** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000                 | 13.3046 ns | 0.3542 ns | 0.5191 ns | 13.0942 ns |  0.41 |    0.02 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000                 | 28.7435 ns | 0.5761 ns | 0.8623 ns | 28.4929 ns |  0.90 |    0.03 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000                 | 34.1454 ns | 1.1009 ns | 1.6137 ns | 34.5629 ns |  1.06 |    0.05 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000                 | 18.2736 ns | 0.4083 ns | 0.5985 ns | 18.0293 ns |  0.57 |    0.02 | 0.0076 |      32 B |        0.57 |
