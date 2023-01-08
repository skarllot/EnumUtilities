using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Stubble.Core.Builders;

namespace Raiqub.Generators.EnumUtilities.Tests;

public static class TestHelper
{
    public static Task Verify(string source)
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(source);
        var compilation = CSharpCompilation.Create("Tests", new[] { syntaxTree }, GetReferences());

        var generator = new EnumUtilitiesGenerator();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.RunGenerators(compilation);

        return Verifier
            .Verify(driver)
            .UseDirectory("Snapshots");
    }

    private static IEnumerable<PortableExecutableReference> GetReferences()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .Append(typeof(EnumGeneratorAttribute).Assembly)
            .Append(typeof(StubbleBuilder).Assembly)
            .Where(it => !it.IsDynamic && !string.IsNullOrWhiteSpace(it.Location))
            .Select(it => MetadataReference.CreateFromFile(it.Location));
    }
}