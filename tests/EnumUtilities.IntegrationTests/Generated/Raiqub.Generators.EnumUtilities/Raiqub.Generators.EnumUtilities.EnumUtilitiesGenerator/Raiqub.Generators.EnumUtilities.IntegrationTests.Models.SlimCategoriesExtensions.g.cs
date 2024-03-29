﻿// <auto-generated />
#nullable enable

using System;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.6.0.0")]
    public static partial class SlimCategoriesExtensions
    {
        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringFast(this SlimCategories value)
        {
            return value switch
            {
                SlimCategories.Electronics => nameof(SlimCategories.Electronics),
                SlimCategories.Food => nameof(SlimCategories.Food),
                SlimCategories.Automotive => nameof(SlimCategories.Automotive),
                SlimCategories.Arts => nameof(SlimCategories.Arts),
                SlimCategories.BeautyCare => nameof(SlimCategories.BeautyCare),
                SlimCategories.Fashion => nameof(SlimCategories.Fashion),
                _ => value.ToString()
            };
        }

        /// <summary>Returns a boolean telling whether the value of this instance exists in the enumeration.</summary>
        /// <returns><c>true</c> if the value of this instance exists in the enumeration; <c>false</c> otherwise.</returns>
        public static bool IsDefined(this SlimCategories value)
        {
            return SlimCategoriesValidation.IsDefined(value);
        }
    }
}
