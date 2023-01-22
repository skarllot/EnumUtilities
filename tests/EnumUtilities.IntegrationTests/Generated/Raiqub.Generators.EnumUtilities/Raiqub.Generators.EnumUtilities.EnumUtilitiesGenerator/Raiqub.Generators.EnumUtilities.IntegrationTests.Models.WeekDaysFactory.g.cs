﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    public static partial class WeekDaysFactory
    {
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType,
            out WeekDays result)
        {
            switch (name)
            {
                case { } s when s.Equals(nameof(WeekDays.Monday), comparisonType):
                    result = WeekDays.Monday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Tuesday), comparisonType):
                    result = WeekDays.Tuesday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Wednesday), comparisonType):
                    result = WeekDays.Wednesday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Thursday), comparisonType):
                    result = WeekDays.Thursday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Friday), comparisonType):
                    result = WeekDays.Friday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Saturday), comparisonType):
                    result = WeekDays.Saturday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Sunday), comparisonType):
                    result = WeekDays.Sunday;
                    return true;
                case { } s when TryParseNumeric(s, comparisonType, out var val):
                    result = (WeekDays)val;
                    return true;
                default:
                    return Enum.TryParse(name, out result);
            }
        }

        public static bool TryParseIgnoreCase(
            [NotNullWhen(true)] string? name,
            out WeekDays result)
        {
            return TryParse(name, StringComparison.OrdinalIgnoreCase, out result);
        }

        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            out WeekDays result)
        {
            switch (name)
            {
                case nameof(WeekDays.Monday):
                    result = WeekDays.Monday;
                    return true;
                case nameof(WeekDays.Tuesday):
                    result = WeekDays.Tuesday;
                    return true;
                case nameof(WeekDays.Wednesday):
                    result = WeekDays.Wednesday;
                    return true;
                case nameof(WeekDays.Thursday):
                    result = WeekDays.Thursday;
                    return true;
                case nameof(WeekDays.Friday):
                    result = WeekDays.Friday;
                    return true;
                case nameof(WeekDays.Saturday):
                    result = WeekDays.Saturday;
                    return true;
                case nameof(WeekDays.Sunday):
                    result = WeekDays.Sunday;
                    return true;
                case { } s when TryParseNumeric(s, StringComparison.Ordinal, out var val):
                    result = (WeekDays)val;
                    return true;
                default:
                    return Enum.TryParse(name, out result);
            }
        }

        public static bool TryCreateFromDisplayShortName(
            [NotNullWhen(true)] string? displayShortName,
            StringComparison comparisonType,
            out WeekDays result)
        {
            switch (displayShortName)
            {
                case { } s when s.Equals(Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayShort, comparisonType):
                    result = WeekDays.Monday;
                    return true;
                case { } s when s.Equals("Tue", comparisonType):
                    result = WeekDays.Tuesday;
                    return true;
                case { } s when s.Equals("Fri", comparisonType):
                    result = WeekDays.Friday;
                    return true;
                case { } s when s.Equals("Sat", comparisonType):
                    result = WeekDays.Saturday;
                    return true;
                default:
                    return TryCreateFromDisplayName(displayShortName, comparisonType, out result);
            }
        }

        public static bool TryCreateFromDisplayName(
            [NotNullWhen(true)] string? displayName,
            StringComparison comparisonType,
            out WeekDays result)
        {
            switch (displayName)
            {
                case { } s when s.Equals(Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayFull, comparisonType):
                    result = WeekDays.Monday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Tuesday), comparisonType):
                    result = WeekDays.Tuesday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Wednesday), comparisonType):
                    result = WeekDays.Wednesday;
                    return true;
                case { } s when s.Equals("Thursday", comparisonType):
                    result = WeekDays.Thursday;
                    return true;
                case { } s when s.Equals("Friday", comparisonType):
                    result = WeekDays.Friday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Saturday), comparisonType):
                    result = WeekDays.Saturday;
                    return true;
                case { } s when s.Equals(nameof(WeekDays.Sunday), comparisonType):
                    result = WeekDays.Sunday;
                    return true;
                default:
                    result = default;
                    return false;
            }
        }

        public static bool TryCreateFromDescription(
            [NotNullWhen(true)] string? description,
            StringComparison comparisonType,
            out WeekDays result)
        {
            switch (description)
            {
                case { } s when s.Equals(Raiqub.Generators.EnumUtilities.IntegrationTests.Strings.MondayDescription, comparisonType):
                    result = WeekDays.Monday;
                    return true;
                case { } s when s.Equals("Almost the last day of the week", comparisonType):
                    result = WeekDays.Saturday;
                    return true;
                case { } s when s.Equals("The last day of the week", comparisonType):
                    result = WeekDays.Sunday;
                    return true;
                default:
                    result = default;
                    return false;
            }
        }

        public static WeekDays[] GetValues()
        {
            return new[]
            {
                WeekDays.Monday,
                WeekDays.Tuesday,
                WeekDays.Wednesday,
                WeekDays.Thursday,
                WeekDays.Friday,
                WeekDays.Saturday,
                WeekDays.Sunday,
            };
        }

        public static string[] GetNames()
        {
            return new[]
            {
                nameof(WeekDays.Monday),
                nameof(WeekDays.Tuesday),
                nameof(WeekDays.Wednesday),
                nameof(WeekDays.Thursday),
                nameof(WeekDays.Friday),
                nameof(WeekDays.Saturday),
                nameof(WeekDays.Sunday),
            };
        }

        private static bool TryParseNumeric(
            string name,
            StringComparison comparisonType,
            out Int32 result)
        {
            switch (comparisonType)
            {
                case StringComparison.CurrentCulture:
                case StringComparison.CurrentCultureIgnoreCase:
                    return Int32.TryParse(name, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
                case StringComparison.InvariantCulture:
                case StringComparison.InvariantCultureIgnoreCase:
                case StringComparison.Ordinal:
                case StringComparison.OrdinalIgnoreCase:
                    return Int32.TryParse(name, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out result);
                default:
                    return Int32.TryParse(name, out result);
            }
        }
    }
}
