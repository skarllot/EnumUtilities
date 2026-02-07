using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[EnumGenerator]
[JsonConverterGenerator]
public enum Bug480
{
    // Basic escape sequences
    [Description("\\")]
    Backslash = 1,

    [Description("\"")]
    DoubleQuote = 2,

    [Description("'")]
    SingleQuote = 3,

    [Description("\n")]
    Newline = 4,

    [Description("\r")]
    CarriageReturn = 5,

    [Description("\t")]
    Tab = 6,

    [Description("\r\n")]
    CrLf = 7,

    // Multiple escapes
    [Description("Line 1\nLine 2\nLine 3")]
    MultipleNewlines = 8,

    [Description("Path: C:\\Users\\Documents\\File.txt")]
    WindowsPath = 9,

    [Description("Say \"Hello\" to the 'world'")]
    MixedQuotes = 10,

    // XML special characters in descriptions
    [Description("Value < 10")]
    LessThan = 11,

    [Description("Value > 10")]
    GreaterThan = 12,

    [Description("X & Y")]
    Ampersand = 13,

    [Description("Tag: <xml>")]
    XmlTag = 14,

    [Description("Formula: 5 < x && x > 0")]
    XmlSpecialChars = 15,

    // Unicode and special characters
    [Description("Temperature: 25°C")]
    Degree = 16,

    [Description("Copyright © 2024")]
    Copyright = 17,

    [Description("Price: €100")]
    Euro = 18,

    [Description("Hello 世界")]
    Unicode = 19,

    [Description("Emoji: 🚀")]
    Emoji = 20,

    // Control characters and nulls
    [Description("\0")]
    NullChar = 21,

    [Description("\b")]
    Backspace = 22,

    [Description("\f")]
    FormFeed = 23,

    [Description("\v")]
    VerticalTab = 24,

    // Complex combinations
    [Description("{\n\t\"key\": \"value\",\n\t\"escaped\": \"\\\"quoted\\\"\"\n}")]
    JsonLike = 25,

    [Description("<![CDATA[Some <data> here]]>")]
    CData = 26,

    [Description("/* Comment */ // Another")]
    CodeComment = 27,

    [Description(@"Verbatim: ""quoted""")]
    VerbatimString = 28,

    // EnumMember with special values
    [EnumMember(Value = "special\\value")]
    [Description("Custom value with backslash")]
    EnumMemberBackslash = 29,

    [EnumMember(Value = "\"quoted\"")]
    [Description("Quoted enum value")]
    EnumMemberQuoted = 30,

    [EnumMember(Value = "new\nline")]
    [Description("Newline in value")]
    EnumMemberNewline = 31,

    // JsonPropertyName with special characters
    [JsonPropertyName("json\\escape")]
    [Description("JSON name with escape")]
    JsonNameEscape = 32,

    [JsonPropertyName("\"json-quoted\"")]
    [Description("JSON name quoted")]
    JsonNameQuoted = 33,

    // Combined attributes with special characters
    [EnumMember(Value = "combined\\escape")]
    [JsonPropertyName("json\\combined")]
    [Description("All three attributes with escapes")]
    CombinedEscapes = 34,

    [EnumMember(Value = "tab\tvalue")]
    [Description("Tab in EnumMember value")]
    EnumMemberTab = 35,

    // Edge cases
    [Description("")]
    EmptyDescription = 36,

    [Description("     ")]
    WhitespaceDescription = 37,

    [Description("Line 1\n\nLine 3")]
    EmptyLine = 38,

    [Description("Trailing space   ")]
    TrailingSpace = 39,

    [Description("   Leading space")]
    LeadingSpace = 40,

    // URL-like strings
    [Description("https://example.com/path?param=value&other=123")]
    Url = 41,

    // SQL-like strings
    [Description("SELECT * FROM Users WHERE Name = 'O''Brien'")]
    SqlLike = 42,

    // Regex-like strings
    [Description(@"^\d{3}-\d{2}-\d{4}$")]
    RegexPattern = 43,

    // File path variations
    [Description(@"\\server\share\folder\file.txt")]
    UncPath = 44,

    [Description("/usr/local/bin")]
    UnixPath = 45,

    // Multiple consecutive escapes
    [Description("\\\\")]
    DoubleBackslash = 46,

    [Description("\"\"\"")]
    TripleQuote = 47,

    [Description("\n\n\n")]
    TripleNewline = 48,

    // Mixed problematic characters
    [Description("Error: \"File not found\" at C:\\Path\\To\\File.txt\nDetails: <none>")]
    ComplexError = 49,

    [Description("JSON: {\"key\": \"value with \\\"quotes\\\" and \\n newlines\"}")]
    EscapedJson = 50,

    NullDescription = 51,
}
