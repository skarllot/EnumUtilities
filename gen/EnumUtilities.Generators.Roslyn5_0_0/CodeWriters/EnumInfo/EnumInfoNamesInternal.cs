using System.Text;
using Raiqub.Generators.EnumUtilities.Common;
using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.EnumInfo;

public static class EnumInfoNamesInternal
{
    private static readonly Encoding s_utf8Encoding = Encoding.UTF8;

    public static void Write(
        StringBuilder builder,
        EnumToGenerate model,
        string className,
        string xmlDocAllRef,
        string xmlDocItemRef,
        string xmlDocAction,
        Func<EnumValue, string> keySelector
    )
    {
        builder.AppendUnixLine(
            $$"""
                /// <summary>Provides constant values for <see cref="{{model.Name}}" /> {{xmlDocAllRef}}.</summary>
                public static partial class {{className}}
                {
                    /// <summary>Represents the largest possible number of characters produced by {{xmlDocAction}} a <see cref="{{model.Name}}" /> value to string, based on defined members.</summary>
                    public const int MaxCharsLength = {{model.Values.Max(x => keySelector(x).Length)}};
            """
        );

        foreach (var curr in model.Values)
        {
            builder.AppendUnixLine(
                $$"""

                        /// <summary>The string representation of <see cref="{{model.Name}}.{{curr.MemberName}}" /> {{xmlDocItemRef}}.</summary>
                        public const string {{curr.MemberName}} = {{keySelector(curr).ToQuotedStringLiteral()}};
                """
            );
        }

        var maxBytesLength = model.Values.Max(x => s_utf8Encoding.GetByteCount(keySelector(x)));
        builder.AppendUnixLine(
            $$"""
                }

                /// <summary>Provides static values for <see cref="{{model.Name}}" /> UTF-8 encoded {{xmlDocAllRef}}.</summary>
                public static partial class Utf8{{className}}
                {
                    /// <summary>Represents the largest possible number of bytes produced by {{xmlDocAction}} a <see cref="{{model.Name}}" /> value to UTF-8 string, based on defined members.</summary>
                    public const int MaxBytesLength = {{maxBytesLength}};
            """
        );

        foreach (var curr in model.Values)
        {
            var byteCount = s_utf8Encoding.GetByteCount(keySelector(curr));
            var bytes = s_utf8Encoding.GetBytes(keySelector(curr)).JoinToString();
            builder.AppendUnixLine(
                $$"""

                        /// <summary>The UTF-8 representation of <see cref="{{model.Name}}.{{curr.MemberName}}" /> {{xmlDocItemRef}}.</summary>
                        public static ReadOnlySpan<byte> {{curr.MemberName}} => new byte[{{byteCount}}] { {{bytes}} };
                """
            );
        }

        builder.AppendUnixLine(
            """
                }
            """
        );
    }
}
