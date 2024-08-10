﻿// <auto-generated />
#nullable enable

using System;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities.Formatters;
using Raiqub.Generators.EnumUtilities.Parsers;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    public static partial class SeasonEnumInfo
    {
        /// <summary>Represents the largest possible number of characters produced by converting an <see cref="Season" /> value to string, based on defined members. This field is constant.</summary>
        public const int NameMaxCharsLength = 6;

        /// <summary>Provides support for formatting <see cref="Season"/> values.</summary>
        public sealed partial class StringFormatter : IEnumFormatter<int>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringFormatter"/> class.</summary>
            public static StringFormatter Instance = new StringFormatter();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetStringLengthForNumber(int value) => EnumNumericFormatter.GetStringLength(value);

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public string GetStringForNumber(int value) => value.ToString();

            /// <inheritdoc />
            public int? TryGetStringLengthForMember(int value)
            {
                return value switch
                {
                    1 => 6,
                    2 => 6,
                    3 => 6,
                    4 => 6,
                    _ => null
                };
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(int value)
            {
                return value switch
                {
                    1 => "Spring",
                    2 => "Summer",
                    3 => "Autumn",
                    4 => "Winter",
                    _ => null
                };
            }
        }

        /// <summary>Provides support for parsing <see cref="Season"/> values.</summary>
        public sealed partial class StringParser
            : IEnumParser<int>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringParser"/> class.</summary>
            public static StringParser Instance = new StringParser();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int BitwiseOr(int value1, int value2) => unchecked((int)(value1 | value2));

            /// <inheritdoc />
            public bool TryParseNumber(ReadOnlySpan<char> value, out int result) => EnumNumericParser.TryParse(value, out result);

            /// <inheritdoc />
            public bool TryParseSingleName(ReadOnlySpan<char> value, bool ignoreCase, out int result)
            {
                return ignoreCase
                    ? TryParse(value, out result)
                    : TryParse(value, StringComparison.OrdinalIgnoreCase, out result);
            }

            /// <inheritdoc />
            public bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                return TryParse(value, comparisonType, out result);
            }

            private bool TryParse(ReadOnlySpan<char> value, out int result)
            {
                switch (value)
                {
                    case { } when value.SequenceEqual("Spring".AsSpan()):
                        result = 1;
                        return true;
                    case { } when value.SequenceEqual("Summer".AsSpan()):
                        result = 2;
                        return true;
                    case { } when value.SequenceEqual("Autumn".AsSpan()):
                        result = 3;
                        return true;
                    case { } when value.SequenceEqual("Winter".AsSpan()):
                        result = 4;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }

            private bool TryParse(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                switch (value)
                {
                    case { } when value.Equals("Spring", comparisonType):
                        result = 1;
                        return true;
                    case { } when value.Equals("Summer", comparisonType):
                        result = 2;
                        return true;
                    case { } when value.Equals("Autumn", comparisonType):
                        result = 3;
                        return true;
                    case { } when value.Equals("Winter", comparisonType):
                        result = 4;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
