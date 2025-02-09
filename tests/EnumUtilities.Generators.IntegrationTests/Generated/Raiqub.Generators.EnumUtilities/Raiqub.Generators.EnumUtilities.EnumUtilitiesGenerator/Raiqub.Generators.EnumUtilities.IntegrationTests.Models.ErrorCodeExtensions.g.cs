﻿// <auto-generated />
#nullable enable

using System;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities.Formatters;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.10.0.0")]
    internal static partial class ErrorCodeExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string? ToJsonString(this ErrorCode value)
        {
            return GetJsonStringInlined((ushort)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? GetJsonStringLength(this ErrorCode value)
        {
            return GetJsonStringLengthInlined((ushort)value);
        }

        private static int? GetJsonStringLengthInlined(ushort value)
        {
            return value switch
            {
                0 => 3,
                1 => 3,
                100 => 3,
                200 => 3,
                _ => null
            };
        }

        private static string? GetJsonStringInlined(ushort value)
        {
            return value switch
            {
                0 => "NON",
                1 => "UNK",
                100 => "CNX",
                200 => "OUT",
                _ => null
            };
        }
    }
}
