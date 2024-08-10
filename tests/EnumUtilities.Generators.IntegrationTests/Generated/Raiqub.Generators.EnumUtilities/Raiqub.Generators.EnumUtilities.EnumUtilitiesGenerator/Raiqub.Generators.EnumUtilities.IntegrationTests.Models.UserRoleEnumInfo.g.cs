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
    public static partial class UserRoleEnumInfo
    {
        /// <summary>Represents the largest possible number of characters produced by converting an <see cref="UserRole" /> value to string, based on defined members. This field is constant.</summary>
        public const int NameMaxCharsLength = 10;

        /// <summary>Provides support for formatting <see cref="UserRole"/> values.</summary>
        public sealed partial class StringFormatter : IEnumFormatter<ulong>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringFormatter"/> class.</summary>
            public static StringFormatter Instance = new StringFormatter();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetStringLengthForNumber(ulong value) => EnumNumericFormatter.GetStringLength(value);

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public string GetStringForNumber(ulong value) => value.ToString();

            /// <inheritdoc />
            public int? TryGetStringLengthForMember(ulong value)
            {
                if (value == 0)
                {
                    return 4;
                }

                int count = 0, foundItemsCount = 0;
                if ((value & 7) == 7)
                {
                    value -= 7;
                    count = checked(count + 3);
                    foundItemsCount++;
                }
                if ((value & 6) == 6)
                {
                    value -= 6;
                    count = checked(count + 9);
                    foundItemsCount++;
                }
                if ((value & 4) == 4)
                {
                    value -= 4;
                    count = checked(count + 7);
                    foundItemsCount++;
                }
                if ((value & 2) == 2)
                {
                    value -= 2;
                    count = checked(count + 9);
                    foundItemsCount++;
                }
                if ((value & 1) == 1)
                {
                    value -= 1;
                    count = checked(count + 10);
                    foundItemsCount++;
                }

                if (value != 0)
                {
                    return null;
                }

                const int separatorStringLength = 2;
                return checked(count + (separatorStringLength * (foundItemsCount - 1)));
            }

            /// <inheritdoc />
            public string? TryGetStringForMember(ulong value)
            {
                if (value == 0)
                {
                    return "None";
                }

                Span<ulong> foundItems = stackalloc ulong[3];
                int count = 0, foundItemsCount = 0;
                if ((value & 7) == 7)
                {
                    value -= 7;
                    count = checked(count + 3);
                    foundItems[foundItemsCount++] = 7;
                }
                if ((value & 6) == 6)
                {
                    value -= 6;
                    count = checked(count + 9);
                    foundItems[foundItemsCount++] = 6;
                }
                if ((value & 4) == 4)
                {
                    value -= 4;
                    count = checked(count + 7);
                    foundItems[foundItemsCount++] = 4;
                }
                if ((value & 2) == 2)
                {
                    value -= 2;
                    count = checked(count + 9);
                    foundItems[foundItemsCount++] = 2;
                }
                if ((value & 1) == 1)
                {
                    value -= 1;
                    count = checked(count + 10);
                    foundItems[foundItemsCount++] = 1;
                }

                if (value != 0)
                {
                    return null;
                }

                if (foundItemsCount == 1)
                {
                    return GetStringForSingleMember(foundItems[0]);
                }

                return WriteMultipleFoundFlagsNames(count, foundItemsCount, foundItems);
            }

            private string WriteMultipleFoundFlagsNames(int count, int foundItemsCount, Span<ulong> foundItems)
            {
                const int separatorStringLength = 2;
                const char enumSeparatorChar = ',';
                var strlen = checked(count + (separatorStringLength * (foundItemsCount - 1)));
                Span<char> result = strlen <= 128
                    ? stackalloc char[128].Slice(0, strlen)
                    : new char[strlen];
                var span = result;

                string name = GetStringForSingleMember(foundItems[--foundItemsCount]);
                name.AsSpan().CopyTo(span);
                span = span.Slice(name.Length);
                while (--foundItemsCount >= 0)
                {
                    span[0] = enumSeparatorChar;
                    span[1] = ' ';
                    span = span.Slice(2);

                    name = GetStringForSingleMember(foundItems[foundItemsCount]);
                    name.CopyTo(span);
                    span = span.Slice(name.Length);
                }

                return result.ToString();
            }

            private string GetStringForSingleMember(ulong value)
            {
                return value switch
                {
                    0 => "None",
                    1 => "NormalUser",
                    2 => "Custodian",
                    4 => "Finance",
                    6 => "SuperUser",
                    7 => "All",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        /// <summary>Provides support for parsing <see cref="UserRole"/> values.</summary>
        public sealed partial class StringParser
            : IEnumParser<ulong>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringParser"/> class.</summary>
            public static StringParser Instance = new StringParser();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ulong BitwiseOr(ulong value1, ulong value2) => unchecked((ulong)(value1 | value2));

            /// <inheritdoc />
            public bool TryParseNumber(ReadOnlySpan<char> value, out ulong result) => EnumNumericParser.TryParse(value, out result);

            /// <inheritdoc />
            public bool TryParseSingleName(ReadOnlySpan<char> value, bool ignoreCase, out ulong result)
            {
                return ignoreCase
                    ? TryParse(value, out result)
                    : TryParse(value, StringComparison.OrdinalIgnoreCase, out result);
            }

            /// <inheritdoc />
            public bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out ulong result)
            {
                return TryParse(value, comparisonType, out result);
            }

            private bool TryParse(ReadOnlySpan<char> value, out ulong result)
            {
                switch (value)
                {
                    case { } when value.SequenceEqual("None".AsSpan()):
                        result = 0;
                        return true;
                    case { } when value.SequenceEqual("NormalUser".AsSpan()):
                        result = 1;
                        return true;
                    case { } when value.SequenceEqual("Custodian".AsSpan()):
                        result = 2;
                        return true;
                    case { } when value.SequenceEqual("Finance".AsSpan()):
                        result = 4;
                        return true;
                    case { } when value.SequenceEqual("SuperUser".AsSpan()):
                        result = 6;
                        return true;
                    case { } when value.SequenceEqual("All".AsSpan()):
                        result = 7;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }

            private bool TryParse(ReadOnlySpan<char> value, StringComparison comparisonType, out ulong result)
            {
                switch (value)
                {
                    case { } when value.Equals("None", comparisonType):
                        result = 0;
                        return true;
                    case { } when value.Equals("NormalUser", comparisonType):
                        result = 1;
                        return true;
                    case { } when value.Equals("Custodian", comparisonType):
                        result = 2;
                        return true;
                    case { } when value.Equals("Finance", comparisonType):
                        result = 4;
                        return true;
                    case { } when value.Equals("SuperUser", comparisonType):
                        result = 6;
                        return true;
                    case { } when value.Equals("All", comparisonType):
                        result = 7;
                        return true;
                    default:
                        result = 0;
                        return false;
                }
            }
        }
    }
}
