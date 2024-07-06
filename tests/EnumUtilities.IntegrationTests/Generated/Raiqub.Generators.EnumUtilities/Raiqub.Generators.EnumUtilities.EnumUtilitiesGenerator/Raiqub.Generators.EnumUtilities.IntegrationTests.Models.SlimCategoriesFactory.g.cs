﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.6.0.0")]
    public static partial class SlimCategoriesFactory
    {
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type SlimCategories whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of SlimCategories. Note that this value need not be a member of the SlimCategories enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType,
            out SlimCategories result)
        {
            byte numValue;
            switch (name)
            {
                case { } s when s.Equals("Electronics", comparisonType):
                    numValue = 0;
                    break;
                case { } s when s.Equals("Food", comparisonType):
                    numValue = 1;
                    break;
                case { } s when s.Equals("Automotive", comparisonType):
                    numValue = 2;
                    break;
                case { } s when s.Equals("Arts", comparisonType):
                    numValue = 3;
                    break;
                case { } s when s.Equals("BeautyCare", comparisonType):
                    numValue = 4;
                    break;
                case { } s when s.Equals("Fashion", comparisonType):
                    numValue = 5;
                    break;
                case { } s when TryParseNumeric(s, comparisonType, out numValue):
                    break;
                default:
                    return Enum.TryParse(name, out result);
            }

            result = (SlimCategories)numValue;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type SlimCategories whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of SlimCategories. Note that this value need not be a member of the SlimCategories enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            out SlimCategories result)
        {
            byte numValue;
            switch (name)
            {
                case "Electronics":
                    numValue = 0;
                    break;
                case "Food":
                    numValue = 1;
                    break;
                case "Automotive":
                    numValue = 2;
                    break;
                case "Arts":
                    numValue = 3;
                    break;
                case "BeautyCare":
                    numValue = 4;
                    break;
                case "Fashion":
                    numValue = 5;
                    break;
                case { } s when TryParseNumeric(s, StringComparison.Ordinal, out numValue):
                    break;
                default:
                    return Enum.TryParse(name, out result);
            }

            result = (SlimCategories)numValue;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type SlimCategories whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of SlimCategories. Note that this value need not be a member of the SlimCategories enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseIgnoreCase(
            [NotNullWhen(true)] string? name,
            out SlimCategories result)
        {
            return TryParse(name, StringComparison.OrdinalIgnoreCase, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type SlimCategories whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static SlimCategories? TryParse(string? name)
        {
            return TryParse(name, out SlimCategories result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type SlimCategories whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static SlimCategories? TryParseIgnoreCase(string? name)
        {
            return TryParse(name, StringComparison.OrdinalIgnoreCase, out SlimCategories result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>
        /// Contains an object of type SlimCategories whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static SlimCategories? TryParse(string? name, StringComparison comparisonType)
        {
            return TryParse(name, comparisonType, out SlimCategories result) ? result : null;
        }

        /// <summary>Retrieves an array of the values of the constants in the SlimCategories enumeration.</summary>
        /// <returns>An array that contains the values of the constants in SlimCategories.</returns>
        public static SlimCategories[] GetValues()
        {
            return new[]
            {
                (SlimCategories)0,
                (SlimCategories)1,
                (SlimCategories)2,
                (SlimCategories)3,
                (SlimCategories)4,
                (SlimCategories)5,
            };
        }

        /// <summary>Retrieves an array of the names of the constants in SlimCategories enumeration.</summary>
        /// <returns>A string array of the names of the constants in SlimCategories.</returns>
        public static string[] GetNames()
        {
            return new[]
            {
                "Electronics",
                "Food",
                "Automotive",
                "Arts",
                "BeautyCare",
                "Fashion",
            };
        }

        private static bool TryParseNumeric(
            string name,
            StringComparison comparisonType,
            out byte result)
        {
            switch (comparisonType)
            {
                case StringComparison.CurrentCulture:
                case StringComparison.CurrentCultureIgnoreCase:
                    return byte.TryParse(name, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
                case StringComparison.InvariantCulture:
                case StringComparison.InvariantCultureIgnoreCase:
                case StringComparison.Ordinal:
                case StringComparison.OrdinalIgnoreCase:
                    return byte.TryParse(name, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out result);
                default:
                    return byte.TryParse(name, out result);
            }
        }
    }
}
