using System.Reflection;
using BenchmarkDotNet.Running;
using EnumUtilities.Benchmark.Config;

BenchmarkSwitcher.FromAssembly(Assembly.GetCallingAssembly()).Run(args, new BenchmarkConfig());
