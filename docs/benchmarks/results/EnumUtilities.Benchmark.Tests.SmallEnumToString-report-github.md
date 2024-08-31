```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method               | Valar | Mean       | Error      | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |------ |-----------:|-----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**     | **18.7290 ns** |  **1.2415 ns** | **0.0681 ns** | **18.7209 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0     |  2.6522 ns |  1.4138 ns | 0.0775 ns |  2.6836 ns |  0.14 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 0     |  3.1340 ns |  1.0229 ns | 0.0561 ns |  3.1385 ns |  0.17 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | 0     | 19.6103 ns |  2.3656 ns | 0.1297 ns | 19.6105 ns |  1.05 |    0.01 | 0.0057 |      24 B |        1.00 |
| RaiqubToString       | 0     |  1.1210 ns |  0.0447 ns | 0.0025 ns |  1.1208 ns |  0.06 |    0.00 |      - |         - |        0.00 |
|                      |       |            |            |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Manwe** | **16.8233 ns** | **13.9097 ns** | **0.7624 ns** | **16.3973 ns** |  **1.00** |    **0.05** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Manwe |  1.2095 ns |  0.2137 ns | 0.0117 ns |  1.2156 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Manwe |  1.8634 ns | 13.7571 ns | 0.7541 ns |  1.4299 ns |  0.11 |    0.04 |      - |         - |        0.00 |
| NetEscapadesToString | Manwe |  0.5880 ns |  0.2182 ns | 0.0120 ns |  0.5813 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Manwe |  1.1265 ns |  0.1325 ns | 0.0073 ns |  1.1295 ns |  0.07 |    0.00 |      - |         - |        0.00 |
|                      |       |            |            |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**  | **27.0860 ns** |  **6.5078 ns** | **0.3567 ns** | **26.8806 ns** |  **1.00** |    **0.02** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000  | 10.2772 ns |  0.6742 ns | 0.0370 ns | 10.2636 ns |  0.38 |    0.00 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000  | 12.4972 ns |  1.3994 ns | 0.0767 ns | 12.4554 ns |  0.46 |    0.01 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000  | 27.8485 ns |  2.7466 ns | 0.1505 ns | 27.9118 ns |  1.03 |    0.01 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000  | 12.4895 ns |  1.5151 ns | 0.0830 ns | 12.4703 ns |  0.46 |    0.01 | 0.0076 |      32 B |        0.57 |
