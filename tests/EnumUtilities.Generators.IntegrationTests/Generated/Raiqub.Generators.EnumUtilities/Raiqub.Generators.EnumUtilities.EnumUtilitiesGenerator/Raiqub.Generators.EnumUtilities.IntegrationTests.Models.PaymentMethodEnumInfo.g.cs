﻿// <auto-generated />
#nullable enable

using System;
using System.Runtime.CompilerServices;
using Raiqub.Generators.EnumUtilities.Formatters;
using Raiqub.Generators.EnumUtilities.Parsers;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models
{
    /// <summary>Provides metadata for <see cref="PaymentMethod" /> enumeration.</summary>
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Raiqub.Generators.EnumUtilities", "1.8.0.0")]
    public static partial class PaymentMethodMetadata
    {
        /// <summary>Provides constant values for <see cref="PaymentMethod" /> members names.</summary>
        public static partial class Name
        {
            /// <summary>Represents the largest possible number of characters produced by converting a <see cref="PaymentMethod" /> value to string, based on defined members.</summary>
            public const int MaxCharsLength = 6;

            /// <summary>The string representation of <see cref="PaymentMethod.Credit" /> name.</summary>
            public const string Credit = "Credit";

            /// <summary>The string representation of <see cref="PaymentMethod.Debit" /> name.</summary>
            public const string Debit = "Debit";

            /// <summary>The string representation of <see cref="PaymentMethod.Cash" /> name.</summary>
            public const string Cash = "Cash";

            /// <summary>The string representation of <see cref="PaymentMethod.Cheque" /> name.</summary>
            public const string Cheque = "Cheque";
        }

        /// <summary>Provides static values for <see cref="PaymentMethod" /> UTF-8 encoded members names.</summary>
        public static partial class Utf8Name
        {
            /// <summary>Represents the largest possible number of bytes produced by converting a <see cref="PaymentMethod" /> value to UTF-8 string, based on defined members.</summary>
            public const int MaxBytesLength = 6;

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Credit" /> name.</summary>
            public static ReadOnlySpan<byte> Credit => new byte[6] { 67, 114, 101, 100, 105, 116 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Debit" /> name.</summary>
            public static ReadOnlySpan<byte> Debit => new byte[5] { 68, 101, 98, 105, 116 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Cash" /> name.</summary>
            public static ReadOnlySpan<byte> Cash => new byte[4] { 67, 97, 115, 104 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Cheque" /> name.</summary>
            public static ReadOnlySpan<byte> Cheque => new byte[6] { 67, 104, 101, 113, 117, 101 };
        }
        /// <summary>Provides constant values for <see cref="PaymentMethod" /> serialized members values.</summary>
        public static partial class SerializedValue
        {
            /// <summary>Represents the largest possible number of characters produced by serializing a <see cref="PaymentMethod" /> value to string, based on defined members.</summary>
            public const int MaxCharsLength = 11;

            /// <summary>The string representation of <see cref="PaymentMethod.Credit" /> serialized value.</summary>
            public const string Credit = "Credit card";

            /// <summary>The string representation of <see cref="PaymentMethod.Debit" /> serialized value.</summary>
            public const string Debit = "Debit card";

            /// <summary>The string representation of <see cref="PaymentMethod.Cash" /> serialized value.</summary>
            public const string Cash = "Cash";

            /// <summary>The string representation of <see cref="PaymentMethod.Cheque" /> serialized value.</summary>
            public const string Cheque = "Cheque";
        }

        /// <summary>Provides static values for <see cref="PaymentMethod" /> UTF-8 encoded serialized members values.</summary>
        public static partial class Utf8SerializedValue
        {
            /// <summary>Represents the largest possible number of bytes produced by serializing a <see cref="PaymentMethod" /> value to UTF-8 string, based on defined members.</summary>
            public const int MaxBytesLength = 11;

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Credit" /> serialized value.</summary>
            public static ReadOnlySpan<byte> Credit => new byte[11] { 67, 114, 101, 100, 105, 116, 32, 99, 97, 114, 100 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Debit" /> serialized value.</summary>
            public static ReadOnlySpan<byte> Debit => new byte[10] { 68, 101, 98, 105, 116, 32, 99, 97, 114, 100 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Cash" /> serialized value.</summary>
            public static ReadOnlySpan<byte> Cash => new byte[4] { 67, 97, 115, 104 };

            /// <summary>The UTF-8 representation of <see cref="PaymentMethod.Cheque" /> serialized value.</summary>
            public static ReadOnlySpan<byte> Cheque => new byte[6] { 67, 104, 101, 113, 117, 101 };
        }
    }
}
