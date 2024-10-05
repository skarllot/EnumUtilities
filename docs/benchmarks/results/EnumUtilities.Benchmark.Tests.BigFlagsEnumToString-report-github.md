```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.402
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Permissions          | Mean          | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |--------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 |    **17.2593 ns** |  **0.3407 ns** |  **0.5099 ns** |  **1.00** |    **0.04** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |     1.7702 ns |  0.0492 ns |  0.0706 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |    10.5740 ns |  0.1066 ns |  0.1563 ns |  0.61 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |     0.8001 ns |  0.0039 ns |  0.0051 ns |  0.05 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |     4.9577 ns |  0.0756 ns |  0.1108 ns |  0.29 |    0.01 |      - |         - |        0.00 |
|                      |                      |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **Read, Write**          |    **55.4430 ns** |  **0.8516 ns** |  **1.2747 ns** |  **1.00** |    **0.03** | **0.0172** |      **72 B** |        **1.00** |
| FastEnumToString     | Read, Write          |     3.3126 ns |  0.0225 ns |  0.0316 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read, Write          |    58.5024 ns |  3.0842 ns |  4.5208 ns |  1.06 |    0.08 | 0.0362 |     152 B |        2.11 |
| NetEscapadesToString | Read, Write          |    56.2647 ns |  1.0976 ns |  1.5742 ns |  1.02 |    0.04 | 0.0172 |      72 B |        1.00 |
| RaiqubToString       | Read, Write          |    31.6271 ns |  0.6482 ns |  0.9296 ns |  0.57 |    0.02 | 0.0114 |      48 B |        0.67 |
|                      |                      |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **Delet(...) Move [39]** |    **82.8045 ns** |  **2.6419 ns** |  **3.7889 ns** |  **1.00** |    **0.06** | **0.0305** |     **128 B** |        **1.00** |
| FastEnumToString     | Delet(...) Move [39] |    13.0036 ns |  0.4357 ns |  0.6521 ns |  0.16 |    0.01 | 0.0076 |      32 B |        0.25 |
| EnumsNetAsString     | Delet(...) Move [39] |   198.2103 ns |  4.7635 ns |  6.9823 ns |  2.40 |    0.14 | 0.1070 |     448 B |        3.50 |
| NetEscapadesToString | Delet(...) Move [39] |    85.9893 ns |  3.3565 ns |  5.0239 ns |  1.04 |    0.08 | 0.0305 |     128 B |        1.00 |
| RaiqubToString       | Delet(...) Move [39] |    76.1145 ns |  1.5380 ns |  2.3021 ns |  0.92 |    0.05 | 0.0248 |     104 B |        0.81 |
|                      |                      |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **Restore**              |    **32.2675 ns** |  **0.4772 ns** |  **0.6994 ns** |  **1.00** |    **0.03** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Restore              |    10.2098 ns |  0.1173 ns |  0.1719 ns |  0.32 |    0.01 |      - |         - |        0.00 |
| EnumsNetAsString     | Restore              |    17.9018 ns |  0.1835 ns |  0.2512 ns |  0.56 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | Restore              |     0.8126 ns |  0.0189 ns |  0.0270 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Restore              |     5.2184 ns |  0.0564 ns |  0.0809 ns |  0.16 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |            |            |       |         |        |           |             |
| **BuiltInToString**      | **Read(...)lock [245]**  |   **288.4096 ns** | **26.7059 ns** | **39.1452 ns** |  **1.02** |    **0.19** | **0.1278** |     **536 B** |        **1.00** |
| FastEnumToString     | Read(...)lock [245]  |    17.0172 ns |  0.4273 ns |  0.6395 ns |  0.06 |    0.01 | 0.0115 |      48 B |        0.09 |
| EnumsNetAsString     | Read(...)lock [245]  | 1,207.0975 ns | 24.4600 ns | 36.6106 ns |  4.26 |    0.58 | 0.3300 |    1384 B |        2.58 |
| NetEscapadesToString | Read(...)lock [245]  |   306.6514 ns | 20.0956 ns | 30.0781 ns |  1.08 |    0.18 | 0.1278 |     536 B |        1.00 |
| RaiqubToString       | Read(...)lock [245]  |   377.5769 ns | 14.0736 ns | 20.6289 ns |  1.33 |    0.19 | 0.1221 |     512 B |        0.96 |
