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
    internal static partial class ErrorCodeMetadata
    {
        /// <summary>Provides support for formatting <see cref="ErrorCode"/> values.</summary>
        internal sealed partial class StringFormatter : IEnumFormatter<ushort>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringFormatter"/> class.</summary>
            public static StringFormatter Instance = new StringFormatter();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetStringLengthForNumber(ushort value) => EnumNumericFormatter.GetStringLength(value);

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public string GetStringForNumber(ushort value) => value.ToString();

            /// <inheritdoc />
            public int? TryGetStringLengthForMember(ushort value)
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

        /// <summary>Provides support for parsing <see cref="ErrorCode"/> values.</summary>
        internal sealed partial class StringParser
            : IEnumParser<ushort>
        {
            /// <summary>Gets the singleton instance of the <see cref="StringParser"/> class.</summary>
            public static StringParser Instance = new StringParser();

            /// <inheritdoc />
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ushort BitwiseOr(ushort value1, ushort value2) => unchecked((ushort)(value1 | value2));

            /// <inheritdoc />
            public bool TryParseNumber(ReadOnlySpan<char> value, out ushort result) => EnumNumericParser.TryParse(value, out result);

            /// <inheritdoc />
            public bool TryParseSingleName(ReadOnlySpan<char> value, StringComparison comparisonType, out ushort result)
            {
                if (value.IsEmpty)
                {
                    result = 0;
                    return false;
                }

                switch (value[0])
                {
                    case 'N':
                    case 'n':
                        switch (value)
                        {
                            case { } when value.Equals("None", comparisonType):
                                result = 0;
                                return true;
                        }
                        goto default;
                    case 'U':
                    case 'u':
                        switch (value)
                        {
                            case { } when value.Equals("Unknown", comparisonType):
                                result = 1;
                                return true;
                        }
                        goto default;
                    case 'C':
                    case 'c':
                        switch (value)
                        {
                            case { } when value.Equals("ConnectionLost", comparisonType):
                                result = 100;
                                return true;
                        }
                        goto default;
                    case 'O':
                    case 'o':
                        switch (value)
                        {
                            case { } when value.Equals("OutlierReading", comparisonType):
                                result = 200;
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
