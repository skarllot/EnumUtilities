﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    public static partial class CategoriesFactory
    {
        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType,
            out Categories result)
        {
            switch (name)
            {
                case { } s when s.Equals(nameof(Categories.Electronics), comparisonType):
                    result = Categories.Electronics;
                    return true;
                case { } s when s.Equals(nameof(Categories.Food), comparisonType):
                    result = Categories.Food;
                    return true;
                case { } s when s.Equals(nameof(Categories.Automotive), comparisonType):
                    result = Categories.Automotive;
                    return true;
                case { } s when s.Equals(nameof(Categories.Arts), comparisonType):
                    result = Categories.Arts;
                    return true;
                case { } s when s.Equals(nameof(Categories.BeautyCare), comparisonType):
                    result = Categories.BeautyCare;
                    return true;
                case { } s when s.Equals(nameof(Categories.Fashion), comparisonType):
                    result = Categories.Fashion;
                    return true;
                case { } s when TryParseNumeric(s, comparisonType, out var val):
                    result = (Categories)val;
                    return true;
                default:
                    return Enum.TryParse(name, out result);
            }
        }

        public static bool TryParseIgnoreCase(
            [NotNullWhen(true)] string? name,
            out Categories result)
        {
            return TryParse(name, StringComparison.OrdinalIgnoreCase, out result);
        }

        public static bool TryParse(
            [NotNullWhen(true)] string? name,
            out Categories result)
        {
            switch (name)
            {
                case nameof(Categories.Electronics):
                    result = Categories.Electronics;
                    return true;
                case nameof(Categories.Food):
                    result = Categories.Food;
                    return true;
                case nameof(Categories.Automotive):
                    result = Categories.Automotive;
                    return true;
                case nameof(Categories.Arts):
                    result = Categories.Arts;
                    return true;
                case nameof(Categories.BeautyCare):
                    result = Categories.BeautyCare;
                    return true;
                case nameof(Categories.Fashion):
                    result = Categories.Fashion;
                    return true;
                case { } s when TryParseNumeric(s, StringComparison.Ordinal, out var val):
                    result = (Categories)val;
                    return true;
                default:
                    return Enum.TryParse(name, out result);
            }
        }

        public static Categories[] GetValues()
        {
            return new[]
            {
                Categories.Electronics,
                Categories.Food,
                Categories.Automotive,
                Categories.Arts,
                Categories.BeautyCare,
                Categories.Fashion,
            };
        }

        public static string[] GetNames()
        {
            return new[]
            {
                nameof(Categories.Electronics),
                nameof(Categories.Food),
                nameof(Categories.Automotive),
                nameof(Categories.Arts),
                nameof(Categories.BeautyCare),
                nameof(Categories.Fashion),
            };
        }

        private static bool TryParseNumeric(
            string name,
            StringComparison comparisonType,
            out Byte result)
        {
            switch (comparisonType)
            {
                case StringComparison.CurrentCulture:
                case StringComparison.CurrentCultureIgnoreCase:
                    return Byte.TryParse(name, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
                case StringComparison.InvariantCulture:
                case StringComparison.InvariantCultureIgnoreCase:
                case StringComparison.Ordinal:
                case StringComparison.OrdinalIgnoreCase:
                    return Byte.TryParse(name, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out result);
                default:
                    return Byte.TryParse(name, out result);
            }
        }
    }
}
