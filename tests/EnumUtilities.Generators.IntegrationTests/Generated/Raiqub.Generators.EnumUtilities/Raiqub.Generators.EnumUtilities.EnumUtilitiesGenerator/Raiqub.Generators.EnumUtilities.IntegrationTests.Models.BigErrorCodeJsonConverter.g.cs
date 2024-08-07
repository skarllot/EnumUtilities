﻿// <auto-generated />
#nullable enable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Raiqub.Generators.EnumUtilities.Formatters;
using Raiqub.Generators.EnumUtilities.Parsers;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    internal sealed class BigErrorCodeJsonConverter : JsonConverter<BigErrorCode>
    {
        private const int MaxBytesLength = 3;
        private const int MaxCharsLength = 3;

        private static readonly BigErrorCodeEnumInfo.StringFormatter s_stringFormatter = BigErrorCodeEnumInfo.StringFormatter.Instance;
        private static readonly BigErrorCodeEnumInfo.StringParser s_stringParser = BigErrorCodeEnumInfo.StringParser.Instance;

        public override BigErrorCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
                return (BigErrorCode)ReadFromString(ref reader);

            return (BigErrorCode)0;
        }

    #if NET7_0_OR_GREATER

        public override void Write(Utf8JsonWriter writer, BigErrorCode value, JsonSerializerOptions options)
        {
            switch ((ulong)value)
            {
                case 0:
                    writer.WriteStringValue("NON"u8);
                    break;
                case 1:
                    writer.WriteStringValue("UNK"u8);
                    break;
                case 100:
                    writer.WriteStringValue("CNX"u8);
                    break;
                case 200000000000:
                    writer.WriteStringValue("OUT"u8);
                    break;
                default:
                    string strValue = EnumStringFormatter.GetString((ulong)value, s_stringFormatter);
                    writer.WriteStringValue(strValue);
                    break;
            }
        }

        private ulong ReadFromString(ref Utf8JsonReader reader)
        {
            int length = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
            if (length > MaxBytesLength)
                return 0;

            Span<char> name = stackalloc char[MaxBytesLength];
            int charsWritten = reader.CopyString(name);
            name = name.Slice(0, charsWritten);

            return name switch
            {
                "NON" => 0,
                "UNK" => 1,
                "CNX" => 100,
                "OUT" => 200000000000,
                _ => EnumStringParser.TryParse(name, s_stringParser, ignoreCase: true, throwOnFailure: false, out ulong result) ? result : 0
            };
        }

    #else

        public override void Write(Utf8JsonWriter writer, BigErrorCode value, JsonSerializerOptions options)
        {
            switch ((ulong)value)
            {
                case 0:
                    writer.WriteStringValue("NON");
                    break;
                case 1:
                    writer.WriteStringValue("UNK");
                    break;
                case 100:
                    writer.WriteStringValue("CNX");
                    break;
                case 200000000000:
                    writer.WriteStringValue("OUT");
                    break;
                default:
                    string strValue = EnumStringFormatter.GetString((ulong)value, s_stringFormatter);
                    writer.WriteStringValue(strValue);
                    break;
            }
        }

        private ulong ReadFromString(ref Utf8JsonReader reader)
        {
            var name = reader.GetString();
            return name switch
            {
                "NON" => 0,
                "UNK" => 1,
                "CNX" => 100,
                "OUT" => 200000000000,
                _ => EnumStringParser.TryParse(name, s_stringParser, ignoreCase: true, throwOnFailure: false, out ulong result) ? result : 0
            };
        }

    #endif
    }
}
