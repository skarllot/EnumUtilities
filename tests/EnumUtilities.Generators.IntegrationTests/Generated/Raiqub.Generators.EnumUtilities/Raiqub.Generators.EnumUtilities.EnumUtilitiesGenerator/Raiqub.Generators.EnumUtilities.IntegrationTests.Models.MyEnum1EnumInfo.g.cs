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
    internal static partial class MyEnum1EnumInfo
    {
        /// <summary>Represents the largest possible number of characters produced by converting an <see cref="MyEnum1" /> value to string, based on defined members. This field is constant.</summary>
        public const int NameMaxCharsLength = 4;

        /// <summary>Provides support for formatting <see cref="MyEnum1"/> values.</summary>
        public sealed partial class StringFormatter : IEnumFormatter<int>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringFormatter"/> class.</summary>
            public static StringFormatter Instance = new StringFormatter();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetStringCountForNumber(int value) => EnumNumericFormatter.GetStringLength(value);

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public string GetStringForNumber(int value) => value.ToString();

            /// <inheritdoc />
            public int? TryGetStringCountForMember(int value)
            {
                return value switch
                {
                    0 => 4,
                    1 => 3,
                    2 => 3,
                    _ => null
                };
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(int value)
            {
                return value switch
                {
                    0 => "Zero",
                    1 => "One",
                    2 => "Two",
                    _ => null
                };
            }
        }

        /// <summary>Provides support for parsing <see cref="MyEnum1"/> values.</summary>
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
                    case { } when value.SequenceEqual("Zero".AsSpan()):
                        result = 0;
                        return true;
                    case { } when value.SequenceEqual("One".AsSpan()):
                        result = 1;
                        return true;
                    case { } when value.SequenceEqual("Two".AsSpan()):
                        result = 2;
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
                    case { } when value.Equals("Zero", comparisonType):
                        result = 0;
                        return true;
                    case { } when value.Equals("One", comparisonType):
                        result = 1;
                        return true;
                    case { } when value.Equals("Two", comparisonType):
                        result = 2;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
