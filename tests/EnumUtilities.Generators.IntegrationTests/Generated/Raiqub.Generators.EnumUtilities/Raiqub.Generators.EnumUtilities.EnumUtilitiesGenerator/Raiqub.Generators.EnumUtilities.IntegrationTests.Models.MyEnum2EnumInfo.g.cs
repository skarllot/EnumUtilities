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
    internal static partial class MyEnum2EnumInfo
    {
        /// <summary>Represents the largest possible number of characters produced by converting an <see cref="MyEnum2" /> value to string, based on defined members. This field is constant.</summary>
        public const int NameMaxCharsLength = 6;

        /// <summary>Provides support for formatting <see cref="MyEnum2"/> values.</summary>
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
                    0 => 6,
                    1 => 5,
                    2 => 4,
                    3 => 6,
                    _ => null
                };
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(int value)
            {
                return value switch
                {
                    0 => "Credit",
                    1 => "Debit",
                    2 => "Cash",
                    3 => "Cheque",
                    _ => null
                };
            }
        }

        /// <summary>Provides support for parsing <see cref="MyEnum2"/> values.</summary>
        public sealed partial class StringParser
            : IEnumParser<int>, IEnumDescriptionParser<int>
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

            /// <inheritdoc />
            public bool TryParseDescription(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                switch (value)
                {
                    case { } s when s.Equals("The payment by using physical cash", comparisonType):
                        result = 2;
                        return true;
                    default:
                        result = default;
                        return false;
                }
            }

            private bool TryParse(ReadOnlySpan<char> value, out int result)
            {
                switch (value)
                {
                    case { } when value.SequenceEqual("Credit".AsSpan()):
                        result = 0;
                        return true;
                    case { } when value.SequenceEqual("Debit".AsSpan()):
                        result = 1;
                        return true;
                    case { } when value.SequenceEqual("Cash".AsSpan()):
                        result = 2;
                        return true;
                    case { } when value.SequenceEqual("Cheque".AsSpan()):
                        result = 3;
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
                    case { } when value.Equals("Credit", comparisonType):
                        result = 0;
                        return true;
                    case { } when value.Equals("Debit", comparisonType):
                        result = 1;
                        return true;
                    case { } when value.Equals("Cash", comparisonType):
                        result = 2;
                        return true;
                    case { } when value.Equals("Cheque", comparisonType):
                        result = 3;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
