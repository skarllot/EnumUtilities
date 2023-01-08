﻿//HintName: ColourExtensions.g.cs
// <auto-generated />
#nullable enable

using System;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace TestNamespace
{
    public static partial class ColourExtensions
    {
        public static string ToStringFast(this Colour value)
        {
            return value switch
            {
                Colour.Red => nameof(Colour.Red),
                Colour.Blue => nameof(Colour.Blue),
                _ => value.ToString()
            };
        }

        public static bool IsDefined(this Colour value)
        {
            return ColourValidation.IsDefined(value);
        }
    }
}
