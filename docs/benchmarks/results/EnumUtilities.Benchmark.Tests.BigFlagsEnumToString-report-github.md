```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]   : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=ShortRun  Arguments=Default  NuGetReferences=Default  
IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method               | Permissions          | Mean          | Error      | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |--------------------- |--------------:|-----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **BuiltInToString**      | **None**                 |    **16.8544 ns** |  **1.8936 ns** | **0.1038 ns** |  **1.00** |    **0.01** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | None                 |     1.7076 ns |  0.1706 ns | 0.0093 ns |  0.10 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | None                 |    10.8865 ns |  0.4560 ns | 0.0250 ns |  0.65 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | None                 |     0.7937 ns |  0.2712 ns | 0.0149 ns |  0.05 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | None                 |     2.8528 ns |  0.0962 ns | 0.0053 ns |  0.17 |    0.00 |      - |         - |        0.00 |
|                      |                      |               |            |           |       |         |        |           |             |
| **BuiltInToString**      | **Read**                 |    **47.2297 ns** |  **2.9597 ns** | **0.1622 ns** |  **1.00** |    **0.00** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Read                 |     1.6926 ns |  0.0082 ns | 0.0004 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read                 |    10.5495 ns |  0.2322 ns | 0.0127 ns |  0.22 |    0.00 |      - |         - |        0.00 |
| NetEscapadesToString | Read                 |     0.7875 ns |  0.3875 ns | 0.0212 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Read                 |    13.1209 ns |  5.9053 ns | 0.3237 ns |  0.28 |    0.01 |      - |         - |        0.00 |
|                      |                      |               |            |           |       |         |        |           |             |
| **BuiltInToString**      | **Write**                |    **43.9242 ns** | **33.4211 ns** | **1.8319 ns** |  **1.00** |    **0.05** | **0.0057** |      **24 B** |        **1.00** |
| FastEnumToString     | Write                |     1.6789 ns |  0.0081 ns | 0.0004 ns |  0.04 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Write                |    10.4479 ns |  0.4290 ns | 0.0235 ns |  0.24 |    0.01 |      - |         - |        0.00 |
| NetEscapadesToString | Write                |     0.7786 ns |  0.0285 ns | 0.0016 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| RaiqubToString       | Write                |    11.8897 ns |  9.2146 ns | 0.5051 ns |  0.27 |    0.01 |      - |         - |        0.00 |
|                      |                      |               |            |           |       |         |        |           |             |
| **BuiltInToString**      | **Read, Write**          |    **52.8468 ns** |  **5.5096 ns** | **0.3020 ns** |  **1.00** |    **0.01** | **0.0172** |      **72 B** |        **1.00** |
| FastEnumToString     | Read, Write          |     3.2021 ns |  0.0782 ns | 0.0043 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| EnumsNetAsString     | Read, Write          |    60.1827 ns | 95.6046 ns | 5.2404 ns |  1.14 |    0.09 | 0.0362 |     152 B |        2.11 |
| NetEscapadesToString | Read, Write          |    53.8442 ns |  2.7113 ns | 0.1486 ns |  1.02 |    0.01 | 0.0172 |      72 B |        1.00 |
| RaiqubToString       | Read, Write          |    36.9615 ns | 18.0552 ns | 0.9897 ns |  0.70 |    0.02 | 0.0114 |      48 B |        0.67 |
|                      |                      |               |            |           |       |         |        |           |             |
| **BuiltInToString**      | **Delet(...) Move [39]** |    **77.3492 ns** | **69.4074 ns** | **3.8045 ns** |  **1.00** |    **0.06** | **0.0305** |     **128 B** |        **1.00** |
| FastEnumToString     | Delet(...) Move [39] |    12.1657 ns |  3.7689 ns | 0.2066 ns |  0.16 |    0.01 | 0.0076 |      32 B |        0.25 |
| EnumsNetAsString     | Delet(...) Move [39] |   186.0545 ns | 34.7467 ns | 1.9046 ns |  2.41 |    0.10 | 0.1070 |     448 B |        3.50 |
| NetEscapadesToString | Delet(...) Move [39] |    77.6757 ns |  6.6191 ns | 0.3628 ns |  1.01 |    0.04 | 0.0305 |     128 B |        1.00 |
| RaiqubToString       | Delet(...) Move [39] |    73.4633 ns |  6.0710 ns | 0.3328 ns |  0.95 |    0.04 | 0.0248 |     104 B |        0.81 |
|                      |                      |               |            |           |       |         |        |           |             |
| **BuiltInToString**      | **Read(...)lock [245]**  |   **316.3875 ns** | **27.2744 ns** | **1.4950 ns** |  **1.00** |    **0.01** | **0.1278** |     **536 B** |        **1.00** |
| FastEnumToString     | Read(...)lock [245]  |    16.0299 ns |  1.6426 ns | 0.0900 ns |  0.05 |    0.00 | 0.0115 |      48 B |        0.09 |
| EnumsNetAsString     | Read(...)lock [245]  | 1,117.8888 ns | 62.0284 ns | 3.4000 ns |  3.53 |    0.02 | 0.3300 |    1384 B |        2.58 |
| NetEscapadesToString | Read(...)lock [245]  |   280.6901 ns | 16.8232 ns | 0.9221 ns |  0.89 |    0.00 | 0.1278 |     536 B |        1.00 |
| RaiqubToString       | Read(...)lock [245]  |   375.6710 ns | 96.8803 ns | 5.3103 ns |  1.19 |    0.02 | 0.1221 |     512 B |        0.96 |
