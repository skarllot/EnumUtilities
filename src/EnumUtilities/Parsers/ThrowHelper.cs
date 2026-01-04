using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.Parsers;

/// <summary>
/// Provides helper methods to throw exceptions with standardized messages.
/// </summary>
#if NET6_0_OR_GREATER
[StackTraceHidden]
#endif
public static class ThrowHelper
{
    /// <summary>
    /// Throws an <see cref="ArgumentException"/> indicating that an empty value was provided for a parsing operation.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that caused the exception.</param>
    /// <exception cref="ArgumentException">Thrown to indicate that the provided argument is invalid for parsing.</exception>
#if NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
    [DoesNotReturn]
#endif
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
#if NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
    [DoesNotReturn]
#endif
    public static void ThrowValueNotFound(ReadOnlySpan<char> value, string parameterName)
    {
#if !NETSTANDARD2_0
        throw new ArgumentException($"Requested value '{value}' was not found.", parameterName);
#else
        throw new ArgumentException($"Requested value '{value.ToString()}' was not found.", parameterName);
#endif
    }

    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> indicating that a required argument is <see langword="null"/>.
    /// </summary>
    /// <param name="paramName">The name of the parameter that is <see langword="null"/>.</param>
    /// <exception cref="ArgumentNullException">Always thrown to indicate that the specified parameter is <see langword="null"/>.</exception>
#if NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
    [DoesNotReturn]
#endif
    public static void ThrowArgumentNullException(string paramName)
    {
        throw new ArgumentNullException(paramName);
    }
}
