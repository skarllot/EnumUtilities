﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Raiqub.Generators.EnumUtilities.CodeWriters
{
    using Common;
    using Models;
    using System.Text;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class EnumJsonConverterWriter : CodeWriterBase<EnumToGenerate>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 5 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    if (Model.JsonConverterGeneratorOptions is null)
        return string.Empty;

            
            #line default
            #line hidden
            this.Write("// <auto-generated />\r\n#nullable enable\r\n\r\nusing System;\r\nusing System.Text.Json;\r\nusing System.Text.Json.Serialization;\r\nusing Raiqub.Generators.EnumUtilities.Formatters;\r\nusing Raiqub.Generators.EnumUtilities.Parsers;\r\n\r\n#pragma warning disable CS1591 // publicly visible type or member must be documented\r\n\r\n");
            
            #line 20 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    if (!string.IsNullOrEmpty(Model.Namespace))
    {
        WriteLine($"namespace {Model.Namespace}");
        WriteLine("{");
        PushIndent();
    }

            
            #line default
            #line hidden
            this.Write("[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]\r\n[global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"");
            
            #line 29 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CurrentAssemblyName.Name));
            
            #line default
            #line hidden
            this.Write("\", \"");
            
            #line 29 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Append($"{CurrentAssemblyName.Version}")));
            
            #line default
            #line hidden
            this.Write("\")]\r\n");
            
            #line 30 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.IsPublic ? "public" : "internal"));
            
            #line default
            #line hidden
            this.Write(" sealed class ");
            
            #line 30 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("JsonConverter : JsonConverter<");
            
            #line 30 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(">\r\n{\r\n    private const int MaxBytesLength = ");
            
            #line 32 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Values.Max(
                        x => GetEncodedLength(x.JsonPropertyName ?? x.SerializationValue ?? x.MemberName))));
            
            #line default
            #line hidden
            this.Write(";\r\n    private const int MaxCharsLength = ");
            
            #line 35 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Values.Max(
                        x => x.JsonPropertyName?.Length ?? x.SerializationValue?.Length ?? x.MemberName.Length)));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n    private static readonly ");
            
            #line 39 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("EnumInfo.StringFormatter s_stringFormatter = ");
            
            #line 39 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("EnumInfo.StringFormatter.Instance;\r\n    private static readonly ");
            
            #line 40 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("EnumInfo.StringParser s_stringParser = ");
            
            #line 40 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("EnumInfo.StringParser.Instance;\r\n\r\n    public override ");
            
            #line 42 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(" Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)\r\n    {\r\n        if (reader.TokenType == JsonTokenType.String)\r\n            return (");
            
            #line 45 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.RefName));
            
            #line default
            #line hidden
            this.Write(")ReadFromString(ref reader);\r\n");
            
            #line 46 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    if (Model.JsonConverterGeneratorOptions.AllowIntegerValues)
    {

            
            #line default
            #line hidden
            this.Write("        if (reader.TokenType == JsonTokenType.Number)\r\n            return (");
            
            #line 51 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.RefName));
            
            #line default
            #line hidden
            this.Write(")ReadFromNumber(ref reader);\r\n");
            
            #line 52 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    }

            
            #line default
            #line hidden
            this.Write("\r\n        ");
            
            #line 56 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AppendFallbackValue(addReturn: true, castToEnum: true)));
            
            #line default
            #line hidden
            this.Write(";\r\n    }\r\n\r\n#if NET7_0_OR_GREATER\r\n\r\n    public override void Write(Utf8JsonWriter writer, ");
            
            #line 61 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(" value, JsonSerializerOptions options)\r\n    {\r\n        switch ((");
            
            #line 63 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(")value)\r\n        {\r\n");
            
            #line 65 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    foreach (var curr in Model.UniqueValues)
    {

            
            #line default
            #line hidden
            this.Write("            case ");
            
            #line 69 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberValue));
            
            #line default
            #line hidden
            this.Write(":\r\n                writer.WriteStringValue(\"");
            
            #line 70 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.JsonPropertyName ?? curr.SerializationValue ?? curr.MemberName));
            
            #line default
            #line hidden
            this.Write("\"u8);\r\n                break;\r\n");
            
            #line 72 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    }

            
            #line default
            #line hidden
            this.Write("            default:\r\n                string strValue = EnumStringFormatter.GetString((");
            
            #line 76 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(")value, s_stringFormatter);\r\n                writer.WriteStringValue(strValue);\r\n                break;\r\n        }\r\n    }\r\n\r\n    private ");
            
            #line 82 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(" ReadFromString(ref Utf8JsonReader reader)\r\n    {\r\n        int length = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;\r\n        if (length > MaxBytesLength)\r\n            ");
            
            #line 86 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AppendFallbackValue(addReturn: true)));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n        Span<char> name = stackalloc char[MaxBytesLength];\r\n        int charsWritten = reader.CopyString(name);\r\n        name = name.Slice(0, charsWritten);\r\n\r\n        return name switch\r\n        {\r\n");
            
            #line 94 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    foreach (var curr in Model.Values)
    {

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 98 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.JsonPropertyName is not null || curr.SerializationValue is not null
                    ? Append($"\"{curr.JsonPropertyName ?? curr.SerializationValue}\"")
                    : Append($"\"{curr.MemberName}\"")));
            
            #line default
            #line hidden
            this.Write(" => ");
            
            #line 101 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NeedNumberCasting() ? Append($"({Model.UnderlyingType})") : Append("")));
            
            #line default
            #line hidden
            
            #line 101 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberValue));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 102 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    }

            
            #line default
            #line hidden
            this.Write("            _ => EnumStringParser.TryParse(name, s_stringParser, ignoreCase: true, throwOnFailure: false, out ");
            
            #line 105 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(" result) ? result : ");
            
            #line 105 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AppendFallbackValue()));
            
            #line default
            #line hidden
            this.Write("\r\n        };\r\n    }\r\n\r\n#else\r\n\r\n    public override void Write(Utf8JsonWriter writer, ");
            
            #line 111 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(" value, JsonSerializerOptions options)\r\n    {\r\n        switch ((");
            
            #line 113 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(")value)\r\n        {\r\n");
            
            #line 115 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    foreach (var curr in Model.UniqueValues)
    {

            
            #line default
            #line hidden
            this.Write("            case ");
            
            #line 119 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberValue));
            
            #line default
            #line hidden
            this.Write(":\r\n                writer.WriteStringValue(\"");
            
            #line 120 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.JsonPropertyName ?? curr.SerializationValue ?? curr.MemberName));
            
            #line default
            #line hidden
            this.Write("\");\r\n                break;\r\n");
            
            #line 122 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    }

            
            #line default
            #line hidden
            this.Write("            default:\r\n                string strValue = EnumStringFormatter.GetString((");
            
            #line 126 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(")value, s_stringFormatter);\r\n                writer.WriteStringValue(strValue);\r\n                break;\r\n        }\r\n    }\r\n\r\n    private ");
            
            #line 132 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(" ReadFromString(ref Utf8JsonReader reader)\r\n    {\r\n        var name = reader.GetString();\r\n        return name switch\r\n        {\r\n");
            
            #line 137 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    foreach (var curr in Model.Values)
    {

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 141 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.JsonPropertyName is not null || curr.SerializationValue is not null
                    ? Append($"\"{curr.JsonPropertyName ?? curr.SerializationValue}\"")
                    : Append($"\"{curr.MemberName}\"")));
            
            #line default
            #line hidden
            this.Write(" => ");
            
            #line 144 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NeedNumberCasting() ? Append($"({Model.UnderlyingType})") : Append("")));
            
            #line default
            #line hidden
            
            #line 144 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberValue));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 145 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    }

            
            #line default
            #line hidden
            this.Write("            _ => EnumStringParser.TryParse(name, s_stringParser, ignoreCase: true, throwOnFailure: false, out ");
            
            #line 148 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(" result) ? result : ");
            
            #line 148 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AppendFallbackValue()));
            
            #line default
            #line hidden
            this.Write("\r\n        };\r\n    }\r\n\r\n#endif\r\n");
            
            #line 153 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    if (Model.JsonConverterGeneratorOptions.AllowIntegerValues)
    {

            
            #line default
            #line hidden
            this.Write("\r\n    private ");
            
            #line 158 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(" ReadFromNumber(ref Utf8JsonReader reader)\r\n    {\r\n        return reader.TryGet");
            
            #line 160 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CSharpExtensions.GetTypeNameFromCSharpKeyword(Model.UnderlyingType)));
            
            #line default
            #line hidden
            this.Write("(out ");
            
            #line 160 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(" value)\r\n            ? value\r\n            : ");
            
            #line 162 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AppendFallbackValue()));
            
            #line default
            #line hidden
            this.Write(";\r\n    }\r\n");
            
            #line 164 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    }

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 168 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

    if (!string.IsNullOrEmpty(Model.Namespace))
    {
        PopIndent();
        WriteLine("}");
    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 175 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumJsonConverterWriter.tt"

#nullable enable
    public EnumJsonConverterWriter(StringBuilder builder) : base(builder)
    {
    }

    public override string GetFileName() => $"{Model.Namespace ?? "_"}.{Model.Name}JsonConverter.g.cs";

    protected override bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.JsonConverter) != 0;

    private None AppendFallbackValue(bool addReturn = false, bool castToEnum = false)
    {
        object? fallbackValue = Model.JsonConverterGeneratorOptions!.DeserializationFailureFallbackValue;
        if (fallbackValue is null)
            return Append("throw new JsonException()");

        if (addReturn)
            Append("return ");
        if (castToEnum)
            Append($"({Model.RefName})");
        if (!castToEnum && NeedNumberCasting())
            Append($"({Model.UnderlyingType})");

        return Append($"{fallbackValue}");
    }

    private static int GetEncodedLength(string value) => value.Sum(c => c < 128 ? 1 : 6);
    private bool NeedNumberCasting() => Model.UnderlyingType is "byte" or "short" or "sbyte" or "ushort";

        
        #line default
        #line hidden
    }
    
}
