using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace EnumUtilities.Benchmark.Config;

public class BenchmarkConfig : ManualConfig
{
    private readonly IConfig _defaultConfig = DefaultConfig.Instance;

    public BenchmarkConfig()
    {
        AddColumnProvider(DefaultColumnProviders.Instance)
            .AddExporter(MarkdownExporter.GitHub)
            .AddLogger(ConsoleLogger.Default)
            .AddAnalyser(_defaultConfig.GetAnalysers().ToArray())
            .AddValidator(_defaultConfig.GetValidators().ToArray())
            .WithSummaryStyle(_defaultConfig.SummaryStyle)
            .WithOption(ConfigOptions.DisableLogFile, true)
            .WithArtifactsPath(Path.Combine(RuntimeContext.SolutionDirectory, "docs", "benchmarks"));

        AddJob(Job.MediumRun);

        HideColumns(Column.Arguments, Column.NuGetReferences);
    }
}
