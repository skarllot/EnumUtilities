```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method                      | Mean     | Error     | StdDev    | Allocated |
|---------------------------- |---------:|----------:|----------:|----------:|
| WithSequenceEqual           | 1.334 ns | 0.0204 ns | 0.0305 ns |         - |
| WithIsExpression            | 1.311 ns | 0.0057 ns | 0.0081 ns |         - |
| WithEqualsOrdinal           | 1.310 ns | 0.0047 ns | 0.0065 ns |         - |
| WithEqualsOrdinalIgnoreCase | 1.327 ns | 0.0180 ns | 0.0264 ns |         - |
