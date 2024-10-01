```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | UserRole             | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 | **18.9262 ns** | **0.4261 ns** | **0.6245 ns** | **19.3029 ns** |  **1.00** |    **0.05** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |  1.9962 ns | 0.0098 ns | 0.0138 ns |  1.9909 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 | 10.2572 ns | 0.1932 ns | 0.2832 ns | 10.3148 ns |  0.54 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |  0.5948 ns | 0.0042 ns | 0.0057 ns |  0.5932 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |  2.6483 ns | 0.0034 ns | 0.0048 ns |  2.6488 ns |  0.14 |    0.00 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Norma(...)odian [21]** | **39.7057 ns** | **0.3162 ns** | **0.4635 ns** | **39.5702 ns** |  **1.00** |    **0.02** | **0.0210** |      **88 B** |        **1.00** |
| FastEnumToString     | Norma(...)odian [21] |  4.1017 ns | 0.0663 ns | 0.0992 ns |  4.1197 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Norma(...)odian [21] | 92.9009 ns | 2.9166 ns | 4.1829 ns | 91.3679 ns |  2.34 |    0.11 | 0.0650 |     272 B |        3.09 |
| NetEscapadesToString | Norma(...)odian [21] | 39.7915 ns | 0.5282 ns | 0.7742 ns | 39.7756 ns |  1.00 |    0.02 | 0.0210 |      88 B |        1.00 |
| RaiqubToString       | Norma(...)odian [21] | 53.1574 ns | 0.6769 ns | 0.9922 ns | 53.0244 ns |  1.34 |    0.03 | 0.0153 |      64 B |        0.73 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Finance**              | **16.9717 ns** | **0.1351 ns** | **0.1895 ns** | **16.9096 ns** |  **1.00** |    **0.02** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Finance              |  1.9932 ns | 0.0064 ns | 0.0090 ns |  1.9908 ns |  0.12 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Finance              | 10.2512 ns | 0.1689 ns | 0.2528 ns | 10.1470 ns |  0.60 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | Finance              |  1.9912 ns | 1.0519 ns | 1.4746 ns |  0.6177 ns |  0.12 |    0.09 |      - |         - |        0.00 |
| RaiqubToString       | Finance              |  2.5181 ns | 0.1023 ns | 0.1401 ns |  2.5313 ns |  0.15 |    0.01 |      - |         - |        0.00 |
|                      |                      |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**                 | **31.6864 ns** | **0.2568 ns** | **0.3765 ns** | **31.6220 ns** |  **1.00** |    **0.02** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000                 | 12.8423 ns | 0.0729 ns | 0.1069 ns | 12.8367 ns |  0.41 |    0.01 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000                 | 27.4920 ns | 0.3816 ns | 0.5712 ns | 27.5322 ns |  0.87 |    0.02 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000                 | 32.2151 ns | 0.2926 ns | 0.4380 ns | 32.1749 ns |  1.02 |    0.02 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000                 | 39.4085 ns | 0.4311 ns | 0.6183 ns | 39.5890 ns |  1.24 |    0.02 | 0.0076 |      32 B |        0.57 |
