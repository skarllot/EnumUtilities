﻿// <auto-generated />
#nullable enable

using System;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static partial class CategoriesExtensions
    {
        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringFast(this Categories value)
        {
            return value switch
            {
                Categories.Electronics => nameof(Categories.Electronics),
                Categories.Food => nameof(Categories.Food),
                Categories.Automotive => nameof(Categories.Automotive),
                Categories.Arts => nameof(Categories.Arts),
                Categories.BeautyCare => nameof(Categories.BeautyCare),
                Categories.Fashion => nameof(Categories.Fashion),
                _ => value.ToString()
            };
        }

        /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(this Categories value)
        {
            return CategoriesValidation.IsDefined(value);
        }
    }
}
