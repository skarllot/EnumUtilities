using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.Parsers;

/// <summary>
/// Provides helper methods to throw exceptions with standardized messages.
/// </summary>
[StackTraceHidden]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class ThrowHelper
{
    /// <summary>
    /// Throws an <see cref="ArgumentException"/> indicating that an empty value was provided for a parsing operation.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that caused the exception.</param>
    /// <exception cref="ArgumentException">Thrown to indicate that the provided argument is invalid for parsing.</exception>
    [DoesNotReturn]
    public static void ThrowInvalidEmptyParseArgument(string parameterName)
    {
        throw new ArgumentException("Must specify valid information for parsing in the string.", parameterName);
    }

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> indicating that a requested value was not found.
    /// </summary>
    /// <param name="value">The value that was not found.</param>
    /// <param name="parameterName">The name of the parameter that caused the exception.</param>
    /// <exception cref="ArgumentException">Thrown to indicate that the requested value was not found.</exception>
    [DoesNotReturn]
    public static void ThrowValueNotFound(ReadOnlySpan<char> value, string parameterName)
    {
        throw new ArgumentException($"Requested value '{value}' was not found.", parameterName);
    }

    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> indicating that a required argument is <see langword="null"/>.
    /// </summary>
    /// <param name="paramName">The name of the parameter that is <see langword="null"/>.</param>
    /// <exception cref="ArgumentNullException">Always thrown to indicate that the specified parameter is <see langword="null"/>.</exception>
    [DoesNotReturn]
    public static void ThrowArgumentNullException(string paramName)
    {
        throw new ArgumentNullException(paramName);
    }
}
