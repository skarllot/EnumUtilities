```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method               | UserRole             | Mean       | Error      | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |-----------:|-----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 | **19.3618 ns** |  **1.1458 ns** | **0.0628 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |  2.0564 ns |  0.9365 ns | 0.0513 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 | 10.0795 ns |  0.8580 ns | 0.0470 ns |  0.52 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |  0.5989 ns |  0.2161 ns | 0.0118 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |  2.6467 ns |  0.6115 ns | 0.0335 ns |  0.14 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |            |           |       |         |        |           |             |
| **BuiltInToString**      | **NormalUser**           | **20.4852 ns** |  **0.9664 ns** | **0.0530 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | NormalUser           |  2.0025 ns |  0.0762 ns | 0.0042 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | NormalUser           | 11.3174 ns |  1.8659 ns | 0.1023 ns |  0.55 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | NormalUser           |  0.5930 ns |  0.1606 ns | 0.0088 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | NormalUser           |  4.7956 ns |  0.4307 ns | 0.0236 ns |  0.23 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |            |           |       |         |        |           |             |
| **BuiltInToString**      | **Custodian**            | **19.0396 ns** |  **1.1672 ns** | **0.0640 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Custodian            |  2.0446 ns |  0.2399 ns | 0.0131 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Custodian            | 10.6607 ns |  1.5621 ns | 0.0856 ns |  0.56 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Custodian            |  0.5927 ns |  0.0923 ns | 0.0051 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Custodian            |  4.7772 ns |  0.5328 ns | 0.0292 ns |  0.25 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |            |           |       |         |        |           |             |
| **BuiltInToString**      | **Norma(...)odian [21]** | **39.8868 ns** |  **4.2253 ns** | **0.2316 ns** |  **1.00** |    **0.01** | **0.0210** |      **88 B** |        **1.00** |
| FastEnumToString     | Norma(...)odian [21] |  4.1657 ns |  0.3090 ns | 0.0169 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Norma(...)odian [21] | 99.0919 ns | 18.7826 ns | 1.0295 ns |  2.48 |    0.03 | 0.0650 |     272 B |        3.09 |
| NetEscapadesToString | Norma(...)odian [21] | 42.0607 ns |  2.5330 ns | 0.1388 ns |  1.05 |    0.01 | 0.0210 |      88 B |        1.00 |
| RaiqubToString       | Norma(...)odian [21] | 38.3157 ns | 10.0788 ns | 0.5525 ns |  0.96 |    0.01 | 0.0153 |      64 B |        0.73 |
|                      |                      |            |            |           |       |         |        |           |             |
| **BuiltInToString**      | **1000**                 | **32.7451 ns** |  **3.2732 ns** | **0.1794 ns** |  **1.00** |    **0.01** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000                 | 13.5435 ns |  2.2021 ns | 0.1207 ns |  0.41 |    0.00 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000                 | 28.3097 ns |  1.4405 ns | 0.0790 ns |  0.86 |    0.00 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000                 | 32.7864 ns |  7.4280 ns | 0.4072 ns |  1.00 |    0.01 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000                 | 16.8431 ns |  4.2852 ns | 0.2349 ns |  0.51 |    0.01 | 0.0076 |      32 B |        0.57 |
