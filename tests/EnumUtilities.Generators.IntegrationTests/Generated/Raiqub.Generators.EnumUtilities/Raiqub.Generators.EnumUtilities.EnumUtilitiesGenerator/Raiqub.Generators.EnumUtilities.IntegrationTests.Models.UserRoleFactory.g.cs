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
    public static partial class UserRoleFactory
    {
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the UserRole enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static UserRole Parse(string value, bool ignoreCase = false)
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
        /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the UserRole enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static UserRole Parse(ReadOnlySpan<char> value, bool ignoreCase = false)
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
        /// <returns>The value represented by the specified name or numeric value or null. Note that this value need not be a member of the UserRole enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        [return: NotNullIfNotNull("value")]
        public static UserRole? ParseOrNull(string? value, bool ignoreCase = false)
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
        /// When this method returns, result contains an object of type UserRole whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of UserRole. Note that this value need not be a member of the UserRole enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse([NotNullWhen(true)] string? value, bool ignoreCase, out UserRole result)
        {
            return TryParse(value.AsSpan(), ignoreCase, throwOnFailure: false, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type UserRole whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of UserRole. Note that this value need not be a member of the UserRole enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse([NotNullWhen(true)] string? value, out UserRole result)
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
        /// Contains an object of type UserRole whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static UserRole? TryParse(string? value, bool ignoreCase = false)
        {
            return TryParse(value.AsSpan(), ignoreCase, throwOnFailure: false, out UserRole result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type UserRole whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of UserRole. Note that this value need not be a member of the UserRole enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, out UserRole result)
        {
            return TryParse(value, ignoreCase, throwOnFailure: false, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type UserRole whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of UserRole. Note that this value need not be a member of the UserRole enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(ReadOnlySpan<char> value, out UserRole result)
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
        /// Contains an object of type UserRole whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static UserRole? TryParse(ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            return TryParse(value, ignoreCase, throwOnFailure: false, out UserRole result) ? result : null;
        }

        private static bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, bool throwOnFailure, out UserRole result)
        {
            bool success = EnumStringParser.TryParse(value, UserRoleStringParser.Instance, ignoreCase, throwOnFailure, out ulong number);
            if (!success)
            {
                result = 0;
                return false;
            }

            result = (UserRole)number;
            return true;
        }

        private sealed partial class UserRoleStringParser : IEnumParser<ulong>
        {
            public static UserRoleStringParser Instance = new UserRoleStringParser();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ulong BitwiseOr(ulong value1, ulong value2) => unchecked((ulong)(value1 | value2));

            public bool TryParseNumber(ReadOnlySpan<char> value, out ulong result) => EnumNumericParser.TryParse(value, out result);

            public bool TryParseSingleName(ReadOnlySpan<char> value, bool ignoreCase, out ulong result)
            {
                return ignoreCase
                    ? TryParse(value, out result)
                    : TryParse(value, StringComparison.OrdinalIgnoreCase, out result);
            }

            public bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out ulong result)
            {
                return TryParse(value, comparisonType, out result);
            }

            private bool TryParse(ReadOnlySpan<char> value, out ulong result)
            {
                switch (value)
                {
                    case "None":
                        result = 0;
                        return true;
                    case "NormalUser":
                        result = 1;
                        return true;
                    case "Custodian":
                        result = 2;
                        return true;
                    case "Finance":
                        result = 4;
                        return true;
                    case "SuperUser":
                        result = 6;
                        return true;
                    case "All":
                        result = 7;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }

            private bool TryParse(ReadOnlySpan<char> value, StringComparison comparisonType, out ulong result)
            {
                switch (value)
                {
                    case { } when value.Equals("None", comparisonType):
                        result = 0;
                        return true;
                    case { } when value.Equals("NormalUser", comparisonType):
                        result = 1;
                        return true;
                    case { } when value.Equals("Custodian", comparisonType):
                        result = 2;
                        return true;
                    case { } when value.Equals("Finance", comparisonType):
                        result = 4;
                        return true;
                    case { } when value.Equals("SuperUser", comparisonType):
                        result = 6;
                        return true;
                    case { } when value.Equals("All", comparisonType):
                        result = 7;
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
        /// When this method returns, result contains an object of type UserRole whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of UserRole. Note that this value need not be a member of the UserRole enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType,
            out UserRole result)
        {
            bool success = UserRoleStringParser.Instance.TryParseSingleName(name.AsSpan(), comparisonType, out ulong number)
                || UserRoleStringParser.Instance.TryParseNumber(name.AsSpan(), out number);
            if (!success)
            {
                return Enum.TryParse(name, out result);
            }

            result = (UserRole)number;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-insensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type UserRole whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of UserRole. Note that this value need not be a member of the UserRole enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static bool TryParseIgnoreCase(
            [NotNullWhen(true)] string? name,
            out UserRole result)
        {
            return TryParse(name.AsSpan(), ignoreCase: true, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-insensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type UserRole whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static UserRole? TryParseIgnoreCase(string? name)
        {
            return TryParse(name.AsSpan(), ignoreCase: true, out UserRole result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>
        /// Contains an object of type UserRole whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static UserRole? TryParse(string? name, StringComparison comparisonType)
        {
            return TryParse(name, comparisonType, out UserRole result) ? result : null;
        }

        /// <summary>Retrieves an array of the values of the constants in the UserRole enumeration.</summary>
        /// <returns>An array that contains the values of the constants in UserRole.</returns>
        public static UserRole[] GetValues()
        {
            return new[]
            {
                (UserRole)0,
                (UserRole)1,
                (UserRole)2,
                (UserRole)4,
                (UserRole)6,
                (UserRole)7,
            };
        }

        /// <summary>Retrieves an array of the names of the constants in UserRole enumeration.</summary>
        /// <returns>A string array of the names of the constants in UserRole.</returns>
        public static string[] GetNames()
        {
            return new[]
            {
                "None",
                "NormalUser",
                "Custodian",
                "Finance",
                "SuperUser",
                "All",
            };
        }

        [DoesNotReturn]
        internal static void ThrowArgumentNullException(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}