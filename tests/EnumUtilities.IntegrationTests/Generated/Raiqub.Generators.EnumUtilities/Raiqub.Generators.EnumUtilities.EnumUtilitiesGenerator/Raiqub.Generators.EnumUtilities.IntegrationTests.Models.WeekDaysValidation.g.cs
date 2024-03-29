﻿// <auto-generated />
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.6.0.0")]
    public static partial class WeekDaysValidation
    {
        /// <summary>Returns a boolean telling whether the value of <see cref="WeekDays"/> instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of <see cref="WeekDays"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(WeekDays value)
        {
            return value switch
            {
                WeekDays.Monday => true,
                WeekDays.Tuesday => true,
                WeekDays.Wednesday => true,
                WeekDays.Thursday => true,
                WeekDays.Friday => true,
                WeekDays.Saturday => true,
                WeekDays.Sunday => true,
                _ => false
            };
        }

        public static bool IsDefined(
            [NotNullWhen(true)] string? name,
            StringComparison comparisonType)
        {
            return name switch
            {
                { } s when s.Equals(nameof(WeekDays.Monday), comparisonType) => true,
                { } s when s.Equals(nameof(WeekDays.Tuesday), comparisonType) => true,
                { } s when s.Equals(nameof(WeekDays.Wednesday), comparisonType) => true,
                { } s when s.Equals(nameof(WeekDays.Thursday), comparisonType) => true,
                { } s when s.Equals(nameof(WeekDays.Friday), comparisonType) => true,
                { } s when s.Equals(nameof(WeekDays.Saturday), comparisonType) => true,
                { } s when s.Equals(nameof(WeekDays.Sunday), comparisonType) => true,
                _ => false
            };
        }

        public static bool IsDefinedIgnoreCase([NotNullWhen(true)] string? name)
        {
            return IsDefined(name, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsDefined([NotNullWhen(true)] string? name)
        {
            return name switch
            {
                nameof(WeekDays.Monday) => true,
                nameof(WeekDays.Tuesday) => true,
                nameof(WeekDays.Wednesday) => true,
                nameof(WeekDays.Thursday) => true,
                nameof(WeekDays.Friday) => true,
                nameof(WeekDays.Saturday) => true,
                nameof(WeekDays.Sunday) => true,
                _ => false
            };
        }
    }
}
