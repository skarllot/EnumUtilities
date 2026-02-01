namespace Raiqub.Generators.EnumUtilities.Contracts;

/// <summary>Provides metadata information for an enumeration type.</summary>
public interface IEnumMetadata
{
    /// <summary>The minimum defined value of the enumeration.</summary>
    int MinimumValue { get; }

    /// <summary>The maximum defined value of the enumeration.</summary>
    int MaximumValue { get; }

    /// <summary>The count of all unique defined values in the enumeration.</summary>
    int ValueCount { get; }
}
