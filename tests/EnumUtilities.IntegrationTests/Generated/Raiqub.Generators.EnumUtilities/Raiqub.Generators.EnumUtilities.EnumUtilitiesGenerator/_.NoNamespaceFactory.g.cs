﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities;

#pragma warning disable CS1591 // publicly visible type or member must be documented

[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.6.0.0")]
public static partial class NoNamespaceFactory
{
    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? name, bool ignoreCase, out NoNamespace result)
    {
        return TryParse(name.AsSpan(), ignoreCase, out result);
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? name, out NoNamespace result)
    {
        return TryParse(name.AsSpan(), false, out result);
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
    /// <returns>
    /// Contains an object of type NoNamespace whose value is represented by value if the parse operation succeeds.
    /// If the parse operation fails, result contains <c>null</c> value.
    /// </returns>
    public static NoNamespace? TryParse(string? name, bool ignoreCase)
    {
        return TryParse(name.AsSpan(), ignoreCase, out NoNamespace result) ? result : null;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <returns>
    /// Contains an object of type NoNamespace whose value is represented by value if the parse operation succeeds.
    /// If the parse operation fails, result contains <c>null</c> value.
    /// </returns>
    public static NoNamespace? TryParse(string? name)
    {
        return TryParse(name.AsSpan(), false, out NoNamespace result) ? result : null;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="source">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="ignoreCase"><c>true</c> to read <paramref name="source"/> in case insensitive mode; <c>false</c> to read value in case sensitive mode.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse(ReadOnlySpan<char> source, bool ignoreCase, out NoNamespace result)
    {
        bool success = EnumStringParser.TryParse(source, NoNamespaceStringParser.Instance, ignoreCase, false, out int number);
        if (!success)
        {
            result = 0;
            return false;
        }

        result = (NoNamespace)number;
        return true;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="source">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParse(ReadOnlySpan<char> source, out NoNamespace result)
    {
        return TryParse(source, false, out result);
    }

    /// <summary>
    /// Converts the UTF-8 representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="source">The case-sensitive UTF-8 representation of the enumeration name or underlying value to convert.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParseUtf8(ReadOnlySpan<byte> source, out NoNamespace result)
    {
        if (source == "Zero"u8)
        {
            result = NoNamespace.Zero;
            return true;
        }

        if (source == "One"u8)
        {
            result = NoNamespace.One;
            return true;
        }

        if (source == "Two"u8)
        {
            result = NoNamespace.Two;
            return true;
        }

        if (source == "0"u8)
        {
            result = NoNamespace.Zero;
            return true;
        }

        if (source == "1"u8)
        {
            result = NoNamespace.One;
            return true;
        }

        if (source == "2"u8)
        {
            result = NoNamespace.Two;
            return true;
        }

#if NET6_0_OR_GREATER
        int charCount = System.Text.Encoding.UTF8.GetCharCount(source);
        Span<char> buffer = charCount <= 512
            ? stackalloc char[512].Slice(0, charCount)
            : new char[charCount];
        System.Text.Encoding.UTF8.GetChars(source, buffer);
        return Enum.TryParse(buffer, out result);
#else
        return Enum.TryParse(System.Text.Encoding.UTF8.GetString(source), out result);
#endif
    }

    private sealed class NoNamespaceStringParser : IEnumParser<int>
    {
        public static NoNamespaceStringParser Instance = new NoNamespaceStringParser();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int BitwiseOr(int value1, int value2) => unchecked((int)(value1 | value2));

        public bool TryParseNumber(ReadOnlySpan<char> value, out int result) => EnumNumericParser.TryParse(value, out result);

        public bool TryParseSingleName(ReadOnlySpan<char> value, bool ignoreCase, out int result)
        {
            return ignoreCase
                ? TryParse(value, out result)
                : TryParse(value, StringComparison.OrdinalIgnoreCase, out result);
        }

        public bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
        {
            return TryParse(value, comparisonType, out result);
        }

        private bool TryParse(ReadOnlySpan<char> value, out int result)
        {
            switch (value)
            {
                case "Zero":
                    result = 0;
                    return true;
                case "One":
                    result = 1;
                    return true;
                case "Two":
                    result = 2;
                    return true;
                default:
                    result = 0;
                    return false;
            }
        }

        private bool TryParse(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
        {
            switch (value)
            {
                case { } when value.Equals("Zero", comparisonType):
                    result = 0;
                    return true;
                case { } when value.Equals("One", comparisonType):
                    result = 1;
                    return true;
                case { } when value.Equals("Two", comparisonType):
                    result = 2;
                    return true;
                default:
                    result = 0;
                    return false;
            }
        }
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
    public static bool TryParse(
        [NotNullWhen(true)] string? name,
        StringComparison comparisonType,
        out NoNamespace result)
    {
        bool success = NoNamespaceStringParser.Instance.TryParseSingleName(name.AsSpan(), comparisonType, out int number)
            || NoNamespaceStringParser.Instance.TryParseNumber(name.AsSpan(), out number);
        if (!success)
        {
            return Enum.TryParse(name, out result);
        }

        result = (NoNamespace)number;
        return true;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="result">
    /// When this method returns, result contains an object of type NoNamespace whose value is represented by value
    /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
    /// underlying type of NoNamespace. Note that this value need not be a member of the NoNamespace enumeration.
    /// </param>
    /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
    public static bool TryParseIgnoreCase(
        [NotNullWhen(true)] string? name,
        out NoNamespace result)
    {
        return TryParse(name.AsSpan(), true, out result);
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <returns>
    /// Contains an object of type NoNamespace whose value is represented by value if the parse operation succeeds.
    /// If the parse operation fails, result contains <c>null</c> value.
    /// </returns>
    public static NoNamespace? TryParseIgnoreCase(string? name)
    {
        return TryParse(name.AsSpan(), true, out NoNamespace result) ? result : null;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more enumerated constants to
    /// an equivalent enumerated object.
    /// </summary>
    /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns>
    /// Contains an object of type NoNamespace whose value is represented by value if the parse operation succeeds.
    /// If the parse operation fails, result contains <c>null</c> value.
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
    public static NoNamespace? TryParse(string? name, StringComparison comparisonType)
    {
        return TryParse(name, comparisonType, out NoNamespace result) ? result : null;
    }

    /// <summary>Retrieves an array of the values of the constants in the NoNamespace enumeration.</summary>
    /// <returns>An array that contains the values of the constants in NoNamespace.</returns>
    public static NoNamespace[] GetValues()
    {
        return new[]
        {
            NoNamespace.Zero,
            NoNamespace.One,
            NoNamespace.Two,
        };
    }

    /// <summary>Retrieves an array of the names of the constants in NoNamespace enumeration.</summary>
    /// <returns>A string array of the names of the constants in NoNamespace.</returns>
    public static string[] GetNames()
    {
        return new[]
        {
            nameof(NoNamespace.Zero),
            nameof(NoNamespace.One),
            nameof(NoNamespace.Two),
        };
    }
}
