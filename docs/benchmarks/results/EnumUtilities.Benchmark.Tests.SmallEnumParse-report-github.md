```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method            | Valar | Mean      | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|------------------ |------ |----------:|----------:|----------:|------:|----------:|------------:|
| **BuiltInParse**      | **0**     | **14.122 ns** | **2.3857 ns** | **0.1308 ns** |  **1.00** |         **-** |          **NA** |
| FastEnumParse     | 0     | 10.010 ns | 0.6469 ns | 0.0355 ns |  0.71 |         - |          NA |
| EnumsNetParse     | 0     | 12.323 ns | 1.5154 ns | 0.0831 ns |  0.87 |         - |          NA |
| NetEscapadesParse | 0     |  9.413 ns | 2.8606 ns | 0.1568 ns |  0.67 |         - |          NA |
| RaiqubParse       | 0     |  9.779 ns | 1.1236 ns | 0.0616 ns |  0.69 |         - |          NA |
|                   |       |           |           |           |       |           |             |
| **BuiltInParse**      | **1000**  | **17.393 ns** | **0.3123 ns** | **0.0171 ns** |  **1.00** |         **-** |          **NA** |
| FastEnumParse     | 1000  | 14.738 ns | 0.6141 ns | 0.0337 ns |  0.85 |         - |          NA |
| EnumsNetParse     | 1000  | 15.128 ns | 0.6087 ns | 0.0334 ns |  0.87 |         - |          NA |
| NetEscapadesParse | 1000  | 12.854 ns | 3.4578 ns | 0.1895 ns |  0.74 |         - |          NA |
| RaiqubParse       | 1000  | 15.624 ns | 4.0917 ns | 0.2243 ns |  0.90 |         - |          NA |
|                   |       |           |           |           |       |           |             |
| **BuiltInParse**      | **Manwe** | **25.925 ns** | **0.9777 ns** | **0.0536 ns** |  **1.00** |         **-** |          **NA** |
| FastEnumParse     | Manwe | 15.276 ns | 1.3099 ns | 0.0718 ns |  0.59 |         - |          NA |
| EnumsNetParse     | Manwe | 22.084 ns | 0.8068 ns | 0.0442 ns |  0.85 |         - |          NA |
| NetEscapadesParse | Manwe |  4.162 ns | 0.7835 ns | 0.0429 ns |  0.16 |         - |          NA |
| RaiqubParse       | Manwe | 18.059 ns | 1.1906 ns | 0.0653 ns |  0.70 |         - |          NA |
|                   |       |           |           |           |       |           |             |
| **BuiltInParse**      | **Orome** | **47.359 ns** | **1.3685 ns** | **0.0750 ns** |  **1.00** |         **-** |          **NA** |
| FastEnumParse     | Orome | 20.924 ns | 0.4447 ns | 0.0244 ns |  0.44 |         - |          NA |
| EnumsNetParse     | Orome | 22.342 ns | 0.3720 ns | 0.0204 ns |  0.47 |         - |          NA |
| NetEscapadesParse | Orome |  4.236 ns | 0.7567 ns | 0.0415 ns |  0.09 |         - |          NA |
| RaiqubParse       | Orome | 17.905 ns | 0.9680 ns | 0.0531 ns |  0.38 |         - |          NA |
