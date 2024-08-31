```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method               | UserRole             | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 | **18.8350 ns** | **1.2709 ns** | **0.0697 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |  2.0704 ns | 0.3955 ns | 0.0217 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |  9.9823 ns | 3.2994 ns | 0.1809 ns |  0.53 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |  0.5800 ns | 0.0528 ns | 0.0029 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |  2.8858 ns | 0.9991 ns | 0.0548 ns |  0.15 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |       |         |        |           |             |
| **BuiltInToString**      | **NormalUser**           | **19.5875 ns** | **5.5706 ns** | **0.3053 ns** |  **1.00** |    **0.02** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | NormalUser           |  2.0459 ns | 0.2008 ns | 0.0110 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | NormalUser           | 10.1385 ns | 7.2485 ns | 0.3973 ns |  0.52 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | NormalUser           |  0.5902 ns | 0.4669 ns | 0.0256 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | NormalUser           |  3.1229 ns | 0.2688 ns | 0.0147 ns |  0.16 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |       |         |        |           |             |
| **BuiltInToString**      | **Custodian**            | **18.1248 ns** | **2.5847 ns** | **0.1417 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Custodian            |  2.0468 ns | 0.2970 ns | 0.0163 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Custodian            | 10.3800 ns | 1.9856 ns | 0.1088 ns |  0.57 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | Custodian            |  0.5752 ns | 0.0044 ns | 0.0002 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Custodian            |  3.0885 ns | 0.8323 ns | 0.0456 ns |  0.17 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |       |         |        |           |             |
| **BuiltInToString**      | **Norma(...)odian [21]** | **38.9204 ns** | **3.2934 ns** | **0.1805 ns** |  **1.00** |    **0.01** | **0.0210** |      **88 B** |        **1.00** |
| FastEnumToString     | Norma(...)odian [21] |  4.0932 ns | 1.1895 ns | 0.0652 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Norma(...)odian [21] | 88.0829 ns | 6.1122 ns | 0.3350 ns |  2.26 |    0.01 | 0.0650 |     272 B |        3.09 |
| NetEscapadesToString | Norma(...)odian [21] | 38.8265 ns | 2.2713 ns | 0.1245 ns |  1.00 |    0.00 | 0.0210 |      88 B |        1.00 |
| RaiqubToString       | Norma(...)odian [21] | 32.4450 ns | 3.2624 ns | 0.1788 ns |  0.83 |    0.01 | 0.0153 |      64 B |        0.73 |
|                      |                      |            |           |           |       |         |        |           |             |
| **BuiltInToString**      | **1000**                 | **31.4154 ns** | **0.9407 ns** | **0.0516 ns** |  **1.00** |    **0.00** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000                 | 12.8739 ns | 1.9566 ns | 0.1072 ns |  0.41 |    0.00 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000                 | 27.2961 ns | 1.8836 ns | 0.1032 ns |  0.87 |    0.00 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000                 | 36.3827 ns | 1.4837 ns | 0.0813 ns |  1.16 |    0.00 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000                 | 18.0918 ns | 2.0469 ns | 0.1122 ns |  0.58 |    0.00 | 0.0076 |      32 B |        0.57 |
