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
    internal sealed class ErrorCodeJsonConverter : JsonConverter<ErrorCode>
    {
        private const int MaxBytesLength = 3;
        private const int MaxCharsLength = 3;

        private static readonly ErrorCodeMetadata.StringFormatter s_stringFormatter = ErrorCodeMetadata.StringFormatter.Instance;
        private static readonly ErrorCodeMetadata.StringParser s_stringParser = ErrorCodeMetadata.StringParser.Instance;

        public override ErrorCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
                return (ErrorCode)ReadFromString(ref reader);

            return (ErrorCode)0;
        }

    #if NET7_0_OR_GREATER

        public override void Write(Utf8JsonWriter writer, ErrorCode value, JsonSerializerOptions options)
        {
            switch ((ushort)value)
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
                case 200:
                    writer.WriteStringValue("OUT"u8);
                    break;
                default:
                    string strValue = EnumStringFormatter.GetString((ushort)value, s_stringFormatter);
                    writer.WriteStringValue(strValue);
                    break;
            }
        }

        private ushort ReadFromString(ref Utf8JsonReader reader)
        {
            int length = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
            if (length > MaxBytesLength)
                return (ushort)0;

            Span<char> name = stackalloc char[MaxBytesLength];
            int charsWritten = reader.CopyString(name);
            name = name.Slice(0, charsWritten);

            return name switch
            {
                "NON" => (ushort)0,
                "UNK" => (ushort)1,
                "CNX" => (ushort)100,
                "OUT" => (ushort)200,
                _ => EnumStringParser.TryParse(name, s_stringParser, StringComparison.OrdinalIgnoreCase, throwOnFailure: false, out ushort result) ? result : (ushort)0
            };
        }

    #else

        public override void Write(Utf8JsonWriter writer, ErrorCode value, JsonSerializerOptions options)
        {
            switch ((ushort)value)
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
                case 200:
                    writer.WriteStringValue("OUT");
                    break;
                default:
                    string strValue = EnumStringFormatter.GetString((ushort)value, s_stringFormatter);
                    writer.WriteStringValue(strValue);
                    break;
            }
        }

        private ushort ReadFromString(ref Utf8JsonReader reader)
        {
            var name = reader.GetString();
            return name switch
            {
                "NON" => (ushort)0,
                "UNK" => (ushort)1,
                "CNX" => (ushort)100,
                "OUT" => (ushort)200,
                _ => EnumStringParser.TryParse(name, s_stringParser, StringComparison.OrdinalIgnoreCase, throwOnFailure: false, out ushort result) ? result : (ushort)0
            };
        }

    #endif
    }
}
