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
    using T4CodeWriter;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class EnumInfoWriter : CodeWriterBase<EnumToGenerate>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n// <auto-generated />\r\n#nullable enable\r\n\r\nusing System;\r\nusing System.Runtime.CompilerServices;\r\nusing Raiqub.Generators.EnumUtilities.Formatters;\r\nusing Raiqub.Generators.EnumUtilities.Parsers;\r\n\r\n#pragma warning disable CS1591 // publicly visible type or member must be documented\r\n\r\n");
            
            #line 18 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"

    if (!string.IsNullOrEmpty(Model.Namespace))
    {
        WriteLine($"namespace {Model.Namespace}");
        WriteLine("{");
        PushIndent();
    }

            
            #line default
            #line hidden
            this.Write("/// <summary>Provides metadata for <see cref=\"");
            
            #line 26 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("\" /> enumeration.</summary>\r\n[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]\r\n[global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"");
            
            #line 28 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CurrentAssemblyName.Name));
            
            #line default
            #line hidden
            this.Write("\", \"");
            
            #line 28 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Append($"{CurrentAssemblyName.Version}")));
            
            #line default
            #line hidden
            this.Write("\")]\r\n");
            
            #line 29 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.IsPublic ? "public" : "internal"));
            
            #line default
            #line hidden
            this.Write(" static partial class ");
            
            #line 29 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.MetadataClassName));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 31 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"

    WriteDefaultBlock();

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 35 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"

    if (!string.IsNullOrEmpty(Model.Namespace))
    {
        PopIndent();
        WriteLine("}");
    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"

    private void WriteNames(
        string className,
        string xmlDocAllRef,
        string xmlDocItemRef,
        string xmlDocAction,
        Func<EnumValue, string> keySelector,
        bool isName)
    {
        string fieldName = isName ? "s_names" : "s_values";
        string propName = isName ? "Names" : "Values";

        
        #line default
        #line hidden
        
        #line 13 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("    /// <summary>Provides constant values for <see cref=\"");

        
        #line default
        #line hidden
        
        #line 13 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));

        
        #line default
        #line hidden
        
        #line 13 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\" /> ");

        
        #line default
        #line hidden
        
        #line 13 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlDocAllRef));

        
        #line default
        #line hidden
        
        #line 13 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(".</summary>\r\n    public static partial class ");

        
        #line default
        #line hidden
        
        #line 14 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(className));

        
        #line default
        #line hidden
        
        #line 14 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\r\n    {\r\n        private static readonly string[] ");

        
        #line default
        #line hidden
        
        #line 16 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 16 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" = new string[");

        
        #line default
        #line hidden
        
        #line 16 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Values.Count));

        
        #line default
        #line hidden
        
        #line 16 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("] { ");

        
        #line default
        #line hidden
        
        #line 16 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"

        foreach (var (index, curr) in Model.Values.Index())
        {
            if (index > 0)
                Write(", ");
            Write($"\"{keySelector(curr)}\"");
        }

        
        #line default
        #line hidden
        
        #line 23 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" };\r\n\r\n        /// <summary>Gets a read-only memory containing the ");

        
        #line default
        #line hidden
        
        #line 25 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlDocAllRef));

        
        #line default
        #line hidden
        
        #line 25 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" of <see cref=\"");

        
        #line default
        #line hidden
        
        #line 25 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));

        
        #line default
        #line hidden
        
        #line 25 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\" />.</summary>\r\n        public static ReadOnlyMemory<string> ");

        
        #line default
        #line hidden
        
        #line 26 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(propName));

        
        #line default
        #line hidden
        
        #line 26 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" => new ReadOnlyMemory<string>(");

        
        #line default
        #line hidden
        
        #line 26 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 26 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(");\r\n\r\n        /// <summary>Gets a read-only span containing the ");

        
        #line default
        #line hidden
        
        #line 28 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlDocAllRef));

        
        #line default
        #line hidden
        
        #line 28 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" of <see cref=\"");

        
        #line default
        #line hidden
        
        #line 28 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));

        
        #line default
        #line hidden
        
        #line 28 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\" />.</summary>\r\n        public static ReadOnlySpan<string> ");

        
        #line default
        #line hidden
        
        #line 29 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(propName));

        
        #line default
        #line hidden
        
        #line 29 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("Span => new ReadOnlySpan<string>(");

        
        #line default
        #line hidden
        
        #line 29 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(fieldName));

        
        #line default
        #line hidden
        
        #line 29 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(");\r\n\r\n        /// <summary>Represents the largest possible number of characters produced by ");

        
        #line default
        #line hidden
        
        #line 31 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlDocAction));

        
        #line default
        #line hidden
        
        #line 31 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" a <see cref=\"");

        
        #line default
        #line hidden
        
        #line 31 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));

        
        #line default
        #line hidden
        
        #line 31 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\" /> value to string, based on defined members.</summary>\r\n        public const int MaxCharsLength = ");

        
        #line default
        #line hidden
        
        #line 32 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Values.Max(x => keySelector(x).Length)));

        
        #line default
        #line hidden
        
        #line 32 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(";\r\n");

        
        #line default
        #line hidden
        
        #line 33 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"

        foreach (var curr in Model.Values)
        {

        
        #line default
        #line hidden
        
        #line 38 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\r\n        /// <summary>The string representation of <see cref=\"");

        
        #line default
        #line hidden
        
        #line 38 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));

        
        #line default
        #line hidden
        
        #line 38 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 38 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberName));

        
        #line default
        #line hidden
        
        #line 38 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\" /> ");

        
        #line default
        #line hidden
        
        #line 38 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlDocItemRef));

        
        #line default
        #line hidden
        
        #line 38 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(".</summary>\r\n        public const string ");

        
        #line default
        #line hidden
        
        #line 39 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberName));

        
        #line default
        #line hidden
        
        #line 39 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" = \"");

        
        #line default
        #line hidden
        
        #line 39 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(keySelector(curr)));

        
        #line default
        #line hidden
        
        #line 39 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\";\r\n");

        
        #line default
        #line hidden
        
        #line 40 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"

        }

        
        #line default
        #line hidden
        
        #line 43 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("    }\r\n\r\n    /// <summary>Provides static values for <see cref=\"");

        
        #line default
        #line hidden
        
        #line 45 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));

        
        #line default
        #line hidden
        
        #line 45 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\" /> UTF-8 encoded ");

        
        #line default
        #line hidden
        
        #line 45 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlDocAllRef));

        
        #line default
        #line hidden
        
        #line 45 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(".</summary>\r\n    public static partial class Utf8");

        
        #line default
        #line hidden
        
        #line 46 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(className));

        
        #line default
        #line hidden
        
        #line 46 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\r\n    {\r\n        /// <summary>Represents the largest possible number of bytes produced by ");

        
        #line default
        #line hidden
        
        #line 48 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlDocAction));

        
        #line default
        #line hidden
        
        #line 48 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" a <see cref=\"");

        
        #line default
        #line hidden
        
        #line 48 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));

        
        #line default
        #line hidden
        
        #line 48 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\" /> value to UTF-8 string, based on defined members.</summary>\r\n        public const int MaxBytesLength = ");

        
        #line default
        #line hidden
        
        #line 49 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Values.Max(x => _utf8Encoding.GetByteCount(keySelector(x)))));

        
        #line default
        #line hidden
        
        #line 49 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(";\r\n");

        
        #line default
        #line hidden
        
        #line 50 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"

        foreach (var curr in Model.Values)
        {

        
        #line default
        #line hidden
        
        #line 55 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\r\n        /// <summary>The UTF-8 representation of <see cref=\"");

        
        #line default
        #line hidden
        
        #line 55 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));

        
        #line default
        #line hidden
        
        #line 55 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(".");

        
        #line default
        #line hidden
        
        #line 55 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberName));

        
        #line default
        #line hidden
        
        #line 55 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("\" /> ");

        
        #line default
        #line hidden
        
        #line 55 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(xmlDocItemRef));

        
        #line default
        #line hidden
        
        #line 55 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(".</summary>\r\n        public static ReadOnlySpan<byte> ");

        
        #line default
        #line hidden
        
        #line 56 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberName));

        
        #line default
        #line hidden
        
        #line 56 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" => new byte[");

        
        #line default
        #line hidden
        
        #line 56 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(_utf8Encoding.GetByteCount(keySelector(curr))));

        
        #line default
        #line hidden
        
        #line 56 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("] { ");

        
        #line default
        #line hidden
        
        #line 56 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(this.ToStringHelper.ToStringWithCulture(_utf8Encoding.GetBytes(keySelector(curr)).JoinToString()));

        
        #line default
        #line hidden
        
        #line 56 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write(" };\r\n");

        
        #line default
        #line hidden
        
        #line 57 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"

        }

        
        #line default
        #line hidden
        
        #line 60 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"
this.Write("    }\r\n");

        
        #line default
        #line hidden
        
        #line 61 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\NamesInternal.ttinclude"

    }

        
        #line default
        #line hidden
        
        #line 1 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfo\DefaultBlock.ttinclude"

    private static readonly Encoding _utf8Encoding = Encoding.UTF8;

    private void WriteDefaultBlock()
    {
        if (HasMainGenerator)
        {
            WriteNames(
                "Name",
                "members names",
                "name",
                "converting",
                x => x.MemberName,
                isName: true);
        }

        if (HasMainGenerator && Model.HasSerializationValue)
        {
            WriteNames(
                "SerializedValue",
                "serialized members values",
                "serialized value",
                "serializing",
                x => x.ResolvedSerializedValue,
                isName: false);
        }

        if ((HasMainGenerator && Model.HasJsonProperty) ||
            (Model.SelectedGenerators & SelectedGenerators.JsonConverter) != 0 && Model.IsFlags)
        {
            WriteNames(
                "JsonValue",
                "serialized members values",
                "serialized value",
                "serializing",
                x => x.ResolvedJsonValue,
                isName: false);
        }
    }

        
        #line default
        #line hidden
        
        #line 42 "C:\Users\skarl\source\repos\github\skarllot\EnumUtilities\gen\EnumUtilities.Generators\CodeWriters\EnumInfoWriter.tt"

    public EnumInfoWriter(StringBuilder builder) : base(builder)
    {
    }

    private bool HasMainGenerator => (Model.SelectedGenerators & SelectedGenerators.MainGenerator) ==
                                     SelectedGenerators.MainGenerator;

    public override string GetFileName() => $"{Model.Namespace ?? "_"}.{Model.Name}EnumInfo.g.cs";

    protected override bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != 0 ||
        ((model.SelectedGenerators & SelectedGenerators.JsonConverter) != 0 && model.IsFlags);

        
        #line default
        #line hidden
    }
    
}
