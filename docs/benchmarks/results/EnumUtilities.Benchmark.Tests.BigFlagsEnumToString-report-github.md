```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Permissions          | Mean          | Error      | StdDev     | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |--------------:|-----------:|-----------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 |    **16.4999 ns** |  **0.0522 ns** |  **0.0715 ns** |    **16.4946 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |     1.6975 ns |  0.0113 ns |  0.0155 ns |     1.6955 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |    10.7721 ns |  0.1020 ns |  0.1495 ns |    10.6886 ns |  0.65 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |     0.7754 ns |  0.0014 ns |  0.0020 ns |     0.7751 ns |  0.05 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |     4.4775 ns |  0.0013 ns |  0.0017 ns |     4.4774 ns |  0.27 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Read, Write**          |    **52.5030 ns** |  **0.1326 ns** |  **0.1943 ns** |    **52.5300 ns** |  **1.00** |    **0.01** | **0.0172** |      **72 B** |        **1.00** |
| FastEnumToString     | Read, Write          |     3.2075 ns |  0.0032 ns |  0.0044 ns |     3.2070 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read, Write          |    53.0620 ns |  0.1707 ns |  0.2502 ns |    53.0074 ns |  1.01 |    0.01 | 0.0363 |     152 B |        2.11 |
| NetEscapadesToString | Read, Write          |    53.6865 ns |  0.0786 ns |  0.1101 ns |    53.6552 ns |  1.02 |    0.00 | 0.0172 |      72 B |        1.00 |
| RaiqubToString       | Read, Write          |    38.0080 ns |  0.1308 ns |  0.1833 ns |    38.0348 ns |  0.72 |    0.00 | 0.0114 |      48 B |        0.67 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Delet(...) Move [39]** |    **75.0257 ns** |  **0.1500 ns** |  **0.2054 ns** |    **75.0500 ns** |  **1.00** |    **0.00** | **0.0305** |     **128 B** |        **1.00** |
| FastEnumToString     | Delet(...) Move [39] |    12.0186 ns |  0.0911 ns |  0.1307 ns |    11.9645 ns |  0.16 |    0.00 | 0.0076 |      32 B |        0.25 |
| EnumsNetAsString     | Delet(...) Move [39] |   186.0024 ns |  0.4894 ns |  0.7174 ns |   185.9563 ns |  2.48 |    0.01 | 0.1070 |     448 B |        3.50 |
| NetEscapadesToString | Delet(...) Move [39] |    76.6881 ns |  0.1157 ns |  0.1544 ns |    76.7316 ns |  1.02 |    0.00 | 0.0305 |     128 B |        1.00 |
| RaiqubToString       | Delet(...) Move [39] |    78.3768 ns |  1.8230 ns |  2.6145 ns |    78.4079 ns |  1.04 |    0.03 | 0.0248 |     104 B |        0.81 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Restore**              |    **30.6747 ns** |  **0.0659 ns** |  **0.0944 ns** |    **30.6469 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Restore              |     9.8331 ns |  0.0111 ns |  0.0163 ns |     9.8314 ns |  0.32 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Restore              |    17.4299 ns |  0.0467 ns |  0.0700 ns |    17.4364 ns |  0.57 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Restore              |     0.7765 ns |  0.0012 ns |  0.0017 ns |     0.7763 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Restore              |     4.7497 ns |  0.0023 ns |  0.0031 ns |     4.7493 ns |  0.15 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Read(...)lock [245]**  |   **259.5235 ns** | **15.0375 ns** | **20.5835 ns** |   **259.0623 ns** |  **1.01** |    **0.11** | **0.1278** |     **536 B** |        **1.00** |
| FastEnumToString     | Read(...)lock [245]  |    15.9837 ns |  0.0417 ns |  0.0599 ns |    15.9793 ns |  0.06 |    0.00 | 0.0115 |      48 B |        0.09 |
| EnumsNetAsString     | Read(...)lock [245]  | 1,171.7462 ns | 13.8742 ns | 20.7662 ns | 1,172.9332 ns |  4.54 |    0.36 | 0.3300 |    1384 B |        2.58 |
| NetEscapadesToString | Read(...)lock [245]  |   295.2265 ns | 11.6814 ns | 17.4842 ns |   291.0205 ns |  1.14 |    0.11 | 0.1278 |     536 B |        1.00 |
| RaiqubToString       | Read(...)lock [245]  |   430.8055 ns |  5.0748 ns |  7.5957 ns |   430.4574 ns |  1.67 |    0.13 | 0.1221 |     512 B |        0.96 |
