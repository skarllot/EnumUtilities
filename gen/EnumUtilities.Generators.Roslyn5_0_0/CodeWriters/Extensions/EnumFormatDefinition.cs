using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public readonly struct EnumFormatDefinition
{
    public EnumFormatDefinition() { }

    public required string XmlRefType { get; init; }
    public required string ToStringMethodName { get; init; }
    public required string GetStringLengthMethodName { get; init; }
    public required string Type { get; init; }
    public required Func<EnumValue, string> KeySelector { get; init; }
    public bool AllowNumbers { get; init; } = true;
}
