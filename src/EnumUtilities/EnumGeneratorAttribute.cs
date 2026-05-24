using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities;

/// <summary>
/// Triggers source generation of extension methods, factory methods, and validation utilities
/// for the decorated enum type.
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
[ExcludeFromCodeCoverage]
public sealed class EnumGeneratorAttribute : Attribute
{
    /// <summary>
    /// Disables generation of a precomputed lookup table for <c>[Flags]</c> enumerations
    /// that span at most 8 bits (at most 256 possible flag combinations).
    /// </summary>
    /// <remarks>
    /// When <see langword="false"/> (the default), the generator emits a static string array covering
    /// every possible combination of flag values, enabling O(1) string formatting at the cost of a
    /// small amount of memory. Set to <see langword="true"/> to skip the table and fall back to
    /// runtime string construction, which reduces generated code size at the cost of additional CPU
    /// work during formatting. This option has no effect on non-flags enumerations.
    /// </remarks>
    public bool DisableLookupTable { get; set; }
}
