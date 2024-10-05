```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.402
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Valar | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**     | **19.6044 ns** | **0.4683 ns** | **0.6716 ns** | **19.5574 ns** |  **1.00** |    **0.05** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0     |  2.8459 ns | 0.0652 ns | 0.0976 ns |  2.8312 ns |  0.15 |    0.01 |      - |         - |        0.00 |
| EnumsNetAsString     | 0     |  3.1221 ns | 0.0549 ns | 0.0822 ns |  3.0909 ns |  0.16 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | 0     | 20.2675 ns | 0.4122 ns | 0.6170 ns | 20.1215 ns |  1.03 |    0.05 | 0.0057 |      24 B |        1.00 |
| RaiqubToString       | 0     |  1.1779 ns | 0.0283 ns | 0.0407 ns |  1.1641 ns |  0.06 |    0.00 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Manwe** | **16.7010 ns** | **0.3702 ns** | **0.5309 ns** | **16.5678 ns** |  **1.00** |    **0.04** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Manwe |  1.1979 ns | 0.0501 ns | 0.0750 ns |  1.1555 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Manwe |  1.4548 ns | 0.0330 ns | 0.0484 ns |  1.4489 ns |  0.09 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Manwe |  0.3467 ns | 0.0380 ns | 0.0569 ns |  0.3142 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Manwe |  1.1572 ns | 0.0072 ns | 0.0103 ns |  1.1564 ns |  0.07 |    0.00 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **Orome** | **16.7389 ns** | **0.3565 ns** | **0.5225 ns** | **16.7787 ns** |  **1.00** |    **0.04** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Orome |  1.1582 ns | 0.0114 ns | 0.0157 ns |  1.1547 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Orome |  1.4048 ns | 0.0200 ns | 0.0273 ns |  1.3951 ns |  0.08 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Orome |  0.5997 ns | 0.0119 ns | 0.0163 ns |  0.5946 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Orome |  1.1680 ns | 0.0137 ns | 0.0196 ns |  1.1626 ns |  0.07 |    0.00 |      - |         - |        0.00 |
|                      |       |            |           |           |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**  | **28.9346 ns** | **0.9582 ns** | **1.4341 ns** | **28.3032 ns** |  **1.00** |    **0.07** | **0.0134** |      **56 B** |        **1.00** |
| FastEnumToString     | 1000  | 10.7276 ns | 0.3232 ns | 0.4838 ns | 10.7191 ns |  0.37 |    0.02 | 0.0076 |      32 B |        0.57 |
| EnumsNetAsString     | 1000  | 12.8546 ns | 0.2450 ns | 0.3514 ns | 12.7347 ns |  0.45 |    0.02 | 0.0076 |      32 B |        0.57 |
| NetEscapadesToString | 1000  | 29.8411 ns | 0.6350 ns | 0.8901 ns | 29.5377 ns |  1.03 |    0.06 | 0.0134 |      56 B |        1.00 |
| RaiqubToString       | 1000  | 13.2219 ns | 0.3314 ns | 0.4858 ns | 13.0578 ns |  0.46 |    0.03 | 0.0076 |      32 B |        0.57 |
