using Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests;

/// <summary>
/// Tests for Bug480Flags: Verifies that special characters and escape sequences in [Flags] enum descriptions,
/// EnumMember values, and JsonPropertyName attributes are correctly escaped in generated code.
/// </summary>
public class Bug480FlagsTests
{
    [Theory]
    [InlineData(Bug480Flags.Backslash, "\\")]
    [InlineData(Bug480Flags.DoubleQuote, "\"")]
    [InlineData(Bug480Flags.Newline, "\n")]
    [InlineData(Bug480Flags.Tab, "\t")]
    [InlineData(Bug480Flags.EnumMemberBackslash, "Custom value with backslash")]
    [InlineData(Bug480Flags.EnumMemberQuoted, "Quoted enum value")]
    [InlineData(Bug480Flags.JsonNameEscape, "JSON name with escape")]
    [InlineData(Bug480Flags.CombinedEscapes, "All three attributes with escapes")]
    public void GetDescriptionShouldReturnCorrectEscapedValue(Bug480Flags value, string? expected)
    {
        string? description = value.GetDescription();
        Assert.Equal(expected, description);
    }

    [Theory]
    [InlineData("\\", Bug480Flags.Backslash)]
    [InlineData("\"", Bug480Flags.DoubleQuote)]
    [InlineData("\n", Bug480Flags.Newline)]
    [InlineData("\t", Bug480Flags.Tab)]
    [InlineData("Custom value with backslash", Bug480Flags.EnumMemberBackslash)]
    [InlineData("Quoted enum value", Bug480Flags.EnumMemberQuoted)]
    [InlineData("JSON name with escape", Bug480Flags.JsonNameEscape)]
    [InlineData("All three attributes with escapes", Bug480Flags.CombinedEscapes)]
    public void CreateFromDescriptionShouldParseCorrectEscapedValue(string description, Bug480Flags expected)
    {
        Bug480Flags result = Bug480FlagsFactory.CreateFromDescription(description);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Bug480Flags.EnumMemberBackslash, "special\\value")]
    [InlineData(Bug480Flags.EnumMemberQuoted, "\"quoted\"")]
    [InlineData(Bug480Flags.CombinedEscapes, "combined\\escape")]
    [InlineData(Bug480Flags.EnumMemberBackslash | Bug480Flags.EnumMemberQuoted, "special\\value, \"quoted\"")]
    [InlineData(Bug480Flags.EnumMemberBackslash | Bug480Flags.CombinedEscapes, "special\\value, combined\\escape")]
    [InlineData(
        Bug480Flags.EnumMemberBackslash | Bug480Flags.EnumMemberQuoted | Bug480Flags.CombinedEscapes,
        "special\\value, \"quoted\", combined\\escape"
    )]
    public void ToEnumMemberValueShouldReturnCorrectEscapedValue(Bug480Flags value, string expected)
    {
        string result = value.ToEnumMemberValue();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("special\\value", Bug480Flags.EnumMemberBackslash)]
    [InlineData("\"quoted\"", Bug480Flags.EnumMemberQuoted)]
    [InlineData("combined\\escape", Bug480Flags.CombinedEscapes)]
    [InlineData("special\\value, \"quoted\"", Bug480Flags.EnumMemberBackslash | Bug480Flags.EnumMemberQuoted)]
    [InlineData("special\\value, combined\\escape", Bug480Flags.EnumMemberBackslash | Bug480Flags.CombinedEscapes)]
    [InlineData(
        "special\\value, \"quoted\", combined\\escape",
        Bug480Flags.EnumMemberBackslash | Bug480Flags.EnumMemberQuoted | Bug480Flags.CombinedEscapes
    )]
    public void ParseFromEnumMemberValueShouldParseCorrectEscapedValue(string value, Bug480Flags expected)
    {
        Bug480Flags result = Bug480FlagsFactory.ParseFromEnumMemberValue(value);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Bug480Flags.JsonNameEscape, "json\\escape")]
    [InlineData(Bug480Flags.CombinedEscapes, "json\\combined")]
    [InlineData(Bug480Flags.JsonNameEscape | Bug480Flags.CombinedEscapes, "json\\escape, json\\combined")]
    public void ToJsonStringShouldReturnCorrectEscapedValue(Bug480Flags value, string expected)
    {
        string? result = value.ToJsonString();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("json\\escape", Bug480Flags.JsonNameEscape)]
    [InlineData("json\\combined", Bug480Flags.CombinedEscapes)]
    [InlineData("json\\escape, json\\combined", Bug480Flags.JsonNameEscape | Bug480Flags.CombinedEscapes)]
    public void ParseJsonStringShouldParseCorrectEscapedValue(string value, Bug480Flags expected)
    {
        Bug480Flags result = Bug480FlagsFactory.ParseJsonString(value);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(Bug480Flags.Backslash, "Backslash")]
    [InlineData(Bug480Flags.DoubleQuote, "DoubleQuote")]
    [InlineData(Bug480Flags.Backslash | Bug480Flags.DoubleQuote, "Backslash, DoubleQuote")]
    [InlineData(Bug480Flags.Newline | Bug480Flags.Tab, "Newline, Tab")]
    [InlineData(Bug480Flags.EnumMemberBackslash | Bug480Flags.JsonNameEscape, "EnumMemberBackslash, JsonNameEscape")]
    [InlineData(
        Bug480Flags.Backslash | Bug480Flags.Newline | Bug480Flags.CombinedEscapes,
        "Backslash, Newline, CombinedEscapes"
    )]
    public void ToStringFastShouldHandleCombinedFlags(Bug480Flags value, string expected)
    {
        string result = value.ToStringFast();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Backslash", Bug480Flags.Backslash)]
    [InlineData("DoubleQuote", Bug480Flags.DoubleQuote)]
    [InlineData("Backslash, DoubleQuote", Bug480Flags.Backslash | Bug480Flags.DoubleQuote)]
    [InlineData("Newline, Tab", Bug480Flags.Newline | Bug480Flags.Tab)]
    [InlineData("EnumMemberBackslash, JsonNameEscape", Bug480Flags.EnumMemberBackslash | Bug480Flags.JsonNameEscape)]
    [InlineData(
        "Backslash, Newline, CombinedEscapes",
        Bug480Flags.Backslash | Bug480Flags.Newline | Bug480Flags.CombinedEscapes
    )]
    public void ParseShouldHandleCombinedFlags(string name, Bug480Flags expected)
    {
        Bug480Flags result = Bug480FlagsFactory.Parse(name);
        Assert.Equal(expected, result);
    }
}
