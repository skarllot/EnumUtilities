using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[Flags]
[EnumGenerator]
[JsonConverterGenerator]
[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix")]
public enum Bug480Flags
{
    // Basic escape sequences in descriptions
    [Description("\\")]
    Backslash = 1,

    [Description("\"")]
    DoubleQuote = 2,

    [Description("\n")]
    Newline = 4,

    [Description("\t")]
    Tab = 8,

    // EnumMember with special values
    [EnumMember(Value = "special\\value")]
    [Description("Custom value with backslash")]
    EnumMemberBackslash = 16,

    [EnumMember(Value = "\"quoted\"")]
    [Description("Quoted enum value")]
    EnumMemberQuoted = 32,

    // JsonPropertyName with special characters
    [JsonPropertyName("json\\escape")]
    [Description("JSON name with escape")]
    JsonNameEscape = 64,

    // Combined attributes with special characters
    [EnumMember(Value = "combined\\escape")]
    [JsonPropertyName("json\\combined")]
    [Description("All three attributes with escapes")]
    CombinedEscapes = 128,
}
