﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.6.0.0")]
    internal static partial class MyEnum2Factory
    {
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse([NotNullWhen(true)] string? name, bool ignoreCase, out NestedInClass.MyEnum2 result)
        {
            return TryParse(name.AsSpan(), ignoreCase, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse([NotNullWhen(true)] string? name, out NestedInClass.MyEnum2 result)
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
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static NestedInClass.MyEnum2? TryParse(string? name, bool ignoreCase)
        {
            return TryParse(name.AsSpan(), ignoreCase, out NestedInClass.MyEnum2 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static NestedInClass.MyEnum2? TryParse(string? name)
        {
            return TryParse(name.AsSpan(), false, out NestedInClass.MyEnum2 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><c>true</c> to read <paramref name="source"/> in case insensitive mode; <c>false</c> to read value in case sensitive mode.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(ReadOnlySpan<char> source, bool ignoreCase, out NestedInClass.MyEnum2 result)
        {
            bool success = EnumStringParser.TryParse(source, MyEnum2StringParser.Instance, ignoreCase, false, out int number);
            if (!success)
            {
                result = 0;
                return false;
            }

            result = (NestedInClass.MyEnum2)number;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(ReadOnlySpan<char> source, out NestedInClass.MyEnum2 result)
        {
            return TryParse(source, false, out result);
        }

        /// <summary>
        /// Converts the UTF-8 representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The case-sensitive UTF-8 representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseUtf8(ReadOnlySpan<byte> source, out NestedInClass.MyEnum2 result)
        {
            if (source == "Credit"u8)
            {
                result = NestedInClass.MyEnum2.Credit;
                return true;
            }

            if (source == "Debit"u8)
            {
                result = NestedInClass.MyEnum2.Debit;
                return true;
            }

            if (source == "Cash"u8)
            {
                result = NestedInClass.MyEnum2.Cash;
                return true;
            }

            if (source == "Cheque"u8)
            {
                result = NestedInClass.MyEnum2.Cheque;
                return true;
            }

            if (source == "0"u8)
            {
                result = NestedInClass.MyEnum2.Credit;
                return true;
            }

            if (source == "1"u8)
            {
                result = NestedInClass.MyEnum2.Debit;
                return true;
            }

            if (source == "2"u8)
            {
                result = NestedInClass.MyEnum2.Cash;
                return true;
            }

            if (source == "3"u8)
            {
                result = NestedInClass.MyEnum2.Cheque;
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

        private sealed class MyEnum2StringParser : IEnumParser<int>
        {
            public static MyEnum2StringParser Instance = new MyEnum2StringParser();

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
                    case "Credit":
                        result = 0;
                        return true;
                    case "Debit":
                        result = 1;
                        return true;
                    case "Cash":
                        result = 2;
                        return true;
                    case "Cheque":
                        result = 3;
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
                    case { } when value.Equals("Credit", comparisonType):
                        result = 0;
                        return true;
                    case { } when value.Equals("Debit", comparisonType):
                        result = 1;
                        return true;
                    case { } when value.Equals("Cash", comparisonType):
                        result = 2;
                        return true;
                    case { } when value.Equals("Cheque", comparisonType):
                        result = 3;
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
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType,
            out NestedInClass.MyEnum2 result)
        {
            bool success = MyEnum2StringParser.Instance.TryParseSingleName(name.AsSpan(), comparisonType, out int number)
                || MyEnum2StringParser.Instance.TryParseNumber(name.AsSpan(), out number);
            if (!success)
            {
                return Enum.TryParse(name, out result);
            }

            result = (NestedInClass.MyEnum2)number;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseIgnoreCase(
            [NotNullWhen(true)] string? name,
            out NestedInClass.MyEnum2 result)
        {
            return TryParse(name.AsSpan(), true, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static NestedInClass.MyEnum2? TryParseIgnoreCase(string? name)
        {
            return TryParse(name.AsSpan(), true, out NestedInClass.MyEnum2 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static NestedInClass.MyEnum2? TryParse(string? name, StringComparison comparisonType)
        {
            return TryParse(name, comparisonType, out NestedInClass.MyEnum2 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the value associated with one enumerated constant to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="enumMemberValue">The value as defined with <see cref="System.Runtime.Serialization.EnumMemberAttribute"/>.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static bool TryParseFromEnumMemberValue(
            [NotNullWhen(true)] string? enumMemberValue,
            StringComparison comparisonType,
            out NestedInClass.MyEnum2 result)
        {
            switch (enumMemberValue)
            {
                case { } s when s.Equals("Credit card", comparisonType):
                    result = NestedInClass.MyEnum2.Credit;
                    return true;
                case { } s when s.Equals("Debit card", comparisonType):
                    result = NestedInClass.MyEnum2.Debit;
                    return true;
                case { } s when s.Equals(nameof(NestedInClass.MyEnum2.Cash), comparisonType):
                    result = NestedInClass.MyEnum2.Cash;
                    return true;
                case { } s when s.Equals(nameof(NestedInClass.MyEnum2.Cheque), comparisonType):
                    result = NestedInClass.MyEnum2.Cheque;
                    return true;
                default:
                    result = default;
                    return false;
            }
        }

        /// <summary>
        /// Converts the string representation of the value associated with one enumerated constant to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="enumMemberValue">The value as defined with <see cref="System.Runtime.Serialization.EnumMemberAttribute"/>.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseFromEnumMemberValue([NotNullWhen(true)] string? enumMemberValue, out NestedInClass.MyEnum2 result)
        {
            return TryParseFromEnumMemberValue(enumMemberValue, StringComparison.Ordinal, out result);
        }

        /// <summary>
        /// Converts the string representation of the value associated with one enumerated constant to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="enumMemberValue">The value as defined with <see cref="System.Runtime.Serialization.EnumMemberAttribute"/>.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains a null value.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static NestedInClass.MyEnum2? TryParseFromEnumMemberValue(string? enumMemberValue, StringComparison comparisonType)
        {
            return TryParseFromEnumMemberValue(enumMemberValue, comparisonType, out NestedInClass.MyEnum2 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the value associated with one enumerated constant to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="enumMemberValue">The value as defined with <see cref="System.Runtime.Serialization.EnumMemberAttribute"/>.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains a null value.
        /// </returns>
        public static NestedInClass.MyEnum2? TryParseFromEnumMemberValue(string? enumMemberValue)
        {
            return TryParseFromEnumMemberValue(enumMemberValue, StringComparison.Ordinal, out NestedInClass.MyEnum2 result) ? result : null;
        }

        public static bool TryCreateFromDescription(
            [NotNullWhen(true)] string? description,
            StringComparison comparisonType,
            out NestedInClass.MyEnum2 result)
        {
            switch (description)
            {
                case { } s when s.Equals("The payment by using physical cash", comparisonType):
                    result = NestedInClass.MyEnum2.Cash;
                    return true;
                default:
                    result = default;
                    return false;
            }
        }

        public static bool TryCreateFromDescription([NotNullWhen(true)] string? description, out NestedInClass.MyEnum2 result)
        {
            return TryCreateFromDescription(description, StringComparison.Ordinal, out result);
        }

        public static NestedInClass.MyEnum2? TryCreateFromDescription(string? description, StringComparison comparisonType)
        {
            return TryCreateFromDescription(description, comparisonType, out NestedInClass.MyEnum2 result) ? result : null;
        }

        public static NestedInClass.MyEnum2? TryCreateFromDescription(string? description)
        {
            return TryCreateFromDescription(description, StringComparison.Ordinal, out NestedInClass.MyEnum2 result) ? result : null;
        }

        public static bool TryCreateFromDisplayShortName(
            [NotNullWhen(true)] string? displayShortName,
            StringComparison comparisonType,
            out NestedInClass.MyEnum2 result)
        {
            switch (displayShortName)
            {
                default:
                    return TryCreateFromDisplayName(displayShortName, comparisonType, out result);
            }
        }

        public static bool TryCreateFromDisplayShortName([NotNullWhen(true)] string? displayShortName, out NestedInClass.MyEnum2 result)
        {
            return TryCreateFromDisplayShortName(displayShortName, StringComparison.Ordinal, out result);
        }

        public static NestedInClass.MyEnum2? TryCreateFromDisplayShortName(string? displayShortName, StringComparison comparisonType)
        {
            return TryCreateFromDisplayShortName(displayShortName, comparisonType, out NestedInClass.MyEnum2 result) ? result : null;
        }

        public static NestedInClass.MyEnum2? TryCreateFromDisplayShortName(string? displayShortName)
        {
            return TryCreateFromDisplayShortName(displayShortName, StringComparison.Ordinal, out NestedInClass.MyEnum2 result) ? result : null;
        }

        public static bool TryCreateFromDisplayName(
            [NotNullWhen(true)] string? displayName,
            StringComparison comparisonType,
            out NestedInClass.MyEnum2 result)
        {
            switch (displayName)
            {
                case { } s when s.Equals("Credit Card", comparisonType):
                    result = NestedInClass.MyEnum2.Credit;
                    return true;
                case { } s when s.Equals("Debit Card", comparisonType):
                    result = NestedInClass.MyEnum2.Debit;
                    return true;
                case { } s when s.Equals("Physical Cash", comparisonType):
                    result = NestedInClass.MyEnum2.Cash;
                    return true;
                case { } s when s.Equals(nameof(NestedInClass.MyEnum2.Cheque), comparisonType):
                    result = NestedInClass.MyEnum2.Cheque;
                    return true;
                default:
                    result = default;
                    return false;
            }
        }

        public static bool TryCreateFromDisplayName([NotNullWhen(true)] string? displayName, out NestedInClass.MyEnum2 result)
        {
            return TryCreateFromDisplayName(displayName, StringComparison.Ordinal, out result);
        }

        public static NestedInClass.MyEnum2? TryCreateFromDisplayName(string? displayName, StringComparison comparisonType)
        {
            return TryCreateFromDisplayName(displayName, comparisonType, out NestedInClass.MyEnum2 result) ? result : null;
        }

        public static NestedInClass.MyEnum2? TryCreateFromDisplayName(string? displayName)
        {
            return TryCreateFromDisplayName(displayName, StringComparison.Ordinal, out NestedInClass.MyEnum2 result) ? result : null;
        }

        /// <summary>Retrieves an array of the values of the constants in the MyEnum2 enumeration.</summary>
        /// <returns>An array that contains the values of the constants in MyEnum2.</returns>
        public static NestedInClass.MyEnum2[] GetValues()
        {
            return new[]
            {
                NestedInClass.MyEnum2.Credit,
                NestedInClass.MyEnum2.Debit,
                NestedInClass.MyEnum2.Cash,
                NestedInClass.MyEnum2.Cheque,
            };
        }

        /// <summary>Retrieves an array of the names of the constants in MyEnum2 enumeration.</summary>
        /// <returns>A string array of the names of the constants in MyEnum2.</returns>
        public static string[] GetNames()
        {
            return new[]
            {
                nameof(NestedInClass.MyEnum2.Credit),
                nameof(NestedInClass.MyEnum2.Debit),
                nameof(NestedInClass.MyEnum2.Cash),
                nameof(NestedInClass.MyEnum2.Cheque),
            };
        }
    }
}
