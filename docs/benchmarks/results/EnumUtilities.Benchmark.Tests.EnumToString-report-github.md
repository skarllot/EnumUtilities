```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Permissions | Mean          | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |------------ |--------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **0**           |    **17.9885 ns** |  **0.2584 ns** |  **0.3706 ns** |  **1.00** |    **0.03** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 0           |     1.7664 ns |  0.0487 ns |  0.0698 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 0           |    10.8160 ns |  0.1451 ns |  0.1987 ns |  0.60 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | 0           |     0.8162 ns |  0.0132 ns |  0.0190 ns |  0.05 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | 0           |     3.2260 ns |  0.0131 ns |  0.0188 ns |  0.18 |    0.00 |      - |         - |        0.00 |
|                      |             |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **1**           |    **45.6866 ns** |  **1.6088 ns** |  **2.3073 ns** |  **1.00** |    **0.07** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 1           |     1.7270 ns |  0.0043 ns |  0.0059 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 1           |    11.0496 ns |  0.1362 ns |  0.1864 ns |  0.24 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | 1           |     0.8126 ns |  0.0141 ns |  0.0188 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | 1           |    13.6650 ns |  0.2647 ns |  0.3961 ns |  0.30 |    0.02 |      - |         - |        0.00 |
|                      |             |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **2**           |    **43.1362 ns** |  **1.0502 ns** |  **1.5718 ns** |  **1.00** |    **0.05** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | 2           |     1.7543 ns |  0.0188 ns |  0.0250 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 2           |    11.0224 ns |  0.1250 ns |  0.1833 ns |  0.26 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | 2           |     0.8375 ns |  0.0369 ns |  0.0504 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | 2           |    13.3602 ns |  0.3967 ns |  0.5937 ns |  0.31 |    0.02 |      - |         - |        0.00 |
|                      |             |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **3**           |    **56.9450 ns** |  **0.9706 ns** |  **1.4528 ns** |  **1.00** |    **0.04** | **0.0172** |      **72 B** |        **1.00** |
| FastEnumToString     | 3           |     3.2996 ns |  0.0154 ns |  0.0225 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | 3           |    57.5480 ns |  0.8305 ns |  1.2173 ns |  1.01 |    0.03 | 0.0362 |     152 B |        2.11 |
| NetEscapadesToString | 3           |    56.4781 ns |  0.6930 ns |  0.9939 ns |  0.99 |    0.03 | 0.0172 |      72 B |        1.00 |
| RaiqubToString       | 3           |    53.6826 ns |  1.6481 ns |  2.4669 ns |  0.94 |    0.05 | 0.0114 |      48 B |        0.67 |
|                      |             |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **1000**        |    **86.8418 ns** |  **2.0670 ns** |  **3.0938 ns** |  **1.00** |    **0.05** | **0.0305** |     **128 B** |        **1.00** |
| FastEnumToString     | 1000        |    12.7041 ns |  0.2460 ns |  0.3681 ns |  0.15 |    0.01 | 0.0076 |      32 B |        0.25 |
| EnumsNetAsString     | 1000        |   199.7548 ns |  3.1153 ns |  4.6629 ns |  2.30 |    0.10 | 0.1070 |     448 B |        3.50 |
| NetEscapadesToString | 1000        |    86.5936 ns |  2.7366 ns |  4.0959 ns |  1.00 |    0.06 | 0.0305 |     128 B |        1.00 |
| RaiqubToString       | 1000        |   102.7282 ns |  1.0026 ns |  1.5007 ns |  1.18 |    0.04 | 0.0248 |     104 B |        0.81 |
|                      |             |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **2147483647**  |   **301.5099 ns** | **27.6005 ns** | **39.5839 ns** |  **1.02** |    **0.19** | **0.1278** |     **536 B** |        **1.00** |
| FastEnumToString     | 2147483647  |    16.8671 ns |  0.2581 ns |  0.3862 ns |  0.06 |    0.01 | 0.0115 |      48 B |        0.09 |
| EnumsNetAsString     | 2147483647  | 1,205.2430 ns | 18.2282 ns | 27.2831 ns |  4.07 |    0.53 | 0.3300 |    1384 B |        2.58 |
| NetEscapadesToString | 2147483647  |   309.5308 ns |  5.4700 ns |  8.1872 ns |  1.04 |    0.14 | 0.1278 |     536 B |        1.00 |
| RaiqubToString       | 2147483647  |   434.7517 ns |  5.0820 ns |  7.2884 ns |  1.47 |    0.19 | 0.2465 |    1032 B |        1.93 |
