using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests;

public class EnumUtilitiesGeneratorTests
{
    private const string GeneratorBasePath =
        "Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator";

    [StringSyntax("C#")]
    private const string WeekDaysEnumText = """
        using System.ComponentModel.DataAnnotations;
        using System.Text.Json.Serialization;
        using Raiqub.Generators.EnumUtilities;

        namespace Testing.Models;

        [EnumGenerator]
        [JsonConverterGenerator(DeserializationFailureFallbackValue = 0, AllowIntegerValues = false)]
        public enum WeekDays
        {
            [Display(
                Name = nameof(Strings.MondayFull),
                ShortName = nameof(Strings.MondayShort),
                Description = nameof(Strings.MondayDescription),
                ResourceType = typeof(Strings))]
            [EnumMember(Value = "Monday")]
            Monday,
            [Display(ShortName = "Tue")]
            [EnumMember(Value = "Tuesday")]
            Tuesday,
            [Display]
            [EnumMember(Value = "Wednesday")]
            Wednesday,
            [Display(Name = "Thursday")]
            [EnumMember(Value = "Thursday")]
            Thursday,
            [Display(Name = "Friday", ShortName = "Fri")]
            [EnumMember(Value = "Friday")]
            Friday,
            [Display(ShortName = "Sat", Description = "Almost the last day of the week")]
            [EnumMember(Value = "Saturday")]
            Saturday,
            [Display(Description = "The last day of the week")]
            [EnumMember(Value = "Sunday")]
            Sunday
        }
        """;

    [StringSyntax("C#")]
    private const string ColoursEnumText = """
        using Raiqub.Generators.EnumUtilities;

        namespace Testing.Models;

        [Flags]
        [EnumGenerator]
        public enum Colours
        {
            Red = 1,
            Blue = 2,
            Green = 4,
        }
        """;

    [StringSyntax("C#")]
    private const string PaymentMethodEnumText = """
        using Raiqub.Generators.EnumUtilities;

        namespace Testing.Models;

        [EnumGenerator]
        public enum PaymentMethod
        {
            [Display(Name = "Credit Card")]
            [EnumMember(Value = "Credit card")]
            Credit,
            [EnumMember(Value = "Debit card")]
            [Display(Name = "Debit Card")]
            Debit,
            [Display(Name = "Physical Cash")]
            [Description("The payment by using physical cash")]
            Cash,
            Cheque
        }
        """;

    [StringSyntax("C#")]
    private const string NoMembersEnumText = """
        using Raiqub.Generators.EnumUtilities;

        namespace Testing.Models;

        [EnumGenerator]
        [JsonConverterGenerator]
        public enum MyEnum
        {
        }
        """;

    [Fact]
    public async Task GenerateFiles()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            [CSharpSyntaxTree.ParseText(WeekDaysEnumText)],
            await ResolveReferenceAssemblies()
        );

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Equal(
            [
                $"{GeneratorBasePath}/Testing.Models.WeekDaysEnumInfo.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.WeekDaysExtensions.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.WeekDaysFactory.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.WeekDaysValidation.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.WeekDaysJsonConverter.g.cs".Replace(
                    '/',
                    Path.DirectorySeparatorChar
                ),
            ],
            generatedFilesNames
        );
        Assert.Empty(runResult.Diagnostics);
    }

    [Fact]
    public async Task GenerateFlagsFiles()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            [CSharpSyntaxTree.ParseText(ColoursEnumText)],
            await ResolveReferenceAssemblies()
        );

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Equal(
            [
                $"{GeneratorBasePath}/Testing.Models.ColoursEnumInfo.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.ColoursExtensions.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.ColoursFactory.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.ColoursValidation.g.cs".Replace('/', Path.DirectorySeparatorChar),
            ],
            generatedFilesNames
        );
        Assert.Empty(runResult.Diagnostics);
    }

    [Fact]
    public async Task GenerateDescriptionFiles()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            [CSharpSyntaxTree.ParseText(PaymentMethodEnumText)],
            await ResolveReferenceAssemblies()
        );

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Equal(
            [
                $"{GeneratorBasePath}/Testing.Models.PaymentMethodEnumInfo.g.cs".Replace(
                    '/',
                    Path.DirectorySeparatorChar
                ),
                $"{GeneratorBasePath}/Testing.Models.PaymentMethodExtensions.g.cs".Replace(
                    '/',
                    Path.DirectorySeparatorChar
                ),
                $"{GeneratorBasePath}/Testing.Models.PaymentMethodFactory.g.cs".Replace(
                    '/',
                    Path.DirectorySeparatorChar
                ),
                $"{GeneratorBasePath}/Testing.Models.PaymentMethodValidation.g.cs".Replace(
                    '/',
                    Path.DirectorySeparatorChar
                ),
            ],
            generatedFilesNames
        );
        Assert.Empty(runResult.Diagnostics);
    }

    [Fact]
    public async Task GenerateBothDescriptionAndDisplayDescriptionFiles()
    {
        // lang=c#
        const string code = """
            using System.ComponentModel;
            using System.ComponentModel.DataAnnotations;
            using Raiqub.Generators.EnumUtilities;

            namespace Testing.Models;

            [EnumGenerator]
            public enum Status
            {
                [Display(Name = "Active", Description = "Currently active")]
                [Description("Active status")]
                Active,
                [Display(Name = "Inactive", Description = "Currently inactive")]
                [Description("Inactive status")]
                Inactive,
                Unknown
            }
            """;

        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            [CSharpSyntaxTree.ParseText(code)],
            await ResolveReferenceAssemblies()
        );

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Equal(
            [
                $"{GeneratorBasePath}/Testing.Models.StatusEnumInfo.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.StatusExtensions.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.StatusFactory.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.StatusValidation.g.cs".Replace('/', Path.DirectorySeparatorChar),
            ],
            generatedFilesNames
        );
        Assert.Empty(runResult.Diagnostics);

        var factoryTree = runResult.GeneratedTrees.Single(t => t.FilePath.Contains("Factory"));
        var factorySource = (await factoryTree.GetTextAsync()).ToString();
        Assert.Contains("TryCreateFromDescription", factorySource);
        Assert.Contains("TryCreateFromDisplayDescription", factorySource);

        var extensionsTree = runResult.GeneratedTrees.Single(t => t.FilePath.Contains("Extensions"));
        var extensionsSource = (await extensionsTree.GetTextAsync()).ToString();
        Assert.Contains("GetDescription", extensionsSource);
        Assert.Contains("GetDisplayDescription", extensionsSource);
    }

    [Fact]
    public async Task NoGenerateFiles()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            [CSharpSyntaxTree.ParseText(NoMembersEnumText)],
            await ResolveReferenceAssemblies()
        );

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Empty(generatedFilesNames);
        Assert.Empty(runResult.Diagnostics);
    }

    [Fact]
    public async Task NoGenerateFilesWhenCSharpVersionLowerThan10()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var parseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp9);
        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            [CSharpSyntaxTree.ParseText(WeekDaysEnumText, parseOptions)],
            await ResolveReferenceAssemblies()
        );

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Empty(generatedFilesNames);

        var diagnostics = runResult.Diagnostics;
        var csharpVersionDiagnostic = Assert.Single(diagnostics, d => d.Id == "REU0003");
        Assert.Equal(DiagnosticSeverity.Warning, csharpVersionDiagnostic.Severity);
        Assert.Contains(
            "C# 10 or higher",
            csharpVersionDiagnostic.GetMessage(System.Globalization.CultureInfo.InvariantCulture)
        );
    }

    private static async Task<IEnumerable<MetadataReference>> ResolveReferenceAssemblies() =>
        [
            .. await ReferenceAssemblies.Net.Net80.ResolveAsync(LanguageNames.CSharp, CancellationToken.None),
            MetadataReference.CreateFromFile(typeof(EnumGeneratorAttribute).Assembly.Location),
        ];
}
