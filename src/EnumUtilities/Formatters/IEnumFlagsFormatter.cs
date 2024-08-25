namespace Raiqub.Generators.EnumUtilities.Formatters;

/// <summary>Represents an interface for formatting enum values that are flags.</summary>
/// <typeparam name="T">The underlying type of the enum.</typeparam>
public interface IEnumFlagsFormatter<T> : IEnumFormatter<T>
{
    /// <summary>Gets the string representation of a single member in a flags enumeration.</summary>
    /// <param name="value">The enumeration value representing a single flag.</param>
    /// <returns>The string representation of the single flag, or <c>null</c> if the value does not correspond to a valid flag.</returns>
    string GetStringForSingleMember(T value);
}
