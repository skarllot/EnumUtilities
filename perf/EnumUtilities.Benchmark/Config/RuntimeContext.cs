using System.Reflection;

namespace EnumUtilities.Benchmark.Config;

internal static class RuntimeContext
{
    public static string SolutionDirectory { get; } = ResolveSolutionDirectory();

    private static string ResolveSolutionDirectory()
    {
        var assemblyFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
        for (var currDir = assemblyFolder; currDir != null; currDir = currDir.Parent)
        {
            if (!currDir.EnumerateFiles("*.sln", SearchOption.TopDirectoryOnly).Any())
                continue;

            return currDir.FullName;
        }

        return string.Empty;
    }
}
