```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8246/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 1600 3.20GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.203
  [Host]    : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
  MediumRun : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method               | Permissions          | Mean          | Error      | StdDev     | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |--------------:|-----------:|-----------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 |    **17.4874 ns** |  **0.0998 ns** |  **0.1366 ns** |    **17.4121 ns** | **1.000** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |     1.4744 ns |  0.0868 ns |  0.1299 ns |     1.4988 ns | 0.084 |    0.01 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |     5.5647 ns |  0.2225 ns |  0.3119 ns |     5.4315 ns | 0.318 |    0.02 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |     1.1471 ns |  0.1974 ns |  0.2894 ns |     0.8762 ns | 0.066 |    0.02 |      - |         - |        0.00 |
| RaiqubToString       | None                 |     0.0332 ns |  0.0012 ns |  0.0017 ns |     0.0341 ns | 0.002 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Read, Write**          |    **46.7411 ns** |  **0.2301 ns** |  **0.3300 ns** |    **46.7614 ns** |  **1.00** |    **0.01** | **0.0172** |      **72 B** |        **1.00** |
| FastEnumToString     | Read, Write          |     2.2687 ns |  0.0045 ns |  0.0065 ns |     2.2678 ns |  0.05 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read, Write          |    47.7228 ns |  0.0789 ns |  0.1156 ns |    47.6890 ns |  1.02 |    0.01 | 0.0363 |     152 B |        2.11 |
| NetEscapadesToString | Read, Write          |    48.1987 ns |  0.0930 ns |  0.1363 ns |    48.1500 ns |  1.03 |    0.01 | 0.0172 |      72 B |        1.00 |
| RaiqubToString       | Read, Write          |    31.1593 ns |  0.0223 ns |  0.0305 ns |    31.1624 ns |  0.67 |    0.00 | 0.0114 |      48 B |        0.67 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Delet(...) Move [39]** |    **73.0326 ns** |  **0.3251 ns** |  **0.4866 ns** |    **72.9973 ns** |  **1.00** |    **0.01** | **0.0305** |     **128 B** |        **1.00** |
| FastEnumToString     | Delet(...) Move [39] |     8.7676 ns |  0.0338 ns |  0.0463 ns |     8.7739 ns |  0.12 |    0.00 | 0.0076 |      32 B |        0.25 |
| EnumsNetAsString     | Delet(...) Move [39] |   206.9221 ns |  2.0908 ns |  3.0647 ns |   208.4672 ns |  2.83 |    0.05 | 0.1070 |     448 B |        3.50 |
| NetEscapadesToString | Delet(...) Move [39] |    74.6500 ns |  0.2434 ns |  0.3568 ns |    74.6921 ns |  1.02 |    0.01 | 0.0305 |     128 B |        1.00 |
| RaiqubToString       | Delet(...) Move [39] |    61.4850 ns |  0.4252 ns |  0.6099 ns |    61.7614 ns |  0.84 |    0.01 | 0.0248 |     104 B |        0.81 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Restore**              |    **25.3401 ns** |  **0.0445 ns** |  **0.0639 ns** |    **25.3393 ns** | **1.000** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Restore              |     8.9716 ns |  0.0613 ns |  0.0898 ns |     8.9854 ns | 0.354 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Restore              |    14.3311 ns |  0.1197 ns |  0.1754 ns |    14.4213 ns | 0.566 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | Restore              |     0.8710 ns |  0.0066 ns |  0.0097 ns |     0.8721 ns | 0.034 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Restore              |     0.0630 ns |  0.0641 ns |  0.0919 ns |     0.0397 ns | 0.002 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |            |            |               |       |         |        |           |             |
| **BuiltInToString**      | **Read(...)lock [245]**  |   **333.3677 ns** |  **7.9372 ns** | **11.8800 ns** |   **336.0245 ns** |  **1.00** |    **0.05** | **0.1278** |     **536 B** |        **1.00** |
| FastEnumToString     | Read(...)lock [245]  |    12.8933 ns |  0.0400 ns |  0.0535 ns |    12.9064 ns |  0.04 |    0.00 | 0.0115 |      48 B |        0.09 |
| EnumsNetAsString     | Read(...)lock [245]  | 1,194.8865 ns |  9.9490 ns | 14.5831 ns | 1,197.1256 ns |  3.59 |    0.15 | 0.3300 |    1384 B |        2.58 |
| NetEscapadesToString | Read(...)lock [245]  |   315.3248 ns | 12.8657 ns | 18.4515 ns |   320.0297 ns |  0.95 |    0.07 | 0.1278 |     536 B |        1.00 |
| RaiqubToString       | Read(...)lock [245]  |   253.7561 ns |  9.8678 ns | 14.7696 ns |   251.8161 ns |  0.76 |    0.05 | 0.1221 |     512 B |        0.96 |
