using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

/// <summary>
/// Tests for Bug480: Verifies that special characters and escape sequences in enum descriptions,
/// EnumMember values, and JsonPropertyName attributes are correctly escaped in generated code.
/// </summary>
public class Bug480Tests
{
    [Theory]
    [InlineData(Bug480.Backslash, "\\")]
    [InlineData(Bug480.DoubleQuote, "\"")]
    [InlineData(Bug480.SingleQuote, "'")]
    [InlineData(Bug480.Newline, "\n")]
    [InlineData(Bug480.CarriageReturn, "\r")]
    [InlineData(Bug480.Tab, "\t")]
    [InlineData(Bug480.CrLf, "\r\n")]
    [InlineData(Bug480.MultipleNewlines, "Line 1\nLine 2\nLine 3")]
    [InlineData(Bug480.WindowsPath, "Path: C:\\Users\\Documents\\File.txt")]
    [InlineData(Bug480.MixedQuotes, "Say \"Hello\" to the 'world'")]
    [InlineData(Bug480.LessThan, "Value < 10")]
    [InlineData(Bug480.GreaterThan, "Value > 10")]
    [InlineData(Bug480.Ampersand, "X & Y")]
    [InlineData(Bug480.XmlTag, "Tag: <xml>")]
    [InlineData(Bug480.XmlSpecialChars, "Formula: 5 < x && x > 0")]
    [InlineData(Bug480.Degree, "Temperature: 25°C")]
    [InlineData(Bug480.Copyright, "Copyright © 2024")]
    [InlineData(Bug480.Euro, "Price: €100")]
    [InlineData(Bug480.Unicode, "Hello 世界")]
    [InlineData(Bug480.Emoji, "Emoji: 🚀")]
    [InlineData(Bug480.NullChar, "\0")]
    [InlineData(Bug480.Backspace, "\b")]
    [InlineData(Bug480.FormFeed, "\f")]
    [InlineData(Bug480.VerticalTab, "\v")]
    [InlineData(Bug480.JsonLike, "{\n\t\"key\": \"value\",\n\t\"escaped\": \"\\\"quoted\\\"\"\n}")]
    [InlineData(Bug480.CData, "<![CDATA[Some <data> here]]>")]
    [InlineData(Bug480.CodeComment, "/* Comment */ // Another")]
    [InlineData(Bug480.VerbatimString, "Verbatim: \"quoted\"")]
    [InlineData(Bug480.EmptyDescription, "")]
    [InlineData(Bug480.WhitespaceDescription, "     ")]
    [InlineData(Bug480.EmptyLine, "Line 1\n\nLine 3")]
    [InlineData(Bug480.TrailingSpace, "Trailing space   ")]
    [InlineData(Bug480.LeadingSpace, "   Leading space")]
    [InlineData(Bug480.Url, "https://example.com/path?param=value&other=123")]
    [InlineData(Bug480.SqlLike, "SELECT * FROM Users WHERE Name = 'O''Brien'")]
    [InlineData(Bug480.RegexPattern, "^\\d{3}-\\d{2}-\\d{4}$")]
    [InlineData(Bug480.UncPath, "\\\\server\\share\\folder\\file.txt")]
    [InlineData(Bug480.UnixPath, "/usr/local/bin")]
    [InlineData(Bug480.DoubleBackslash, "\\\\")]
    [InlineData(Bug480.TripleQuote, "\"\"\"")]
    [InlineData(Bug480.TripleNewline, "\n\n\n")]
    [InlineData(Bug480.ComplexError, "Error: \"File not found\" at C:\\Path\\To\\File.txt\nDetails: <none>")]
    [InlineData(Bug480.EscapedJson, "JSON: {\"key\": \"value with \\\"quotes\\\" and \\n newlines\"}")]
    [InlineData(Bug480.NullDescription, null)]
    public void GetDescriptionShouldReturnCorrectEscapedValue(Bug480 value, string? expected)
    {
        string? description = value.GetDescription();
        Assert.Equal(expected, description);
    }

    [Theory]
    [InlineData("\\", Bug480.Backslash)]
    [InlineData("\"", Bug480.DoubleQuote)]
    [InlineData("'", Bug480.SingleQuote)]
    [InlineData("\n", Bug480.Newline)]
    [InlineData("\r", Bug480.CarriageReturn)]
    [InlineData("\t", Bug480.Tab)]
    [InlineData("\r\n", Bug480.CrLf)]
    [InlineData("Line 1\nLine 2\nLine 3", Bug480.MultipleNewlines)]
    [InlineData("Path: C:\\Users\\Documents\\File.txt", Bug480.WindowsPath)]
    [InlineData("Say \"Hello\" to the 'world'", Bug480.MixedQuotes)]
    [InlineData("Value < 10", Bug480.LessThan)]
    [InlineData("Value > 10", Bug480.GreaterThan)]
    [InlineData("X & Y", Bug480.Ampersand)]
    [InlineData("Tag: <xml>", Bug480.XmlTag)]
    [InlineData("Formula: 5 < x && x > 0", Bug480.XmlSpecialChars)]
    [InlineData("Temperature: 25°C", Bug480.Degree)]
    [InlineData("Copyright © 2024", Bug480.Copyright)]
    [InlineData("Price: €100", Bug480.Euro)]
    [InlineData("Hello 世界", Bug480.Unicode)]
    [InlineData("Emoji: 🚀", Bug480.Emoji)]
    [InlineData("\0", Bug480.NullChar)]
    [InlineData("\b", Bug480.Backspace)]
    [InlineData("\f", Bug480.FormFeed)]
    [InlineData("\v", Bug480.VerticalTab)]
    [InlineData("{\n\t\"key\": \"value\",\n\t\"escaped\": \"\\\"quoted\\\"\"\n}", Bug480.JsonLike)]
    [InlineData("<![CDATA[Some <data> here]]>", Bug480.CData)]
    [InlineData("/* Comment */ // Another", Bug480.CodeComment)]
    [InlineData("Verbatim: \"quoted\"", Bug480.VerbatimString)]
    [InlineData("", Bug480.EmptyDescription)]
    [InlineData("     ", Bug480.WhitespaceDescription)]
    [InlineData("Line 1\n\nLine 3", Bug480.EmptyLine)]
    [InlineData("Trailing space   ", Bug480.TrailingSpace)]
    [InlineData("   Leading space", Bug480.LeadingSpace)]
    [InlineData("https://example.com/path?param=value&other=123", Bug480.Url)]
    [InlineData("SELECT * FROM Users WHERE Name = 'O''Brien'", Bug480.SqlLike)]
    [InlineData("^\\d{3}-\\d{2}-\\d{4}$", Bug480.RegexPattern)]
    [InlineData("\\\\server\\share\\folder\\file.txt", Bug480.UncPath)]
    [InlineData("/usr/local/bin", Bug480.UnixPath)]
    [InlineData("\\\\", Bug480.DoubleBackslash)]
    [InlineData("\"\"\"", Bug480.TripleQuote)]
    [InlineData("\n\n\n", Bug480.TripleNewline)]
    [InlineData("Error: \"File not found\" at C:\\Path\\To\\File.txt\nDetails: <none>", Bug480.ComplexError)]
    [InlineData("JSON: {\"key\": \"value with \\\"quotes\\\" and \\n newlines\"}", Bug480.EscapedJson)]
    public void CreateFromDescriptionShouldParseCorrectEscapedValue(string description, Bug480 expected)
    {
        Bug480 result = Bug480Factory.CreateFromDescription(description);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Bug480.EnumMemberBackslash, "special\\value")]
    [InlineData(Bug480.EnumMemberQuoted, "\"quoted\"")]
    [InlineData(Bug480.EnumMemberNewline, "new\nline")]
    [InlineData(Bug480.EnumMemberTab, "tab\tvalue")]
    [InlineData(Bug480.CombinedEscapes, "combined\\escape")]
    public void ToEnumMemberValueShouldReturnCorrectEscapedValue(Bug480 value, string expected)
    {
        string result = value.ToEnumMemberValue();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("special\\value", Bug480.EnumMemberBackslash)]
    [InlineData("\"quoted\"", Bug480.EnumMemberQuoted)]
    [InlineData("new\nline", Bug480.EnumMemberNewline)]
    [InlineData("tab\tvalue", Bug480.EnumMemberTab)]
    [InlineData("combined\\escape", Bug480.CombinedEscapes)]
    public void ParseFromEnumMemberValueShouldParseCorrectEscapedValue(string value, Bug480 expected)
    {
        Bug480 result = Bug480Factory.ParseFromEnumMemberValue(value);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Bug480.JsonNameEscape, "json\\escape")]
    [InlineData(Bug480.JsonNameQuoted, "\"json-quoted\"")]
    [InlineData(Bug480.CombinedEscapes, "json\\combined")]
    public void ToJsonStringShouldReturnCorrectEscapedValue(Bug480 value, string expected)
    {
        string? result = value.ToJsonString();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("json\\escape", Bug480.JsonNameEscape)]
    [InlineData("\"json-quoted\"", Bug480.JsonNameQuoted)]
    [InlineData("json\\combined", Bug480.CombinedEscapes)]
    public void ParseJsonStringShouldParseCorrectEscapedValue(string value, Bug480 expected)
    {
        Bug480 result = Bug480Factory.ParseJsonString(value);
        Assert.Equal(expected, result);
    }
}
