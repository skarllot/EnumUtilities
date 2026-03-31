using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Factory;

public readonly struct EnumParseDefinition
{
    public EnumParseDefinition() { }

    public required string XmlRefType { get; init; }
    public required string FacadeNameSuffix { get; init; }
    public required string CoreNameSuffix { get; init; }
    public required Func<EnumValue, string?> KeySelector { get; init; }
    public string ActionName { get; init; } = "Parse";
    public string ParameterName { get; init; } = "value";
    public bool AllowNumbers { get; init; } = true;
    public bool AllowEmpty { get; init; } = false;
    public bool UseStringComparison { get; init; } = false;
}
