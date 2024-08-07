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
    public static partial class WeekDaysFactory
    {
        private static readonly WeekDaysEnumInfo.StringParser s_stringParser = WeekDaysEnumInfo.StringParser.Instance;

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the WeekDays enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static WeekDays Parse(string value, bool ignoreCase = false)
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
        /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the WeekDays enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static WeekDays Parse(ReadOnlySpan<char> value, bool ignoreCase = false)
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
        /// <returns>The value represented by the specified name or numeric value or null. Note that this value need not be a member of the WeekDays enumeration.</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        [return: NotNullIfNotNull("value")]
        public static WeekDays? ParseOrNull(string? value, bool ignoreCase = false)
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
        /// When this method returns, result contains an object of type WeekDays whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of WeekDays. Note that this value need not be a member of the WeekDays enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse([NotNullWhen(true)] string? value, bool ignoreCase, out WeekDays result)
        {
            return TryParse(value.AsSpan(), ignoreCase, throwOnFailure: false, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type WeekDays whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of WeekDays. Note that this value need not be a member of the WeekDays enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse([NotNullWhen(true)] string? value, out WeekDays result)
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
        /// Contains an object of type WeekDays whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static WeekDays? TryParse(string? value, bool ignoreCase = false)
        {
            return TryParse(value.AsSpan(), ignoreCase, throwOnFailure: false, out WeekDays result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type WeekDays whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of WeekDays. Note that this value need not be a member of the WeekDays enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, out WeekDays result)
        {
            return TryParse(value, ignoreCase, throwOnFailure: false, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type WeekDays whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of WeekDays. Note that this value need not be a member of the WeekDays enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(ReadOnlySpan<char> value, out WeekDays result)
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
        /// Contains an object of type WeekDays whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static WeekDays? TryParse(ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            return TryParse(value, ignoreCase, throwOnFailure: false, out WeekDays result) ? result : null;
        }

        private static bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, bool throwOnFailure, out WeekDays result)
        {
            bool success = EnumStringParser.TryParse(value, s_stringParser, ignoreCase, throwOnFailure, out int number);
            if (!success)
            {
                result = 0;
                return false;
            }

            result = (WeekDays)number;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type WeekDays whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of WeekDays. Note that this value need not be a member of the WeekDays enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType,
            out WeekDays result)
        {
            bool success = s_stringParser.TryParseSingleName(name.AsSpan(), comparisonType, out int number)
                || s_stringParser.TryParseNumber(name.AsSpan(), out number);
            if (!success)
            {
                return Enum.TryParse(name, out result);
            }

            result = (WeekDays)number;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-insensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type WeekDays whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of WeekDays. Note that this value need not be a member of the WeekDays enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static bool TryParseIgnoreCase(
            [NotNullWhen(true)] string? name,
            out WeekDays result)
        {
            return TryParse(name.AsSpan(), ignoreCase: true, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-insensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type WeekDays whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static WeekDays? TryParseIgnoreCase(string? name)
        {
            return TryParse(name.AsSpan(), ignoreCase: true, out WeekDays result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>
        /// Contains an object of type WeekDays whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        [Obsolete("Use TryParse overload with 'ignoreCase' parameter")]
        public static WeekDays? TryParse(string? name, StringComparison comparisonType)
        {
            return TryParse(name, comparisonType, out WeekDays result) ? result : null;
        }

        public static bool TryCreateFromDisplayShortName(
            [NotNullWhen(true)] string? displayShortName,
            StringComparison comparisonType,
            out WeekDays result)
        {
            int numValue;
            switch (displayShortName)
            {
                case { } s when s.Equals(Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayShort, comparisonType):
                    numValue = 0;
                    break;
                case { } s when s.Equals("Tue", comparisonType):
                    numValue = 1;
                    break;
                case { } s when s.Equals("Fri", comparisonType):
                    numValue = 4;
                    break;
                case { } s when s.Equals("Sat", comparisonType):
                    numValue = 5;
                    break;
                default:
                    return TryCreateFromDisplayName(displayShortName, comparisonType, out result);
            }

            result = (WeekDays)numValue;
            return true;
        }

        public static bool TryCreateFromDisplayShortName([NotNullWhen(true)] string? displayShortName, out WeekDays result)
        {
            return TryCreateFromDisplayShortName(displayShortName, StringComparison.Ordinal, out result);
        }

        public static WeekDays? TryCreateFromDisplayShortName(string? displayShortName, StringComparison comparisonType)
        {
            return TryCreateFromDisplayShortName(displayShortName, comparisonType, out WeekDays result) ? result : null;
        }

        public static WeekDays? TryCreateFromDisplayShortName(string? displayShortName)
        {
            return TryCreateFromDisplayShortName(displayShortName, StringComparison.Ordinal, out WeekDays result) ? result : null;
        }

        public static bool TryCreateFromDisplayName(
            [NotNullWhen(true)] string? displayName,
            StringComparison comparisonType,
            out WeekDays result)
        {
            int numValue;
            switch (displayName)
            {
                case { } s when s.Equals(Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayFull, comparisonType):
                    numValue = 0;
                    break;
                case { } s when s.Equals("Tuesday", comparisonType):
                    numValue = 1;
                    break;
                case { } s when s.Equals("Wednesday", comparisonType):
                    numValue = 2;
                    break;
                case { } s when s.Equals("Thursday", comparisonType):
                    numValue = 3;
                    break;
                case { } s when s.Equals("Friday", comparisonType):
                    numValue = 4;
                    break;
                case { } s when s.Equals("Saturday", comparisonType):
                    numValue = 5;
                    break;
                case { } s when s.Equals("Sunday", comparisonType):
                    numValue = 6;
                    break;
                default:
                    result = default;
                    return false;
            }

            result = (WeekDays)numValue;
            return true;
        }

        public static bool TryCreateFromDisplayName([NotNullWhen(true)] string? displayName, out WeekDays result)
        {
            return TryCreateFromDisplayName(displayName, StringComparison.Ordinal, out result);
        }

        public static WeekDays? TryCreateFromDisplayName(string? displayName, StringComparison comparisonType)
        {
            return TryCreateFromDisplayName(displayName, comparisonType, out WeekDays result) ? result : null;
        }

        public static WeekDays? TryCreateFromDisplayName(string? displayName)
        {
            return TryCreateFromDisplayName(displayName, StringComparison.Ordinal, out WeekDays result) ? result : null;
        }

        public static bool TryCreateFromDescription(
            [NotNullWhen(true)] string? description,
            StringComparison comparisonType,
            out WeekDays result)
        {
            int numValue;
            switch (description)
            {
                case { } s when s.Equals(Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayDescription, comparisonType):
                    numValue = 0;
                    break;
                case { } s when s.Equals("Almost the last day of the week", comparisonType):
                    numValue = 5;
                    break;
                case { } s when s.Equals("The last day of the week", comparisonType):
                    numValue = 6;
                    break;
                default:
                    result = default;
                    return false;
            }

            result = (WeekDays)numValue;
            return true;
        }

        public static bool TryCreateFromDescription([NotNullWhen(true)] string? description, out WeekDays result)
        {
            return TryCreateFromDescription(description, StringComparison.Ordinal, out result);
        }

        public static WeekDays? TryCreateFromDescription(string? description, StringComparison comparisonType)
        {
            return TryCreateFromDescription(description, comparisonType, out WeekDays result) ? result : null;
        }

        public static WeekDays? TryCreateFromDescription(string? description)
        {
            return TryCreateFromDescription(description, StringComparison.Ordinal, out WeekDays result) ? result : null;
        }

        /// <summary>Retrieves an array of the values of the constants in the WeekDays enumeration.</summary>
        /// <returns>An array that contains the values of the constants in WeekDays.</returns>
        public static WeekDays[] GetValues()
        {
            return new[]
            {
                (WeekDays)0,
                (WeekDays)1,
                (WeekDays)2,
                (WeekDays)3,
                (WeekDays)4,
                (WeekDays)5,
                (WeekDays)6,
            };
        }

        /// <summary>Retrieves an array of the names of the constants in WeekDays enumeration.</summary>
        /// <returns>A string array of the names of the constants in WeekDays.</returns>
        public static string[] GetNames()
        {
            return new[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };
        }

        [DoesNotReturn]
        private static void ThrowArgumentNullException(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}
