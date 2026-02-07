using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

/// <summary>
/// Tests for Bug480Display: Verifies that special characters and escape sequences in Display attribute properties
/// (Name, ShortName, Description) are correctly escaped in generated code.
/// </summary>
public class Bug480DisplayTests
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
}
