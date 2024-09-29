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
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="value">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case; <see langword="false"/> to regard case.</param>
        /// <returns>The value represented by the specified name or numeric value. Note that this value need not be a member of the WeekDays enumeration.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is empty or does not represent a valid value.</exception>
        public static WeekDays Parse(string value, bool ignoreCase = false)
        {
            if (value is null) ThrowHelper.ThrowArgumentNullException(nameof(value));
            TryParseName(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
            return (WeekDays)result;
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
            TryParseName(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
            return (WeekDays)result;
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
            TryParseName(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: true, out var result);
            return (WeekDays)result;
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
            Unsafe.SkipInit(out result);
            return TryParseName(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<WeekDays, int>(ref result));
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
            Unsafe.SkipInit(out result);
            return TryParseName(value.AsSpan(), StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<WeekDays, int>(ref result));
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
            return TryParseName(value.AsSpan(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out var result) ? (WeekDays?)result : null;
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
            Unsafe.SkipInit(out result);
            return TryParseName(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<WeekDays, int>(ref result));
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
            Unsafe.SkipInit(out result);
            return TryParseName(value, StringComparison.Ordinal, throwOnFailure: false, out Unsafe.As<WeekDays, int>(ref result));
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
            return TryParseName(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal, throwOnFailure: false, out var result) ? (WeekDays?)result : null;
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
                case 'F':
                case 'f':
                    switch (value)
                    {
                        case { } when value.Equals("Friday", comparisonType):
                            result = 4;
                            return true;
                    }
                    break;
                case 'M':
                case 'm':
                    switch (value)
                    {
                        case { } when value.Equals("Monday", comparisonType):
                            result = 0;
                            return true;
                    }
                    break;
                case 'S':
                case 's':
                    switch (value)
                    {
                        case { } when value.Equals("Saturday", comparisonType):
                            result = 5;
                            return true;
                        case { } when value.Equals("Sunday", comparisonType):
                            result = 6;
                            return true;
                    }
                    break;
                case 'T':
                case 't':
                    switch (value)
                    {
                        case { } when value.Equals("Tuesday", comparisonType):
                            result = 1;
                            return true;
                        case { } when value.Equals("Thursday", comparisonType):
                            result = 3;
                            return true;
                    }
                    break;
                case 'W':
                case 'w':
                    switch (value)
                    {
                        case { } when value.Equals("Wednesday", comparisonType):
                            result = 2;
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
            Unsafe.SkipInit(out result);
            return TryParseName(name.AsSpan(), comparisonType, throwOnFailure: false, out Unsafe.As<WeekDays, int>(ref result));
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
            Unsafe.SkipInit(out result);
            return TryParseName(name.AsSpan(), StringComparison.OrdinalIgnoreCase, throwOnFailure: false, out Unsafe.As<WeekDays, int>(ref result));
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
            return TryParseName(name.AsSpan(), StringComparison.OrdinalIgnoreCase, throwOnFailure: false, out var result) ? (WeekDays?)result : null;
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
            return TryParseName(name.AsSpan(), comparisonType, throwOnFailure: false, out var result) ? (WeekDays?)result : null;
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
    }
}
