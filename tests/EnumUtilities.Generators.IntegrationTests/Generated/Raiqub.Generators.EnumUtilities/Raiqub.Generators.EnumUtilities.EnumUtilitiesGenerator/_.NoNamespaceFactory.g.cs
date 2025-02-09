﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities.Parsers;

#pragma warning disable CS1591 // publicly visible type or member must be documented

[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.9.0.0")]
public static partial class NoNamespaceFactory
{
    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the NoNamespace enumeration.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
    public static NoNamespace Parse(string value, bool ignoreCase = false)
    {
        if (value is null) ThrowHelper.ThrowArgumentNullException(nameof(value));
        TryParseName(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
        return (NoNamespace)result;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the NoNamespace enumeration.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
    public static NoNamespace Parse(ReadOnlySpan<char> value, bool ignoreCase = false)
    {
        TryParseName(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
        return (NoNamespace)result;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <returns>The value represented by the specified name or numeric value or null. Note that this value need not be a member of the NoNamespace enumeration.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
    [return: NotNullIfNotNull("value")]
    public static NoNamespace? ParseOrNull(string? value, bool ignoreCase = false)
    {
        if (value is null) return null;
        TryParseName(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
        return (NoNamespace)result;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? value, bool ignoreCase, out NoNamespace result)
    {
        Unsafe.SkipInit(out result);
        return TryParseName(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<NoNamespace, int>(ref result));
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? value, out NoNamespace result)
    {
        Unsafe.SkipInit(out result);
        return TryParseName(value.AsSpan(), StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<NoNamespace, int>(ref result));
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <returns>
    /// Contains an object of type NoNamespace whose value is represented by value if the parse operation succeeds.
    /// If the parse operation fails, result contains <c>null</c> value.
    /// </returns>
    public static NoNamespace? TryParse(string? value, bool ignoreCase = false)
    {
        return TryParseName(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out var result) ? (NoNamespace?)result : null;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, out NoNamespace result)
    {
        Unsafe.SkipInit(out result);
        return TryParseName(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<NoNamespace, int>(ref result));
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="value">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse(ReadOnlySpan<char> value, out NoNamespace result)
    {
        Unsafe.SkipInit(out result);
        return TryParseName(value, StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<NoNamespace, int>(ref result));
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <returns>
    /// Contains an object of type NoNamespace whose value is represented by value if the parse operation succeeds.
    /// If the parse operation fails, result contains <c>null</c> value.
    /// </returns>
    public static NoNamespace? TryParse(ReadOnlySpan<char> value, bool ignoreCase = false)
    {
        return TryParseName(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out var result) ? (NoNamespace?)result : null;
    }

    private static bool TryParseName(ReadOnlySpan<char> value, StringComparison comparisonType, bool throwOnFailure, out int result)
    {
        if (!value.IsEmpty)
        {
            char c = value[0];
            if (char.IsWhiteSpace(c))
            {
                value = value.TrimStart();
                if (value.IsEmpty)
                {
                    goto ParseFailure;
                }

                c = value[0];
            }

            if ((c < '0' || c > '9') && c != '-' && c != '+')
            {
                return TryParseNonNumericName(value, comparisonType, throwOnFailure, out result);
            }

            bool success = EnumNumericParser.TryParse(value, out result);
            if (success)
            {
                return true;
            }

            return TryParseNonNumericName(value, comparisonType, throwOnFailure, out result);
        }

        ParseFailure:
        if (throwOnFailure)
        {
            ThrowHelper.ThrowInvalidEmptyParseArgument(nameof(value));
        }

        result = 0;
        return false;
    }

    private static bool TryParseNonNumericName(ReadOnlySpan<char> value, StringComparison comparisonType, bool throwOnFailure, out int result)
    {
        bool success = TryParseSingleName(value, comparisonType, out result);
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

    private static bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
    {
        if (value.IsEmpty)
        {
            result = 0;
            return false;
        }

        switch (value[0])
        {
            case 'O':
            case 'o':
                switch (value)
                {
                    case { } when value.Equals("One", comparisonType):
                        result = 1;
                        return true;
                }
                break;
            case 'T':
            case 't':
                switch (value)
                {
                    case { } when value.Equals("Two", comparisonType):
                        result = 2;
                        return true;
                }
                break;
            case 'Z':
            case 'z':
                switch (value)
                {
                    case { } when value.Equals("Zero", comparisonType):
                        result = 0;
                        return true;
                }
                break;
        }

        result = 0;
        return false;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="name">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
    [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
    public static bool TryParse(
        [NotNullWhen(true)] string? name,
        StringComparison comparisonType,
        out NoNamespace result)
    {
        Unsafe.SkipInit(out result);
        return TryParseName(name.AsSpan(), comparisonType, throwOnFailure: false, out Unsafe.As<NoNamespace, int>(ref result));
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="name">The case-insensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
    public static bool TryParseIgnoreCase(
        [NotNullWhen(true)] string? name,
        out NoNamespace result)
    {
        Unsafe.SkipInit(out result);
        return TryParseName(name.AsSpan(), StringComparison.OrdinalIgnoreCase, throwOnFailure: false, out Unsafe.As<NoNamespace, int>(ref result));
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="name">The case-insensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <returns>
    /// Contains an object of type NoNamespace whose value is represented by value if the parse operation succeeds.
    /// If the parse operation fails, result contains <c>null</c> value.
    /// </returns>
    [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
    public static NoNamespace? TryParseIgnoreCase(string? name)
    {
        return TryParseName(name.AsSpan(), StringComparison.OrdinalIgnoreCase, throwOnFailure: false, out var result) ? (NoNamespace?)result : null;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="name">The string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>
    /// Contains an object of type NoNamespace whose value is represented by value if the parse operation succeeds.
    /// If the parse operation fails, result contains <c>null</c> value.
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
    [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
    public static NoNamespace? TryParse(string? name, StringComparison comparisonType)
    {
        return TryParseName(name.AsSpan(), comparisonType, throwOnFailure: false, out var result) ? (NoNamespace?)result : null;
    }

    /// <summary>Retrieves an array of the values of the constants in the NoNamespace enumeration.</summary>
    /// <returns>An array that contains the values of the constants in NoNamespace.</returns>
    public static NoNamespace[] GetValues()
    {
        return new[]
        {
            (NoNamespace)(0),
            (NoNamespace)(1),
            (NoNamespace)(2),
        };
    }

    /// <summary>Retrieves an array of the names of the constants in NoNamespace enumeration.</summary>
    /// <returns>A string array of the names of the constants in NoNamespace.</returns>
    public static string[] GetNames()
    {
        return new[]
        {
            "Zero",
            "One",
            "Two",
        };
    }
}
