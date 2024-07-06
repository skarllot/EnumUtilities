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
    public static partial class MyEnum3Factory
    {
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum3 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum3. Note that this value need not be a member of the MyEnum3 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType,
            out NestedInClass.MyEnum3 result)
        {
            int numValue;
            switch (name)
            {
                case { } s when s.Equals("Monday", comparisonType):
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
                case { } s when TryParseNumeric(s, comparisonType, out numValue):
                    break;
                default:
                    return Enum.TryParse(name, out result);
            }

            result = (NestedInClass.MyEnum3)numValue;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum3 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum3. Note that this value need not be a member of the MyEnum3 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            out NestedInClass.MyEnum3 result)
        {
            int numValue;
            switch (name)
            {
                case "Monday":
                    numValue = 0;
                    break;
                case "Tuesday":
                    numValue = 1;
                    break;
                case "Wednesday":
                    numValue = 2;
                    break;
                case "Thursday":
                    numValue = 3;
                    break;
                case "Friday":
                    numValue = 4;
                    break;
                case "Saturday":
                    numValue = 5;
                    break;
                case "Sunday":
                    numValue = 6;
                    break;
                case { } s when TryParseNumeric(s, StringComparison.Ordinal, out numValue):
                    break;
                default:
                    return Enum.TryParse(name, out result);
            }

            result = (NestedInClass.MyEnum3)numValue;
            return true;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="result">
        /// When this method returns, result contains an object of type MyEnum3 whose value is represented by value
        /// if the parse operation succeeds. If the parse operation fails, result contains the default value of the
        /// underlying type of MyEnum3. Note that this value need not be a member of the MyEnum3 enumeration.
        /// </param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseIgnoreCase(
            [NotNullWhen(true)] string? name,
            out NestedInClass.MyEnum3 result)
        {
            return TryParse(name, StringComparison.OrdinalIgnoreCase, out result);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type MyEnum3 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static NestedInClass.MyEnum3? TryParse(string? name)
        {
            return TryParse(name, out NestedInClass.MyEnum3 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <returns>
        /// Contains an object of type MyEnum3 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        public static NestedInClass.MyEnum3? TryParseIgnoreCase(string? name)
        {
            return TryParse(name, StringComparison.OrdinalIgnoreCase, out NestedInClass.MyEnum3 result) ? result : null;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to
        /// an equivalent enumerated object.
        /// </summary>
        /// <param name="name">The case-sensitive string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>
        /// Contains an object of type MyEnum3 whose value is represented by value if the parse operation succeeds.
        /// If the parse operation fails, result contains <c>null</c> value.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static NestedInClass.MyEnum3? TryParse(string? name, StringComparison comparisonType)
        {
            return TryParse(name, comparisonType, out NestedInClass.MyEnum3 result) ? result : null;
        }

        public static bool TryCreateFromDisplayShortName(
            [NotNullWhen(true)] string? displayShortName,
            StringComparison comparisonType,
            out NestedInClass.MyEnum3 result)
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

            result = (NestedInClass.MyEnum3)numValue;
            return true;
        }

        public static bool TryCreateFromDisplayShortName([NotNullWhen(true)] string? displayShortName, out NestedInClass.MyEnum3 result)
        {
            return TryCreateFromDisplayShortName(displayShortName, StringComparison.Ordinal, out result);
        }

        public static NestedInClass.MyEnum3? TryCreateFromDisplayShortName(string? displayShortName, StringComparison comparisonType)
        {
            return TryCreateFromDisplayShortName(displayShortName, comparisonType, out NestedInClass.MyEnum3 result) ? result : null;
        }

        public static NestedInClass.MyEnum3? TryCreateFromDisplayShortName(string? displayShortName)
        {
            return TryCreateFromDisplayShortName(displayShortName, StringComparison.Ordinal, out NestedInClass.MyEnum3 result) ? result : null;
        }

        public static bool TryCreateFromDisplayName(
            [NotNullWhen(true)] string? displayName,
            StringComparison comparisonType,
            out NestedInClass.MyEnum3 result)
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

            result = (NestedInClass.MyEnum3)numValue;
            return true;
        }

        public static bool TryCreateFromDisplayName([NotNullWhen(true)] string? displayName, out NestedInClass.MyEnum3 result)
        {
            return TryCreateFromDisplayName(displayName, StringComparison.Ordinal, out result);
        }

        public static NestedInClass.MyEnum3? TryCreateFromDisplayName(string? displayName, StringComparison comparisonType)
        {
            return TryCreateFromDisplayName(displayName, comparisonType, out NestedInClass.MyEnum3 result) ? result : null;
        }

        public static NestedInClass.MyEnum3? TryCreateFromDisplayName(string? displayName)
        {
            return TryCreateFromDisplayName(displayName, StringComparison.Ordinal, out NestedInClass.MyEnum3 result) ? result : null;
        }

        public static bool TryCreateFromDescription(
            [NotNullWhen(true)] string? description,
            StringComparison comparisonType,
            out NestedInClass.MyEnum3 result)
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

            result = (NestedInClass.MyEnum3)numValue;
            return true;
        }

        public static bool TryCreateFromDescription([NotNullWhen(true)] string? description, out NestedInClass.MyEnum3 result)
        {
            return TryCreateFromDescription(description, StringComparison.Ordinal, out result);
        }

        public static NestedInClass.MyEnum3? TryCreateFromDescription(string? description, StringComparison comparisonType)
        {
            return TryCreateFromDescription(description, comparisonType, out NestedInClass.MyEnum3 result) ? result : null;
        }

        public static NestedInClass.MyEnum3? TryCreateFromDescription(string? description)
        {
            return TryCreateFromDescription(description, StringComparison.Ordinal, out NestedInClass.MyEnum3 result) ? result : null;
        }

        /// <summary>Retrieves an array of the values of the constants in the MyEnum3 enumeration.</summary>
        /// <returns>An array that contains the values of the constants in MyEnum3.</returns>
        public static NestedInClass.MyEnum3[] GetValues()
        {
            return new[]
            {
                (NestedInClass.MyEnum3)0,
                (NestedInClass.MyEnum3)1,
                (NestedInClass.MyEnum3)2,
                (NestedInClass.MyEnum3)3,
                (NestedInClass.MyEnum3)4,
                (NestedInClass.MyEnum3)5,
                (NestedInClass.MyEnum3)6,
            };
        }

        /// <summary>Retrieves an array of the names of the constants in MyEnum3 enumeration.</summary>
        /// <returns>A string array of the names of the constants in MyEnum3.</returns>
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

        private static bool TryParseNumeric(
            string name,
            StringComparison comparisonType,
            out int result)
        {
            switch (comparisonType)
            {
                case StringComparison.CurrentCulture:
                case StringComparison.CurrentCultureIgnoreCase:
                    return int.TryParse(name, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
                case StringComparison.InvariantCulture:
                case StringComparison.InvariantCultureIgnoreCase:
                case StringComparison.Ordinal:
                case StringComparison.OrdinalIgnoreCase:
                    return int.TryParse(name, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out result);
                default:
                    return int.TryParse(name, out result);
            }
        }
    }
}
