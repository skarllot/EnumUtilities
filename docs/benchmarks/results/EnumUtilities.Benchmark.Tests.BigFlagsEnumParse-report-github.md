```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method            | Permissions          | Mean         | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------ |--------------------- |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **BuiltInParse**      | **0**                    |    **13.987 ns** |  **0.0470 ns** |  **0.0674 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | 0                    |     9.442 ns |  0.0244 ns |  0.0325 ns |  0.68 |    0.00 |         - |          NA |
| EnumsNetParse     | 0                    |    47.279 ns |  1.1095 ns |  1.6607 ns |  3.38 |    0.12 |         - |          NA |
| NetEscapadesParse | 0                    |    10.073 ns |  0.0595 ns |  0.0814 ns |  0.72 |    0.01 |         - |          NA |
| RaiqubParse       | 0                    |    10.300 ns |  0.0915 ns |  0.1341 ns |  0.74 |    0.01 |         - |          NA |
|                   |                      |              |            |            |       |         |           |             |
| **BuiltInParse**      | **Delet(...) Move [39]** |   **309.194 ns** |  **1.6450 ns** |  **2.4112 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Delet(...) Move [39] |           NA |         NA |         NA |     ? |       ? |        NA |           ? |
| EnumsNetParse     | Delet(...) Move [39] |   286.000 ns |  1.6095 ns |  2.3083 ns |  0.93 |    0.01 |         - |          NA |
| NetEscapadesParse | Delet(...) Move [39] |           NA |         NA |         NA |     ? |       ? |        NA |           ? |
| RaiqubParse       | Delet(...) Move [39] |   224.670 ns |  0.7306 ns |  1.0709 ns |  0.73 |    0.01 |         - |          NA |
|                   |                      |              |            |            |       |         |           |             |
| **BuiltInParse**      | **Read, Write**          |    **63.240 ns** |  **0.3288 ns** |  **0.4819 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Read, Write          |           NA |         NA |         NA |     ? |       ? |        NA |           ? |
| EnumsNetParse     | Read, Write          |    95.609 ns |  0.7829 ns |  1.0975 ns |  1.51 |    0.02 |         - |          NA |
| NetEscapadesParse | Read, Write          |           NA |         NA |         NA |     ? |       ? |        NA |           ? |
| RaiqubParse       | Read, Write          |    55.005 ns |  0.2825 ns |  0.4052 ns |  0.87 |    0.01 |         - |          NA |
|                   |                      |              |            |            |       |         |           |             |
| **BuiltInParse**      | **Read(...)lock [245]**  | **2,783.170 ns** | **17.6501 ns** | **23.5624 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Read(...)lock [245]  |           NA |         NA |         NA |     ? |       ? |        NA |           ? |
| EnumsNetParse     | Read(...)lock [245]  | 1,659.957 ns | 19.1646 ns | 26.8661 ns |  0.60 |    0.01 |         - |          NA |
| NetEscapadesParse | Read(...)lock [245]  |           NA |         NA |         NA |     ? |       ? |        NA |           ? |
| RaiqubParse       | Read(...)lock [245]  | 1,539.143 ns |  5.4026 ns |  7.5737 ns |  0.55 |    0.01 |         - |          NA |
|                   |                      |              |            |            |       |         |           |             |
| **BuiltInParse**      | **Restore**              |    **79.891 ns** |  **0.4963 ns** |  **0.7428 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FastEnumParse     | Restore              |    16.590 ns |  0.3468 ns |  0.5083 ns |  0.21 |    0.01 |         - |          NA |
| EnumsNetParse     | Restore              |    55.787 ns |  0.5216 ns |  0.7646 ns |  0.70 |    0.01 |         - |          NA |
| NetEscapadesParse | Restore              |     3.887 ns |  0.0278 ns |  0.0399 ns |  0.05 |    0.00 |         - |          NA |
| RaiqubParse       | Restore              |    33.789 ns |  0.0832 ns |  0.1138 ns |  0.42 |    0.00 |         - |          NA |

Benchmarks with issues:
  BigFlagsEnumParse.FastEnumParse: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10) [Permissions=Delet(...) Move [39]]
  BigFlagsEnumParse.NetEscapadesParse: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10) [Permissions=Delet(...) Move [39]]
  BigFlagsEnumParse.FastEnumParse: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10) [Permissions=Read, Write]
  BigFlagsEnumParse.NetEscapadesParse: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10) [Permissions=Read, Write]
  BigFlagsEnumParse.FastEnumParse: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10) [Permissions=Read(...)lock [245]]
  BigFlagsEnumParse.NetEscapadesParse: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10) [Permissions=Read(...)lock [245]]
