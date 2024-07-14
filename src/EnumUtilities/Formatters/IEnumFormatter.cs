using System.Runtime.CompilerServices;

namespace Raiqub.Generators.EnumUtilities.Formatters;

/// <summary>Represents a generic interface for formatting enum values.</summary>
/// <typeparam name="T">The underlying type of enum.</typeparam>
public interface IEnumFormatter<T>
{
    /// <summary>Gets the string count required to represent the given enumeration value as a number.</summary>
    /// <param name="value">The enumeration value.</param>
    /// <returns>The count of the string representation of the value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    int GetStringCountForNumber(T value);

    /// <summary>Gets the string representation of the given enumeration value as a number.</summary>
    /// <param name="value">The enumeration value.</param>
    /// <returns>The string representation of the value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    string GetStringForNumber(T value);

    /// <summary>Attempts to get the string count required to represent the given enumeration member.</summary>
    /// <param name="value">The enumeration value.</param>
    /// <returns>The count of the string representation of the value, or <c>null</c> if the value could not be converted.</returns>
    int? TryGetStringCountForMember(T value);

    /// <summary>Attempts to get the string representation of the given enumeration member.</summary>
    /// <param name="value">The enumeration value.</param>
    /// <returns>The string representation of the value, or <c>null</c> if the value could not be converted.</returns>
    string? TryGetStringForMember(T value);
}
