﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities.Parsers;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    internal static partial class MyEnum2Factory
    {
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the MyEnum2 enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static NestedInClass.MyEnum2 Parse(string value, bool ignoreCase = false)
        {
            if (value is null) ThrowArgumentNullException(nameof(value));
            TryParse(value.AsSpan(), ignoreCase, throwOnFailure: true, out var result);
            return result;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the MyEnum2 enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static NestedInClass.MyEnum2 Parse(ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            TryParse(value, ignoreCase, throwOnFailure: true, out var result);
            return result;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified name or numeric value or null. Note that this value need not be a member of the MyEnum2 enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        [return: NotNullIfNotNull("value")]
        public static NestedInClass.MyEnum2? ParseOrNull(string? value, bool ignoreCase = false)
        {
            if (value is null) return null;
            TryParse(value.AsSpan(), ignoreCase, throwOnFailure: true, out var result);
            return result;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse([NotNullWhen(true)] string? value, bool ignoreCase, out NestedInClass.MyEnum2 result)
        {
            return TryParse(value.AsSpan(), ignoreCase, throwOnFailure: false, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse([NotNullWhen(true)] string? value, out NestedInClass.MyEnum2 result)
        {
            return TryParse(value.AsSpan(), ignoreCase: false, throwOnFailure: false, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static NestedInClass.MyEnum2? TryParse(string? value, bool ignoreCase = false)
        {
            return TryParse(value.AsSpan(), ignoreCase, throwOnFailure: false, out NestedInClass.MyEnum2 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, out NestedInClass.MyEnum2 result)
        {
            return TryParse(value, ignoreCase, throwOnFailure: false, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(ReadOnlySpan<char> value, out NestedInClass.MyEnum2 result)
        {
            return TryParse(value, ignoreCase: false, throwOnFailure: false, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static NestedInClass.MyEnum2? TryParse(ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            return TryParse(value, ignoreCase, throwOnFailure: false, out NestedInClass.MyEnum2 result) ? result : null;
        }

        private static bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, bool throwOnFailure, out NestedInClass.MyEnum2 result)
        {
            bool success = EnumStringParser.TryParse(value, MyEnum2StringParser.Instance, ignoreCase, throwOnFailure, out int number);
            if (!success)
            {
                result = 0;
                return false;
            }

            result = (NestedInClass.MyEnum2)number;
            return true;
        }

        private sealed partial class MyEnum2StringParser : IEnumParser<int>
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
                    case { } when value.SequenceEqual("Credit".AsSpan()):
                        result = 0;
                        return true;
                    case { } when value.SequenceEqual("Debit".AsSpan()):
                        result = 1;
                        return true;
                    case { } when value.SequenceEqual("Cash".AsSpan()):
                        result = 2;
                        return true;
                    case { } when value.SequenceEqual("Cheque".AsSpan()):
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
        /// <param name="name">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
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
        /// <param name="name">The case-insensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum2 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum2. Note that this value need not be a member of the MyEnum2 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static bool TryParseIgnoreCase(
            [NotNullWhen(true)] string? name,
            out NestedInClass.MyEnum2 result)
        {
            return TryParse(name.AsSpan(), ignoreCase: true, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-insensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static NestedInClass.MyEnum2? TryParseIgnoreCase(string? name)
        {
            return TryParse(name.AsSpan(), ignoreCase: true, out NestedInClass.MyEnum2 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>
        /// Contains an object of type MyEnum2 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
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
            int numValue;
            switch (enumMemberValue)
            {
                case { } s when s.Equals("Credit card", comparisonType):
                    numValue = 0;
                    break;
                case { } s when s.Equals("Debit card", comparisonType):
                    numValue = 1;
                    break;
                case { } s when s.Equals("Cash", comparisonType):
                    numValue = 2;
                    break;
                case { } s when s.Equals("Cheque", comparisonType):
                    numValue = 3;
                    break;
                default:
                    result = default;
                    return false;
            }

            result = (NestedInClass.MyEnum2)numValue;
            return true;
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

        public static NestedInClass.MyEnum2 CreateFromDescription(string description, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (description is null) ThrowArgumentNullException(nameof(description));
            TryCreateFromDescription(description.AsSpan(), comparisonType, throwOnFailure: true, out var result);
            return result;
        }

        public static NestedInClass.MyEnum2 CreateFromDescription(ReadOnlySpan<char> description, StringComparison comparisonType = StringComparison.Ordinal)
        {
            TryCreateFromDescription(description, comparisonType, throwOnFailure: true, out var result);
            return result;
        }

        [return: NotNullIfNotNull("description")]
        public static NestedInClass.MyEnum2? CreateFromDescriptionOrNull(string? description, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (description is null) return null;
            TryCreateFromDescription(description.AsSpan(), comparisonType, throwOnFailure: true, out var result);
            return result;
        }

        public static bool TryCreateFromDescription([NotNullWhen(true)] string? description, StringComparison comparisonType, out NestedInClass.MyEnum2 result)
        {
            return TryCreateFromDescription(description.AsSpan(), comparisonType, throwOnFailure: false, out result);
        }

        public static bool TryCreateFromDescription([NotNullWhen(true)] string? description, out NestedInClass.MyEnum2 result)
        {
            return TryCreateFromDescription(description.AsSpan(), StringComparison.Ordinal, throwOnFailure: false, out result);
        }

        public static NestedInClass.MyEnum2? TryCreateFromDescription(string? description, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return TryCreateFromDescription(description.AsSpan(), comparisonType, throwOnFailure: false, out NestedInClass.MyEnum2 result) ? result : null;
        }

        public static bool TryCreateFromDescription(ReadOnlySpan<char> description, StringComparison comparisonType, out NestedInClass.MyEnum2 result)
        {
            return TryCreateFromDescription(description, comparisonType, throwOnFailure: false, out result);
        }

        public static bool TryCreateFromDescription(ReadOnlySpan<char> description, out NestedInClass.MyEnum2 result)
        {
            return TryCreateFromDescription(description, StringComparison.Ordinal, throwOnFailure: false, out result);
        }

        public static NestedInClass.MyEnum2? TryCreateFromDescription(ReadOnlySpan<char> description, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return TryCreateFromDescription(description, comparisonType, throwOnFailure: false, out NestedInClass.MyEnum2 result) ? result : null;
        }

        private static bool TryCreateFromDescription(ReadOnlySpan<char> description, StringComparison comparisonType, bool throwOnFailure, out NestedInClass.MyEnum2 result)
        {
            bool success = EnumStringParser.TryParseDescription(description, MyEnum2StringParser.Instance, comparisonType, throwOnFailure, out int number);
            if (!success)
            {
                result = 0;
                return false;
            }

            result = (NestedInClass.MyEnum2)number;
            return true;
        }

        private sealed partial class MyEnum2StringParser : IEnumDescriptionParser<int>
        {
            public bool TryParseDescription(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                switch (value)
                {
                    case { } s when s.Equals("The payment by using physical cash", comparisonType):
                        result = 2;
                        return true;
                    default:
                        result = default;
                        return false;
                }
            }
        }

        public static bool TryCreateFromDisplayShortName(
            [NotNullWhen(true)] string? displayShortName,
            StringComparison comparisonType,
            out NestedInClass.MyEnum2 result)
        {
            return TryCreateFromDisplayName(displayShortName, comparisonType, out result);
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
            int numValue;
            switch (displayName)
            {
                case { } s when s.Equals("Credit Card", comparisonType):
                    numValue = 0;
                    break;
                case { } s when s.Equals("Debit Card", comparisonType):
                    numValue = 1;
                    break;
                case { } s when s.Equals("Physical Cash", comparisonType):
                    numValue = 2;
                    break;
                case { } s when s.Equals("Cheque", comparisonType):
                    numValue = 3;
                    break;
                default:
                    result = default;
                    return false;
            }

            result = (NestedInClass.MyEnum2)numValue;
            return true;
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
                (NestedInClass.MyEnum2)0,
                (NestedInClass.MyEnum2)1,
                (NestedInClass.MyEnum2)2,
                (NestedInClass.MyEnum2)3,
            };
        }

        /// <summary>Retrieves an array of the names of the constants in MyEnum2 enumeration.</summary>
        /// <returns>A string array of the names of the constants in MyEnum2.</returns>
        public static string[] GetNames()
        {
            return new[]
            {
                "Credit",
                "Debit",
                "Cash",
                "Cheque",
            };
        }

        [DoesNotReturn]
        internal static void ThrowArgumentNullException(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}
