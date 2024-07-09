﻿// <auto-generated />
#nullable enable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    internal sealed class BigErrorCodeJsonConverter : JsonConverter<BigErrorCode>
    {
        private const int MaxBytesLength = 3;
        private const int MaxCharsLength = 3;

        public override BigErrorCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
                return (BigErrorCode)ReadFromString(ref reader);

            return (BigErrorCode)0;
        }

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
                    writer.WriteStringValue(value.ToString());
                    break;
            }
        }

        private ulong ReadFromString(ref Utf8JsonReader reader)
        {
    #if NET7_0_OR_GREATER
            int length = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
            if (length > MaxBytesLength)
                return 0;

            Span<char> name = stackalloc char[MaxBytesLength];
            int charsWritten = reader.CopyString(name);
            name = name.Slice(0, charsWritten);
    #else
            string? name = reader.GetString();
    #endif

            return name switch
            {
                "NON" => 0,
                "UNK" => 1,
                "CNX" => 100,
                "OUT" => 200000000000,
                _ => Enum.TryParse(name, out BigErrorCode result) ? (ulong)result : 0
            };
        }
    }
}
