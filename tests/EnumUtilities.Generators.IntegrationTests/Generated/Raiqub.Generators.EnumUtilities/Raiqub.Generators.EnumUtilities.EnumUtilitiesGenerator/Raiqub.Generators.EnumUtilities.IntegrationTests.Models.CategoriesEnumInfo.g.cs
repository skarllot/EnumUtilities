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
    public static partial class CategoriesMetadata
    {
        /// <summary>Provides constant values for <see cref="Categories" /> members names.</summary>
        public static partial class Name
        {
            /// <summary>Represents the largest possible number of characters produced by converting an <see cref="Categories" /> value to string, based on defined members. This field is constant.</summary>
            public const int MaxCharsLength = 11;

            /// <summary>The string representation of <see cref="Categories.Electronics" /> name.</summary>
            public const string Electronics = "Electronics";

            /// <summary>The string representation of <see cref="Categories.Food" /> name.</summary>
            public const string Food = "Food";

            /// <summary>The string representation of <see cref="Categories.Automotive" /> name.</summary>
            public const string Automotive = "Automotive";

            /// <summary>The string representation of <see cref="Categories.Arts" /> name.</summary>
            public const string Arts = "Arts";

            /// <summary>The string representation of <see cref="Categories.BeautyCare" /> name.</summary>
            public const string BeautyCare = "BeautyCare";

            /// <summary>The string representation of <see cref="Categories.Fashion" /> name.</summary>
            public const string Fashion = "Fashion";
        }

        /// <summary>Provides static values for <see cref="Categories" /> UTF-8 encoded members names.</summary>
        public static partial class Utf8Name
        {
            /// <summary>Represents the largest possible number of bytes produced by converting an <see cref="Categories" /> value to UTF-8 string, based on defined members. This field is constant.</summary>
            public const int MaxBytesLength = 11;

            /// <summary>The UTF-8 representation of <see cref="Categories.Electronics" /> name.</summary>
            public static ReadOnlySpan<byte> Electronics => new byte[11] { 69, 108, 101, 99, 116, 114, 111, 110, 105, 99, 115 };

            /// <summary>The UTF-8 representation of <see cref="Categories.Food" /> name.</summary>
            public static ReadOnlySpan<byte> Food => new byte[4] { 70, 111, 111, 100 };

            /// <summary>The UTF-8 representation of <see cref="Categories.Automotive" /> name.</summary>
            public static ReadOnlySpan<byte> Automotive => new byte[10] { 65, 117, 116, 111, 109, 111, 116, 105, 118, 101 };

            /// <summary>The UTF-8 representation of <see cref="Categories.Arts" /> name.</summary>
            public static ReadOnlySpan<byte> Arts => new byte[4] { 65, 114, 116, 115 };

            /// <summary>The UTF-8 representation of <see cref="Categories.BeautyCare" /> name.</summary>
            public static ReadOnlySpan<byte> BeautyCare => new byte[10] { 66, 101, 97, 117, 116, 121, 67, 97, 114, 101 };

            /// <summary>The UTF-8 representation of <see cref="Categories.Fashion" /> name.</summary>
            public static ReadOnlySpan<byte> Fashion => new byte[7] { 70, 97, 115, 104, 105, 111, 110 };
        }

        /// <summary>Provides support for formatting <see cref="Categories"/> values.</summary>
        internal sealed partial class StringFormatter : IEnumFormatter<int>
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
                    0 => 11,
                    1 => 4,
                    2 => 10,
                    3 => 4,
                    4 => 10,
                    5 => 7,
                    _ => null
                };
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(int value)
            {
                return value switch
                {
                    0 => "Electronics",
                    1 => "Food",
                    2 => "Automotive",
                    3 => "Arts",
                    4 => "BeautyCare",
                    5 => "Fashion",
                    _ => null
                };
            }
        }

        /// <summary>Provides support for parsing <see cref="Categories"/> values.</summary>
        internal sealed partial class StringParser
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
            public bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out int result)
            {
                if (value.IsEmpty)
                {
                    result = 0;
                    return false;
                }

                switch (value[0])
                {
                    case 'E':
                    case 'e':
                        switch (value)
                        {
                            case { } when value.Equals("Electronics", comparisonType):
                                result = 0;
                                return true;
                        }
                        goto default;
                    case 'F':
                    case 'f':
                        switch (value)
                        {
                            case { } when value.Equals("Food", comparisonType):
                                result = 1;
                                return true;
                            case { } when value.Equals("Fashion", comparisonType):
                                result = 5;
                                return true;
                        }
                        goto default;
                    case 'A':
                    case 'a':
                        switch (value)
                        {
                            case { } when value.Equals("Automotive", comparisonType):
                                result = 2;
                                return true;
                            case { } when value.Equals("Arts", comparisonType):
                                result = 3;
                                return true;
                        }
                        goto default;
                    case 'B':
                    case 'b':
                        switch (value)
                        {
                            case { } when value.Equals("BeautyCare", comparisonType):
                                result = 4;
                                return true;
                        }
                        goto default;
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
