```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.401
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  Arguments=Default  NuGetReferences=Default  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method                 | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |----------:|---------:|---------:|-------:|----------:|
| UninitializedString    |  15.88 ns | 0.102 ns | 0.153 ns | 0.0536 |     224 B |
| ZeroedString           |  16.25 ns | 0.077 ns | 0.111 ns | 0.0536 |     224 B |
| MemoryMarshalReference | 381.08 ns | 2.460 ns | 3.448 ns | 0.9999 |    4184 B |
| UnsafePointer          | 381.22 ns | 1.040 ns | 1.492 ns | 0.9999 |    4184 B |
