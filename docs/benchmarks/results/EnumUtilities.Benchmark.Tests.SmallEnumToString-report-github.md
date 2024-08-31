```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Valar | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**     | **18.9609 ns** | **0.2534 ns** | **0.3715 ns** | **19.1923 ns** |  **1.00** |    **0.03** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0     |  2.8235 ns | 0.0399 ns | 0.0597 ns |  2.8279 ns |  0.15 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 0     |  3.0227 ns | 0.0289 ns | 0.0424 ns |  3.0138 ns |  0.16 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | 0     | 19.3106 ns | 0.0625 ns | 0.0897 ns | 19.3338 ns |  1.02 |    0.02 | 0.0057 |      24 B |        1.00 |
| RaiqubToString       | 0     |  1.1255 ns | 0.0038 ns | 0.0056 ns |  1.1233 ns |  0.06 |    0.00 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Manwe** | **15.9864 ns** | **0.1016 ns** | **0.1489 ns** | **15.9851 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Manwe |  1.1261 ns | 0.0081 ns | 0.0116 ns |  1.1210 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Manwe |  1.3832 ns | 0.0174 ns | 0.0256 ns |  1.3863 ns |  0.09 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Manwe |  0.5764 ns | 0.0036 ns | 0.0052 ns |  0.5773 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Manwe |  1.1223 ns | 0.0023 ns | 0.0031 ns |  1.1212 ns |  0.07 |    0.00 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Orome** | **15.8455 ns** | **0.0388 ns** | **0.0544 ns** | **15.8556 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Orome |  1.1263 ns | 0.0042 ns | 0.0063 ns |  1.1251 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Orome |  1.3795 ns | 0.0266 ns | 0.0398 ns |  1.3643 ns |  0.09 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Orome |  0.4466 ns | 0.1006 ns | 0.1377 ns |  0.4479 ns |  0.03 |    0.01 |      - |         - |        0.00 |
| RaiqubToString       | Orome |  1.1216 ns | 0.0080 ns | 0.0110 ns |  1.1184 ns |  0.07 |    0.00 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**  | **26.4430 ns** | **0.1609 ns** | **0.2408 ns** | **26.4868 ns** |  **1.00** |    **0.01** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000  | 10.0328 ns | 0.0458 ns | 0.0685 ns | 10.0364 ns |  0.38 |    0.00 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000  | 12.2252 ns | 0.0696 ns | 0.0975 ns | 12.1693 ns |  0.46 |    0.01 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000  | 27.9312 ns | 0.1555 ns | 0.2280 ns | 27.9221 ns |  1.06 |    0.01 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000  | 12.4229 ns | 0.0222 ns | 0.0304 ns | 12.4094 ns |  0.47 |    0.00 | 0.0076 |      32 B |        0.57 |
