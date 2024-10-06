using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities;

/// <summary>
/// An attribute used by the code generator to specify options for generating a JSON converter for the enumeration.
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
[ExcludeFromCodeCoverage]
public sealed class JsonConverterGeneratorAttribute : Attribute
{
    /// <summary>
    /// Gets or sets a value indicating whether integer values are allowed during deserialization. The default is true.
    /// </summary>
    public bool AllowIntegerValues { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether case should be ignored during deserialization. The default is false.
    /// </summary>
    public bool IgnoreCase { get; set; }

    /// <summary>
    /// Gets or sets the fallback value to use when deserialization fails.
    /// </summary>
    public object? DeserializationFailureFallbackValue { get; set; }
}
