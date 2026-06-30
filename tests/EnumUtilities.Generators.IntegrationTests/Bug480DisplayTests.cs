using System.ComponentModel.DataAnnotations;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

/// <summary>
/// Tests for Bug480Display: Verifies that special characters and escape sequences in Display attribute properties
/// (Name, ShortName, Description) are correctly escaped in generated code.
/// </summary>
public partial class Bug480DisplayTests
{
    [Theory]
    [InlineData(Bug480Display.Backslash, "\\")]
    [InlineData(Bug480Display.DoubleQuote, "\"")]
    [InlineData(Bug480Display.SingleQuote, "'")]
    [InlineData(Bug480Display.Newline, "\n")]
    [InlineData(Bug480Display.CarriageReturn, "\r")]
    [InlineData(Bug480Display.Tab, "\t")]
    [InlineData(Bug480Display.CrLf, "\r\n")]
    [InlineData(Bug480Display.MultipleNewlines, "Line 1\nLine 2\nLine 3")]
    [InlineData(Bug480Display.WindowsPath, "Path: C:\\Users\\Documents\\File.txt")]
    [InlineData(Bug480Display.MixedQuotes, "Say \"Hello\" to the 'world'")]
    [InlineData(Bug480Display.LessThan, "Value < 10")]
    [InlineData(Bug480Display.GreaterThan, "Value > 10")]
    [InlineData(Bug480Display.Ampersand, "X & Y")]
    [InlineData(Bug480Display.XmlTag, "Tag: <xml>")]
    [InlineData(Bug480Display.XmlSpecialChars, "Formula: 5 < x && x > 0")]
    [InlineData(Bug480Display.Degree, "Temperature: 25°C")]
    [InlineData(Bug480Display.Copyright, "Copyright © 2024")]
    [InlineData(Bug480Display.Euro, "Price: €100")]
    [InlineData(Bug480Display.Unicode, "Hello 世界")]
    [InlineData(Bug480Display.Emoji, "Emoji: 🚀")]
    [InlineData(Bug480Display.NullChar, "\0")]
    [InlineData(Bug480Display.Backspace, "\b")]
    [InlineData(Bug480Display.FormFeed, "\f")]
    [InlineData(Bug480Display.VerticalTab, "\v")]
    [InlineData(Bug480Display.JsonLike, "{\n\t\"key\": \"value\",\n\t\"escaped\": \"\\\"quoted\\\"\"\n}")]
    [InlineData(Bug480Display.CData, "<![CDATA[Some <data> here]]>")]
    [InlineData(Bug480Display.CodeComment, "/* Comment */ // Another")]
    [InlineData(Bug480Display.VerbatimString, "Verbatim: \"quoted\"")]
    [InlineData(Bug480Display.NameBackslash, "Custom value with backslash")]
    [InlineData(Bug480Display.NameQuoted, "Quoted name value")]
    [InlineData(Bug480Display.NameNewline, "Newline in name")]
    [InlineData(Bug480Display.ShortNameEscape, "ShortName with escape")]
    [InlineData(Bug480Display.ShortNameQuoted, "ShortName quoted")]
    [InlineData(Bug480Display.DisplayWithQuotes, "Display attributes with quotes")]
    [InlineData(Bug480Display.DisplayMixed, "Temp <folder>")]
    [InlineData(Bug480Display.EmptyDescription, "")]
    [InlineData(Bug480Display.WhitespaceDescription, "     ")]
    [InlineData(Bug480Display.EmptyLine, "Line 1\n\nLine 3")]
    [InlineData(Bug480Display.TrailingSpace, "Trailing space   ")]
    [InlineData(Bug480Display.LeadingSpace, "   Leading space")]
    [InlineData(Bug480Display.Url, "https://example.com/path?param=value&other=123")]
    [InlineData(Bug480Display.SqlLike, "SELECT * FROM Users WHERE Name = 'O''Brien'")]
    [InlineData(Bug480Display.RegexPattern, "^\\d{3}-\\d{2}-\\d{4}$")]
    [InlineData(Bug480Display.UncPath, "\\\\server\\share\\folder\\file.txt")]
    [InlineData(Bug480Display.UnixPath, "/usr/local/bin")]
    [InlineData(Bug480Display.DoubleBackslash, "\\\\")]
    [InlineData(Bug480Display.TripleQuote, "\"\"\"")]
    [InlineData(Bug480Display.TripleNewline, "\n\n\n")]
    [InlineData(Bug480Display.ComplexError, "Error: \"File not found\" at C:\\Path\\To\\File.txt\nDetails: <none>")]
    [InlineData(Bug480Display.EscapedJson, "JSON: {\"key\": \"value with \\\"quotes\\\" and \\n newlines\"}")]
    [InlineData(Bug480Display.AllPropertiesEscaped, "All properties with escapes: \\ \" ' \n\t")]
    [InlineData(Bug480Display.NoDescription, null)]
    public void GetDescriptionShouldReturnCorrectEscapedValue(Bug480Display value, string? expected)
    {
        string? description = value.GetDescription();
        Assert.Equal(expected, description);
    }

    [Theory]
    [InlineData(Bug480Display.NameBackslash, "special\\value")]
    [InlineData(Bug480Display.NameQuoted, "\"quoted\"")]
    [InlineData(Bug480Display.NameNewline, "new\nline")]
    [InlineData(Bug480Display.DisplayWithQuotes, "Display \"Name\" with quotes")]
    [InlineData(Bug480Display.DisplayMixed, "Path: C:\\Temp")]
    [InlineData(Bug480Display.AllPropertiesEscaped, "Complex <Name>")]
    public void GetDisplayNameShouldReturnCorrectEscapedValue(Bug480Display value, string expected)
    {
        string result = value.GetDisplayName();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Bug480Display.ShortNameEscape, "short\\escape")]
    [InlineData(Bug480Display.ShortNameQuoted, "\"short-quoted\"")]
    [InlineData(Bug480Display.DisplayWithQuotes, "D'Name")]
    [InlineData(Bug480Display.DisplayMixed, "Tmp")]
    [InlineData(Bug480Display.AllPropertiesEscaped, "Cplx\"")]
    public void GetDisplayShortNameShouldReturnCorrectEscapedValue(Bug480Display value, string expected)
    {
        string result = value.GetDisplayShortName();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("special\\value", Bug480Display.NameBackslash)]
    [InlineData("\"quoted\"", Bug480Display.NameQuoted)]
    [InlineData("new\nline", Bug480Display.NameNewline)]
    [InlineData("Display \"Name\" with quotes", Bug480Display.DisplayWithQuotes)]
    [InlineData("Path: C:\\Temp", Bug480Display.DisplayMixed)]
    [InlineData("Complex <Name>", Bug480Display.AllPropertiesEscaped)]
    public void TryCreateFromDisplayNameShouldParseCorrectEscapedValue(string displayName, Bug480Display expected)
    {
        Bug480Display? result = Bug480DisplayFactory.TryCreateFromDisplayName(displayName);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("short\\escape", Bug480Display.ShortNameEscape)]
    [InlineData("\"short-quoted\"", Bug480Display.ShortNameQuoted)]
    [InlineData("D'Name", Bug480Display.DisplayWithQuotes)]
    [InlineData("Tmp", Bug480Display.DisplayMixed)]
    [InlineData("Cplx\"", Bug480Display.AllPropertiesEscaped)]
    public void TryCreateFromDisplayShortNameShouldParseCorrectEscapedValue(string shortName, Bug480Display expected)
    {
        Bug480Display? result = Bug480DisplayFactory.TryCreateFromDisplayShortName(shortName);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("\\", Bug480Display.Backslash)]
    [InlineData("\"", Bug480Display.DoubleQuote)]
    [InlineData("Value < 10", Bug480Display.LessThan)]
    [InlineData("Temperature: 25°C", Bug480Display.Degree)]
    [InlineData("Hello 世界", Bug480Display.Unicode)]
    [InlineData("\0", Bug480Display.NullChar)]
    [InlineData("Temp <folder>", Bug480Display.DisplayMixed)]
    public void TryCreateFromDescriptionShouldParseCorrectEscapedValue(string description, Bug480Display expected)
    {
        Bug480Display? result = Bug480DisplayFactory.TryCreateFromDescription(description);
        Assert.Equal(expected, result);
    }

    [EnumGenerator]
    [JsonConverterGenerator]
    public enum Bug480Display
    {
        // Basic escape sequences in Description property
        [Display(Description = "\\")]
        Backslash = 1,

        [Display(Description = "\"")]
        DoubleQuote = 2,

        [Display(Description = "'")]
        SingleQuote = 3,

        [Display(Description = "\n")]
        Newline = 4,

        [Display(Description = "\r")]
        CarriageReturn = 5,

        [Display(Description = "\t")]
        Tab = 6,

        [Display(Description = "\r\n")]
        CrLf = 7,

        // Multiple escapes
        [Display(Description = "Line 1\nLine 2\nLine 3")]
        MultipleNewlines = 8,

        [Display(Description = "Path: C:\\Users\\Documents\\File.txt")]
        WindowsPath = 9,

        [Display(Description = "Say \"Hello\" to the 'world'")]
        MixedQuotes = 10,

        // XML special characters in descriptions
        [Display(Description = "Value < 10")]
        LessThan = 11,

        [Display(Description = "Value > 10")]
        GreaterThan = 12,

        [Display(Description = "X & Y")]
        Ampersand = 13,

        [Display(Description = "Tag: <xml>")]
        XmlTag = 14,

        [Display(Description = "Formula: 5 < x && x > 0")]
        XmlSpecialChars = 15,

        // Unicode and special characters
        [Display(Description = "Temperature: 25°C")]
        Degree = 16,

        [Display(Description = "Copyright © 2024")]
        Copyright = 17,

        [Display(Description = "Price: €100")]
        Euro = 18,

        [Display(Description = "Hello 世界")]
        Unicode = 19,

        [Display(Description = "Emoji: 🚀")]
        Emoji = 20,

        // Control characters and nulls
        [Display(Description = "\0")]
        NullChar = 21,

        [Display(Description = "\b")]
        Backspace = 22,

        [Display(Description = "\f")]
        FormFeed = 23,

        [Display(Description = "\v")]
        VerticalTab = 24,

        // Complex combinations
        [Display(Description = "{\n\t\"key\": \"value\",\n\t\"escaped\": \"\\\"quoted\\\"\"\n}")]
        JsonLike = 25,

        [Display(Description = "<![CDATA[Some <data> here]]>")]
        CData = 26,

        [Display(Description = "/* Comment */ // Another")]
        CodeComment = 27,

        [Display(Description = @"Verbatim: ""quoted""")]
        VerbatimString = 28,

        // Name with special characters
        [Display(Name = "special\\value", Description = "Custom value with backslash")]
        NameBackslash = 29,

        [Display(Name = "\"quoted\"", Description = "Quoted name value")]
        NameQuoted = 30,

        [Display(Name = "new\nline", Description = "Newline in name")]
        NameNewline = 31,

        // ShortName with special characters
        [Display(ShortName = "short\\escape", Description = "ShortName with escape")]
        ShortNameEscape = 32,

        [Display(ShortName = "\"short-quoted\"", Description = "ShortName quoted")]
        ShortNameQuoted = 33,

        // Multiple Display properties with special characters
        [Display(
            Name = "Display \"Name\" with quotes",
            ShortName = "D'Name",
            Description = "Display attributes with quotes"
        )]
        DisplayWithQuotes = 34,

        [Display(Name = "Path: C:\\Temp", ShortName = "Tmp", Description = "Temp <folder>")]
        DisplayMixed = 35,

        // Edge cases
        [Display(Description = "")]
        EmptyDescription = 36,

        [Display(Description = "     ")]
        WhitespaceDescription = 37,

        [Display(Description = "Line 1\n\nLine 3")]
        EmptyLine = 38,

        [Display(Description = "Trailing space   ")]
        TrailingSpace = 39,

        [Display(Description = "   Leading space")]
        LeadingSpace = 40,

        // URL-like strings
        [Display(Description = "https://example.com/path?param=value&other=123")]
        Url = 41,

        // SQL-like strings
        [Display(Description = "SELECT * FROM Users WHERE Name = 'O''Brien'")]
        SqlLike = 42,

        // Regex-like strings
        [Display(Description = @"^\d{3}-\d{2}-\d{4}$")]
        RegexPattern = 43,

        // File path variations
        [Display(Description = @"\\server\share\folder\file.txt")]
        UncPath = 44,

        [Display(Description = "/usr/local/bin")]
        UnixPath = 45,

        // Multiple consecutive escapes
        [Display(Description = "\\\\")]
        DoubleBackslash = 46,

        [Display(Description = "\"\"\"")]
        TripleQuote = 47,

        [Display(Description = "\n\n\n")]
        TripleNewline = 48,

        // Mixed problematic characters
        [Display(Description = "Error: \"File not found\" at C:\\Path\\To\\File.txt\nDetails: <none>")]
        ComplexError = 49,

        [Display(Description = "JSON: {\"key\": \"value with \\\"quotes\\\" and \\n newlines\"}")]
        EscapedJson = 50,

        // Name with all properties containing special characters
        [Display(
            Name = "Complex <Name>",
            ShortName = "Cplx\"",
            Description = "All properties with escapes: \\ \" ' \n\t"
        )]
        AllPropertiesEscaped = 51,

        // No Description at all
        NoDescription = 52,
    }
}
