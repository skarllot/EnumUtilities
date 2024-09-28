using System.ComponentModel;

namespace Raiqub.Generators.EnumUtilities.Parsers;

/// <summary>Provides utility methods for parsing enum values from string representations.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static partial class EnumStringParser
{
    private static bool TryParseSingleName<TNumber>(
        ReadOnlySpan<char> value,
        TryParseSingleValueHandler<TNumber> tryParseSingleValueHandler,
        StringComparison comparisonType,
        bool throwOnFailure,
        out TNumber result)
        where TNumber : unmanaged
    {
        bool success = tryParseSingleValueHandler(value, comparisonType, out result);
        if (success)
        {
            return true;
        }

        if (throwOnFailure)
        {
            ThrowHelper.ThrowValueNotFound(value, nameof(value));
        }

        return false;
    }
}
