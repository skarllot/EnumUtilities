﻿// <auto-generated />
#nullable enable

using System;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities.Formatters;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    internal static partial class ErrorCodeEnumInfo
    {
        /// <summary>Represents the largest possible number of characters produced by converting an <see cref="ErrorCode" /> value to string, based on defined members. This field is constant.</summary>
        public const int NameMaxCharsLength = 14;

        /// <summary>Provides support for formatting <see cref="ErrorCode"/> values.</summary>
        public sealed partial class StringFormatter : IEnumFormatter<ushort>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringFormatter"/> class.</summary>
            public static StringFormatter Instance = new StringFormatter();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetStringCountForNumber(ushort value) => EnumNumericFormatter.GetStringLength(value);

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public string GetStringForNumber(ushort value) => value.ToString();

            /// <inheritdoc />
            public int? TryGetStringCountForMember(ushort value)
            {
                return value switch
                {
                    0 => 4,
                    1 => 7,
                    100 => 14,
                    200 => 14,
                    _ => null
                };
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(ushort value)
            {
                return value switch
                {
                    0 => "None",
                    1 => "Unknown",
                    100 => "ConnectionLost",
                    200 => "OutlierReading",
                    _ => null
                };
            }
        }
    }
}
