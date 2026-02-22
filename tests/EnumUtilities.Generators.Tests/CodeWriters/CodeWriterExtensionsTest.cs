using Raiqub.Generators.EnumUtilities.CodeWriters;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.CodeWriters;

public class CodeWriterExtensionsTest
{
    [Fact]
    public void WriteNamespaceImports_NoModulesNoDefaults_WritesNothing()
    {
        var writer = new SourceTextWriter();

        writer.WriteNamespaceImports(Array.Empty<ICodeWriterModule<int>>(), 0);

        Assert.Equal(string.Empty, writer.ToString());
    }

    [Fact]
    public void WriteNamespaceImports_WithDefaultImportsOnly_WritesDefaultImports()
    {
        var writer = new SourceTextWriter();
        string[] defaults = ["System", "Raiqub.Stuff"];

        writer.WriteNamespaceImports(Array.Empty<ICodeWriterModule<int>>(), 0, defaultImports: defaults);

        Assert.Equal(["using System;", "using Raiqub.Stuff;"], GetLines(writer));
    }

    [Fact]
    public void WriteNamespaceImports_MixedImports_SystemDirectivesWrittenFirst()
    {
        var writer = new SourceTextWriter();
        ICodeWriterModule<int>[] modules =
        [
            CreateModule("Raiqub.Stuff", "System.Text", "System"),
        ];

        writer.WriteNamespaceImports(modules, 0);

        Assert.Equal(["using System;", "using System.Text;", "using Raiqub.Stuff;"], GetLines(writer));
    }

    [Fact]
    public void WriteNamespaceImports_SortSystemDirectivesFirstFalse_SortsAlphabetically()
    {
        var writer = new SourceTextWriter();
        ICodeWriterModule<int>[] modules =
        [
            CreateModule("Raiqub.Stuff", "System.Text", "System"),
        ];

        writer.WriteNamespaceImports(modules, 0, sortSystemDirectivesFirst: false);

        Assert.Equal(["using Raiqub.Stuff;", "using System;", "using System.Text;"], GetLines(writer));
    }

    [Fact]
    public void WriteNamespaceImports_DuplicateImportsAcrossModules_DeduplicatesImports()
    {
        var writer = new SourceTextWriter();
        ICodeWriterModule<int>[] modules =
        [
            CreateModule("System", "Raiqub.Stuff"),
            CreateModule("System", "Other"),
        ];

        writer.WriteNamespaceImports(modules, 0);

        Assert.Equal(["using System;", "using Other;", "using Raiqub.Stuff;"], GetLines(writer));
    }

    [Fact]
    public void WriteNamespaceImports_ModuleAndDefaultImportsOverlap_DeduplicatesImports()
    {
        var writer = new SourceTextWriter();
        ICodeWriterModule<int>[] modules = [CreateModule("System")];
        string[] defaults = ["System", "System.Text.Json"];

        writer.WriteNamespaceImports(modules, 0, defaultImports: defaults);

        Assert.Equal(["using System;", "using System.Text.Json;"], GetLines(writer));
    }

    [Fact]
    public void WriteNamespaceImports_ModuleWithCanGenerateForFalse_SkipsItsImports()
    {
        var writer = new SourceTextWriter();
        ICodeWriterModule<int>[] modules = [CreateModule(canGenerateFor: false, "System")];

        writer.WriteNamespaceImports(modules, 0);

        Assert.Equal(string.Empty, writer.ToString());
    }

    [Fact]
    public void WriteNamespaceImports_MixedCanGenerateFor_OnlyIncludesApplicableModuleImports()
    {
        var writer = new SourceTextWriter();
        ICodeWriterModule<int>[] modules =
        [
            CreateModule(canGenerateFor: true, "System"),
            CreateModule(canGenerateFor: false, "System.Text"),
        ];

        writer.WriteNamespaceImports(modules, 0);

        Assert.Equal(["using System;"], GetLines(writer));
    }

    private static string[] GetLines(SourceTextWriter writer) =>
        writer.ToString().Split('\n', StringSplitOptions.RemoveEmptyEntries);

    private static StubModule CreateModule(params string[] imports) =>
        new StubModule(canGenerateFor: true, imports);

    private static StubModule CreateModule(bool canGenerateFor, params string[] imports) =>
        new StubModule(canGenerateFor, imports);

    private sealed class StubModule(bool canGenerateFor, string[] imports) : ICodeWriterModule<int>
    {
        public IEnumerable<string> GetNamespacesImports(int model) => imports;
        public bool CanGenerateFor(int model) => canGenerateFor;
        public void Write(SourceTextWriter writer, int model) { }
    }
}
