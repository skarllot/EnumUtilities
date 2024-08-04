using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests;

public class EnumUtilitiesGeneratorTests
{
    private const string GeneratorBasePath =
        "Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator";

    [StringSyntax("C#")]
    private const string WeekDaysEnumText =
        """
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
    private const string ColoursEnumText =
        """
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
    private const string PaymentMethodEnumText =
        """
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
    private const string NoMembersEnumText =
        """
        using Raiqub.Generators.EnumUtilities;

        namespace Testing.Models;

        [EnumGenerator]
        [JsonConverterGenerator]
        public enum MyEnum
        {
        }
        """;

    [Fact]
    public void GenerateFiles()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            new[] { CSharpSyntaxTree.ParseText(WeekDaysEnumText) },
            AppDomain.CurrentDomain.GetAssemblies()
                .Append(typeof(EnumGeneratorAttribute).Assembly)
                .Where(it => !it.IsDynamic && !string.IsNullOrWhiteSpace(it.Location))
                .Select(it => MetadataReference.CreateFromFile(it.Location)));

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Equal(
            [
                $"{GeneratorBasePath}/Testing.Models.WeekDaysEnumInfo.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.WeekDaysExtensions.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.WeekDaysFactory.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.WeekDaysValidation.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.WeekDaysJsonConverter.g.cs".Replace('/', Path.DirectorySeparatorChar),
            ],
            generatedFilesNames);
    }

    [Fact]
    public void GenerateFlagsFiles()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            new[] { CSharpSyntaxTree.ParseText(ColoursEnumText) },
            AppDomain.CurrentDomain.GetAssemblies()
                .Append(typeof(EnumGeneratorAttribute).Assembly)
                .Where(it => !it.IsDynamic && !string.IsNullOrWhiteSpace(it.Location))
                .Select(it => MetadataReference.CreateFromFile(it.Location)));

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Equal(
            [
                $"{GeneratorBasePath}/Testing.Models.ColoursEnumInfo.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.ColoursExtensions.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.ColoursFactory.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.ColoursValidation.g.cs".Replace('/', Path.DirectorySeparatorChar),
            ],
            generatedFilesNames);
    }

    [Fact]
    public void GenerateDescriptionFiles()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            new[] { CSharpSyntaxTree.ParseText(PaymentMethodEnumText) },
            AppDomain.CurrentDomain.GetAssemblies()
                .Append(typeof(EnumGeneratorAttribute).Assembly)
                .Where(it => !it.IsDynamic && !string.IsNullOrWhiteSpace(it.Location))
                .Select(it => MetadataReference.CreateFromFile(it.Location)));

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Equal(
            [
                $"{GeneratorBasePath}/Testing.Models.PaymentMethodEnumInfo.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.PaymentMethodExtensions.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.PaymentMethodFactory.g.cs".Replace('/', Path.DirectorySeparatorChar),
                $"{GeneratorBasePath}/Testing.Models.PaymentMethodValidation.g.cs".Replace('/', Path.DirectorySeparatorChar),
            ],
            generatedFilesNames);
    }

    [Fact]
    public void NoGenerateFiles()
    {
        var generator = new EnumUtilitiesGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);

        var compilation = CSharpCompilation.Create(
            nameof(EnumUtilitiesGeneratorTests),
            new[] { CSharpSyntaxTree.ParseText(NoMembersEnumText) },
            AppDomain.CurrentDomain.GetAssemblies()
                .Append(typeof(EnumGeneratorAttribute).Assembly)
                .Where(it => !it.IsDynamic && !string.IsNullOrWhiteSpace(it.Location))
                .Select(it => MetadataReference.CreateFromFile(it.Location)));

        var runResult = driver.RunGenerators(compilation).GetRunResult();
        var generatedFilesNames = runResult.GeneratedTrees.Select(t => t.FilePath);

        Assert.Empty(generatedFilesNames);
    }
}
