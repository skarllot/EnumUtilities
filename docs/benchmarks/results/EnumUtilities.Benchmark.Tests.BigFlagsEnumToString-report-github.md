```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Permissions          | Mean          | Error      | StdDev     | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |--------------:|-----------:|-----------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 |    **17.0825 ns** |  **0.1186 ns** |  **0.1701 ns** |    **17.0446 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |     1.7617 ns |  0.0323 ns |  0.0484 ns |     1.7369 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |    10.7434 ns |  0.1993 ns |  0.2858 ns |    10.7203 ns |  0.63 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |     0.8010 ns |  0.0124 ns |  0.0186 ns |     0.7950 ns |  0.05 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |     2.9777 ns |  0.1464 ns |  0.1955 ns |     3.0033 ns |  0.17 |    0.01 |      - |         - |        0.00 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Read, Write**          |    **58.5790 ns** |  **1.9052 ns** |  **2.6709 ns** |    **57.9456 ns** |  **1.00** |    **0.06** | **0.0172** |      **72 B** |        **1.00** |
| FastEnumToString     | Read, Write          |     3.2827 ns |  0.0192 ns |  0.0269 ns |     3.2853 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read, Write          |    57.9687 ns |  2.7913 ns |  3.9129 ns |    59.9967 ns |  0.99 |    0.08 | 0.0363 |     152 B |        2.11 |
| NetEscapadesToString | Read, Write          |    55.5968 ns |  0.3657 ns |  0.5244 ns |    55.6160 ns |  0.95 |    0.04 | 0.0172 |      72 B |        1.00 |
| RaiqubToString       | Read, Write          |    61.3939 ns |  0.9887 ns |  1.4492 ns |    62.1877 ns |  1.05 |    0.05 | 0.0114 |      48 B |        0.67 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Delet(...) Move [39]** |    **79.5070 ns** |  **1.3201 ns** |  **1.9759 ns** |    **79.4931 ns** |  **1.00** |    **0.03** | **0.0305** |     **128 B** |        **1.00** |
| FastEnumToString     | Delet(...) Move [39] |    12.4220 ns |  0.0897 ns |  0.1342 ns |    12.3995 ns |  0.16 |    0.00 | 0.0076 |      32 B |        0.25 |
| EnumsNetAsString     | Delet(...) Move [39] |   196.7291 ns |  1.2384 ns |  1.7361 ns |   196.6094 ns |  2.48 |    0.06 | 0.1070 |     448 B |        3.50 |
| NetEscapadesToString | Delet(...) Move [39] |    84.1504 ns |  3.0080 ns |  4.3140 ns |    84.2139 ns |  1.06 |    0.06 | 0.0305 |     128 B |        1.00 |
| RaiqubToString       | Delet(...) Move [39] |    91.8250 ns |  1.4927 ns |  2.1408 ns |    91.0759 ns |  1.16 |    0.04 | 0.0248 |     104 B |        0.81 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Restore**              |    **32.4466 ns** |  **0.7358 ns** |  **1.0315 ns** |    **31.8414 ns** |  **1.00** |    **0.04** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Restore              |    10.1379 ns |  0.0242 ns |  0.0355 ns |    10.1260 ns |  0.31 |    0.01 |      - |         - |        0.00 |
| EnumsNetAsString     | Restore              |    17.7987 ns |  0.0904 ns |  0.1326 ns |    17.7913 ns |  0.55 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | Restore              |     0.8077 ns |  0.0130 ns |  0.0186 ns |     0.7997 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Restore              |     3.3233 ns |  0.0095 ns |  0.0142 ns |     3.3206 ns |  0.10 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Read(...)lock [245]**  |   **306.9798 ns** | **17.4324 ns** | **26.0920 ns** |   **316.6347 ns** |  **1.01** |    **0.12** | **0.1278** |     **536 B** |        **1.00** |
| FastEnumToString     | Read(...)lock [245]  |    16.6925 ns |  0.1274 ns |  0.1868 ns |    16.6707 ns |  0.05 |    0.00 | 0.0115 |      48 B |        0.09 |
| EnumsNetAsString     | Read(...)lock [245]  | 1,180.6292 ns | 12.6110 ns | 18.8756 ns | 1,183.2062 ns |  3.87 |    0.35 | 0.3300 |    1384 B |        2.58 |
| NetEscapadesToString | Read(...)lock [245]  |   276.8813 ns |  7.8420 ns | 11.7375 ns |   276.9892 ns |  0.91 |    0.09 | 0.1278 |     536 B |        1.00 |
| RaiqubToString       | Read(...)lock [245]  |   322.5277 ns |  2.0600 ns |  3.0834 ns |   322.4441 ns |  1.06 |    0.09 | 0.1221 |     512 B |        0.96 |
