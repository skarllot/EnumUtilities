```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method               | Permissions          | Mean          | Error       | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |--------------:|------------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 |    **16.7930 ns** |   **0.7112 ns** |  **0.0390 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |     1.7954 ns |   0.3401 ns |  0.0186 ns |  0.11 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |    10.8834 ns |   3.5318 ns |  0.1936 ns |  0.65 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |     0.7893 ns |   0.0995 ns |  0.0055 ns |  0.05 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |     4.6455 ns |   2.2042 ns |  0.1208 ns |  0.28 |    0.01 |      - |         - |        0.00 |
|                      |                      |               |             |            |       |         |        |           |             |
| **BuiltInToString**      | **Read**                 |    **46.2530 ns** |   **0.7443 ns** |  **0.0408 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Read                 |     1.8036 ns |   0.2011 ns |  0.0110 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read                 |    10.8982 ns |   1.0707 ns |  0.0587 ns |  0.24 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Read                 |     0.7790 ns |   0.0379 ns |  0.0021 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Read                 |     4.4785 ns |   0.0320 ns |  0.0018 ns |  0.10 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |             |            |       |         |        |           |             |
| **BuiltInToString**      | **Write**                |    **43.3199 ns** |  **15.7660 ns** |  **0.8642 ns** |  **1.00** |    **0.02** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Write                |     1.7683 ns |   0.2705 ns |  0.0148 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Write                |    10.5087 ns |   1.0713 ns |  0.0587 ns |  0.24 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Write                |     0.7793 ns |   0.0761 ns |  0.0042 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Write                |     4.5957 ns |   0.6882 ns |  0.0377 ns |  0.11 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |             |            |       |         |        |           |             |
| **BuiltInToString**      | **Read, Write**          |    **52.8651 ns** |   **8.5595 ns** |  **0.4692 ns** |  **1.00** |    **0.01** | **0.0172** |      **72 B** |        **1.00** |
| FastEnumToString     | Read, Write          |     3.2042 ns |   0.0306 ns |  0.0017 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read, Write          |    53.1715 ns |   4.8580 ns |  0.2663 ns |  1.01 |    0.01 | 0.0363 |     152 B |        2.11 |
| NetEscapadesToString | Read, Write          |    53.9850 ns |   2.5190 ns |  0.1381 ns |  1.02 |    0.01 | 0.0172 |      72 B |        1.00 |
| RaiqubToString       | Read, Write          |    38.0268 ns |   4.7252 ns |  0.2590 ns |  0.72 |    0.01 | 0.0114 |      48 B |        0.67 |
|                      |                      |               |             |            |       |         |        |           |             |
| **BuiltInToString**      | **Delet(...) Move [39]** |    **75.1718 ns** |   **4.2637 ns** |  **0.2337 ns** |  **1.00** |    **0.00** | **0.0305** |     **128 B** |        **1.00** |
| FastEnumToString     | Delet(...) Move [39] |    12.1982 ns |   2.1203 ns |  0.1162 ns |  0.16 |    0.00 | 0.0076 |      32 B |        0.25 |
| EnumsNetAsString     | Delet(...) Move [39] |   192.5542 ns |  34.6929 ns |  1.9016 ns |  2.56 |    0.02 | 0.1070 |     448 B |        3.50 |
| NetEscapadesToString | Delet(...) Move [39] |    79.9217 ns |   9.4581 ns |  0.5184 ns |  1.06 |    0.01 | 0.0305 |     128 B |        1.00 |
| RaiqubToString       | Delet(...) Move [39] |    75.3040 ns |   4.6654 ns |  0.2557 ns |  1.00 |    0.00 | 0.0248 |     104 B |        0.81 |
|                      |                      |               |             |            |       |         |        |           |             |
| **BuiltInToString**      | **Read(...)lock [245]**  |   **286.7287 ns** | **531.0970 ns** | **29.1112 ns** |  **1.01** |    **0.13** | **0.1278** |     **536 B** |        **1.00** |
| FastEnumToString     | Read(...)lock [245]  |    16.4008 ns |   1.4773 ns |  0.0810 ns |  0.06 |    0.01 | 0.0115 |      48 B |        0.09 |
| EnumsNetAsString     | Read(...)lock [245]  | 1,133.2051 ns | 166.8450 ns |  9.1453 ns |  3.98 |    0.37 | 0.3300 |    1384 B |        2.58 |
| NetEscapadesToString | Read(...)lock [245]  |   318.8403 ns |  59.5440 ns |  3.2638 ns |  1.12 |    0.10 | 0.1278 |     536 B |        1.00 |
| RaiqubToString       | Read(...)lock [245]  |   428.1725 ns |  37.8223 ns |  2.0732 ns |  1.50 |    0.14 | 0.1221 |     512 B |        0.96 |
