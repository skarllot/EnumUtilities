```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method            | Valar | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------ |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **BuiltInParse**      | **0**     | **14.009 ns** | **0.0380 ns** | **0.0520 ns** | **13.988 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | 0     | 10.025 ns | 0.0689 ns | 0.1031 ns | 10.013 ns |  0.72 |    0.01 |         - |          NA |
| EnumsNetParse     | 0     | 12.577 ns | 0.1104 ns | 0.1584 ns | 12.592 ns |  0.90 |    0.01 |         - |          NA |
| NetEscapadesParse | 0     |  9.304 ns | 0.1782 ns | 0.2667 ns |  9.256 ns |  0.66 |    0.02 |         - |          NA |
| RaiqubParse       | 0     |  8.974 ns | 0.0363 ns | 0.0521 ns |  8.970 ns |  0.64 |    0.00 |         - |          NA |
|                   |       |           |           |           |           |       |         |           |             |
| **BuiltInParse**      | **1000**  | **17.546 ns** | **0.0390 ns** | **0.0547 ns** | **17.546 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| FastEnumParse     | 1000  | 14.643 ns | 0.1779 ns | 0.2608 ns | 14.692 ns |  0.83 |    0.01 |         - |          NA |
| EnumsNetParse     | 1000  | 15.048 ns | 0.1278 ns | 0.1792 ns | 14.988 ns |  0.86 |    0.01 |         - |          NA |
| NetEscapadesParse | 1000  | 12.921 ns | 0.3500 ns | 0.5130 ns | 12.877 ns |  0.74 |    0.03 |         - |          NA |
| RaiqubParse       | 1000  | 11.739 ns | 0.0759 ns | 0.1039 ns | 11.698 ns |  0.67 |    0.01 |         - |          NA |
|                   |       |           |           |           |           |       |         |           |             |
| **BuiltInParse**      | **Manwe** | **25.912 ns** | **0.0853 ns** | **0.1196 ns** | **25.919 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Manwe | 15.073 ns | 0.1319 ns | 0.1760 ns | 15.094 ns |  0.58 |    0.01 |         - |          NA |
| EnumsNetParse     | Manwe | 22.680 ns | 0.3163 ns | 0.4536 ns | 22.935 ns |  0.88 |    0.02 |         - |          NA |
| NetEscapadesParse | Manwe |  4.153 ns | 0.0801 ns | 0.1199 ns |  4.152 ns |  0.16 |    0.00 |         - |          NA |
| RaiqubParse       | Manwe | 15.512 ns | 0.0971 ns | 0.1361 ns | 15.470 ns |  0.60 |    0.01 |         - |          NA |
|                   |       |           |           |           |           |       |         |           |             |
| **BuiltInParse**      | **Orome** | **47.739 ns** | **0.3490 ns** | **0.5116 ns** | **47.641 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Orome | 15.363 ns | 0.2900 ns | 0.3970 ns | 15.662 ns |  0.32 |    0.01 |         - |          NA |
| EnumsNetParse     | Orome | 22.730 ns | 0.1685 ns | 0.2522 ns | 22.760 ns |  0.48 |    0.01 |         - |          NA |
| NetEscapadesParse | Orome |  4.248 ns | 0.0824 ns | 0.1233 ns |  4.249 ns |  0.09 |    0.00 |         - |          NA |
| RaiqubParse       | Orome | 15.741 ns | 0.0944 ns | 0.1413 ns | 15.725 ns |  0.33 |    0.00 |         - |          NA |
