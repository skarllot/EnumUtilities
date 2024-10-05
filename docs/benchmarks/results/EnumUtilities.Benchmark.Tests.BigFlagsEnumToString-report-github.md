```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.402
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Permissions          | Mean          | Error      | StdDev     | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |--------------:|-----------:|-----------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 |    **17.4106 ns** |  **0.5216 ns** |  **0.7807 ns** |    **17.2003 ns** |  **1.00** |    **0.06** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |     1.7633 ns |  0.0314 ns |  0.0461 ns |     1.7427 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |    10.7569 ns |  0.1239 ns |  0.1816 ns |    10.8469 ns |  0.62 |    0.03 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |     0.8065 ns |  0.0080 ns |  0.0109 ns |     0.8033 ns |  0.05 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |     4.9437 ns |  0.0668 ns |  0.0936 ns |     4.8902 ns |  0.28 |    0.01 |      - |         - |        0.00 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Read, Write**          |    **54.7734 ns** |  **0.5244 ns** |  **0.7849 ns** |    **54.8739 ns** |  **1.00** |    **0.02** | **0.0172** |      **72 B** |        **1.00** |
| FastEnumToString     | Read, Write          |     3.3109 ns |  0.0182 ns |  0.0249 ns |     3.3064 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read, Write          |    60.5186 ns |  0.6323 ns |  0.8864 ns |    60.3551 ns |  1.11 |    0.02 | 0.0362 |     152 B |        2.11 |
| NetEscapadesToString | Read, Write          |    59.1108 ns |  0.9027 ns |  1.2655 ns |    59.0186 ns |  1.08 |    0.03 | 0.0172 |      72 B |        1.00 |
| RaiqubToString       | Read, Write          |    32.8484 ns |  0.4131 ns |  0.6055 ns |    32.6146 ns |  0.60 |    0.01 | 0.0114 |      48 B |        0.67 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Delet(...) Move [39]** |    **79.4866 ns** |  **0.9360 ns** |  **1.3719 ns** |    **79.3398 ns** |  **1.00** |    **0.02** | **0.0305** |     **128 B** |        **1.00** |
| FastEnumToString     | Delet(...) Move [39] |    12.5736 ns |  0.2004 ns |  0.2676 ns |    12.5551 ns |  0.16 |    0.00 | 0.0076 |      32 B |        0.25 |
| EnumsNetAsString     | Delet(...) Move [39] |   192.3880 ns |  1.7609 ns |  2.4104 ns |   192.2929 ns |  2.42 |    0.05 | 0.1070 |     448 B |        3.50 |
| NetEscapadesToString | Delet(...) Move [39] |    79.8912 ns |  2.4930 ns |  3.5754 ns |    80.3421 ns |  1.01 |    0.05 | 0.0305 |     128 B |        1.00 |
| RaiqubToString       | Delet(...) Move [39] |    72.0406 ns |  3.3867 ns |  5.0690 ns |    73.7853 ns |  0.91 |    0.06 | 0.0248 |     104 B |        0.81 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Restore**              |    **31.8871 ns** |  **0.2496 ns** |  **0.3499 ns** |    **31.9096 ns** |  **1.00** |    **0.02** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Restore              |    10.1447 ns |  0.0447 ns |  0.0641 ns |    10.1164 ns |  0.32 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Restore              |    17.8343 ns |  0.1750 ns |  0.2396 ns |    17.8997 ns |  0.56 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | Restore              |     0.8086 ns |  0.0115 ns |  0.0165 ns |     0.8011 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Restore              |     5.2155 ns |  0.0503 ns |  0.0688 ns |     5.1904 ns |  0.16 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Read(...)lock [245]**  |   **294.0483 ns** | **19.8665 ns** | **29.7352 ns** |   **298.3516 ns** |  **1.01** |    **0.14** | **0.1278** |     **536 B** |        **1.00** |
| FastEnumToString     | Read(...)lock [245]  |    16.9184 ns |  0.3611 ns |  0.5405 ns |    16.7432 ns |  0.06 |    0.01 | 0.0115 |      48 B |        0.09 |
| EnumsNetAsString     | Read(...)lock [245]  | 1,214.1650 ns | 16.6086 ns | 23.8195 ns | 1,214.4279 ns |  4.17 |    0.43 | 0.3300 |    1384 B |        2.58 |
| NetEscapadesToString | Read(...)lock [245]  |   315.3307 ns | 17.9389 ns | 26.8501 ns |   321.4061 ns |  1.08 |    0.14 | 0.1278 |     536 B |        1.00 |
| RaiqubToString       | Read(...)lock [245]  |   394.1485 ns |  3.4109 ns |  5.1053 ns |   394.7210 ns |  1.35 |    0.14 | 0.1221 |     512 B |        0.96 |
