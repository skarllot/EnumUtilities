using System.ComponentModel.DataAnnotations;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

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
    [Display(Name = "Complex <Name>", ShortName = "Cplx\"", Description = "All properties with escapes: \\ \" ' \n\t")]
    AllPropertiesEscaped = 51,

    // No Description at all
    NoDescription = 52,
}
