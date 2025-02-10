﻿// <auto-generated />
#nullable enable

using System;
using System.Buffers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Raiqub.Generators.EnumUtilities.Formatters;
using Raiqub.Generators.EnumUtilities.Parsers;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.10.0.0")]
    internal sealed partial class ErrorCodeJsonConverter : JsonConverter<ErrorCode>
    {
        private const int MaxCharStack = 256;

        public override ErrorCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
                return ReadFromString(ref reader);

            return (ErrorCode)0;
        }

        public override void Write(Utf8JsonWriter writer, ErrorCode value, JsonSerializerOptions options)
        {
            string? jsonString = value.ToJsonString();
            if (jsonString is not null)
            {
                writer.WriteStringValue(jsonString);
            }
            else
            {
                jsonString = ((ErrorCode)0).ToJsonString();
                if (jsonString is not null)
                    writer.WriteStringValue(jsonString);
                else
                    throw new JsonException();
            }
        }

    #if NET7_0_OR_GREATER

        private ErrorCode ReadFromString(ref Utf8JsonReader reader)
        {
            int length = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;

            char[]? rented = null;
            Span<char> name = length <= MaxCharStack ? stackalloc char[MaxCharStack] : (rented = ArrayPool<char>.Shared.Rent(length));
            try
            {
                int charsWritten = reader.CopyString(name);
                name = name.Slice(0, charsWritten);

                bool isParsed = ErrorCodeFactory.TryParseJsonString(name, ignoreCase: false, out ErrorCode result);
                if (!isParsed)
                {
                    return (ErrorCode)0;
                }

                return result;
            }
            finally
            {
                if (rented != null)
                {
                    ArrayPool<char>.Shared.Return(rented);
                }
            }
        }

    #else

        private ErrorCode ReadFromString(ref Utf8JsonReader reader)
        {
            var name = reader.GetString();
            bool isParsed = ErrorCodeFactory.TryParseJsonString(name, ignoreCase: false, out ErrorCode result);
            if (!isParsed)
            {
                return (ErrorCode)0;
            }

            return result;
        }

    #endif
    }
}
