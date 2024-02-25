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
    
    #line 1 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class EnumJsonConverterWriter : CodeWriterBase<EnumToGenerate>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("// <auto-generated />\r\n#nullable enable\r\n\r\nusing System;\r\nusing System.Text.Json;\r\nusing System.Text.Json.Serialization;\r\n\r\n#pragma warning disable CS1591 // publicly visible type or member must be documented\r\n\r\n");
            
            #line 14 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"

    if (!string.IsNullOrEmpty(Model.Namespace))
    {
        WriteLine($"namespace {Model.Namespace}");
        WriteLine("{");
        PushIndent();
    }

            
            #line default
            #line hidden
            this.Write("[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]\r\n[global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"");
            
            #line 23 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CurrentAssemblyName.Name));
            
            #line default
            #line hidden
            this.Write("\", \"");
            
            #line 23 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Append($"{CurrentAssemblyName.Version}")));
            
            #line default
            #line hidden
            this.Write("\")]\r\n");
            
            #line 24 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.IsPublic ? "public" : "internal"));
            
            #line default
            #line hidden
            this.Write(" sealed class ");
            
            #line 24 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("JsonConverter : JsonConverter<");
            
            #line 24 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(">\r\n{\r\n    private const int MaxValueLength = ");
            
            #line 26 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Values.Max(x => x.MemberName.Length)));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n    public override ");
            
            #line 28 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(" Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)\r\n    {\r\n#if NET7_0_OR_GREATER\r\n        int length = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;\r\n        if (length != MaxValueLength)\r\n            return 0;\r\n\r\n        Span<char> name = stackalloc char[MaxValueLength];\r\n        reader.CopyString(name);\r\n#else\r\n        string? name = reader.GetString();\r\n#endif\r\n\r\n        return name switch\r\n        {\r\n");
            
            #line 43 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"

    foreach (var curr in Model.Values)
    {

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 47 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.SerializationValue is not null
                    ? Append($"\"{curr.SerializationValue}\"")
                    : Append($"nameof({Model.RefName}.{curr.MemberName})")));
            
            #line default
            #line hidden
            this.Write(" => ");
            
            #line 50 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.RefName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 50 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberName));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 51 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"

    }

            
            #line default
            #line hidden
            this.Write("            _ => 0\r\n        };\r\n    }\r\n\r\n    public override void Write(Utf8JsonWriter writer, ");
            
            #line 58 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(" value, JsonSerializerOptions options)\r\n    {\r\n        switch (value)\r\n        {\r\n");
            
            #line 62 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"

    foreach (var curr in Model.Values)
    {

            
            #line default
            #line hidden
            this.Write("            case ");
            
            #line 66 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.RefName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 66 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberName));
            
            #line default
            #line hidden
            this.Write(":\r\n                writer.WriteStringValue(\"");
            
            #line 67 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.SerializationValue ?? curr.MemberName));
            
            #line default
            #line hidden
            this.Write("\"u8);\r\n                break;\r\n");
            
            #line 69 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"

    }

            
            #line default
            #line hidden
            this.Write("            default:\r\n                writer.WriteNullValue();\r\n                break;\r\n        }\r\n    }\r\n}\r\n");
            
            #line 78 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"

    if (!string.IsNullOrEmpty(Model.Namespace))
    {
        PopIndent();
        WriteLine("}");
    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 85 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\src\EnumUtilities\CodeWriters\EnumJsonConverterWriter.tt"

    public EnumJsonConverterWriter(StringBuilder builder) : base(builder)
    {
    }

    public override string GetFileName() => $"{Model.Namespace ?? "_"}.{Model.Name}JsonConverter.g.cs";
    protected override bool CanGenerateFor(EnumToGenerate model) => model.GenerateJsonConverter;

        
        #line default
        #line hidden
    }
    
}
