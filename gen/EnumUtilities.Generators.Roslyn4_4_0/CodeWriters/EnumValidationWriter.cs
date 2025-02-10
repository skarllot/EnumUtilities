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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class EnumValidationWriter : CodeWriterBase<EnumToGenerate>
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("// <auto-generated />\r\n#nullable enable\r\n\r\nusing System;\r\nusing System.Diagnostics.CodeAnalysis;\r\n\r\n#pragma warning disable CS1591 // publicly visible type or member must be documented\r\n\r\n");

    if (!string.IsNullOrEmpty(Model.Namespace))
    {
        WriteLine($"namespace {Model.Namespace}");
        WriteLine("{");
        PushIndent();
    }

            this.Write("[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]\r\n[global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(CurrentAssemblyName.Name));
            
            #line default
            #line hidden
            this.Write("\", \"");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(Append($"{CurrentAssemblyName.Version}")));
            
            #line default
            #line hidden
            this.Write("\")]\r\n");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.IsPublic ? "public" : "internal"));
            
            #line default
            #line hidden
            this.Write(" static partial class ");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Validation\r\n{\r\n    /// <summary>Returns a boolean telling whether the value of <see cref=\"");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("\"/> instance exists in the enumeration.</summary>\r\n    /// <returns><c>true</c> if the value of <see cref=\"");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("\"/> instance exists in the enumeration; <c>false</c> otherwise.</returns>\r\n    public static bool IsDefined(");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.RefName));
            
            #line default
            #line hidden
            this.Write(" value)\r\n    {\r\n        return (");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UnderlyingType));
            
            #line default
            #line hidden
            this.Write(")value switch\r\n        {\r\n");

    foreach (var curr in Model.UniqueValues)
    {

            this.Write("            ");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberValue));
            
            #line default
            #line hidden
            this.Write(" => true,\r\n");

    }

            this.Write("            _ => false\r\n        };\r\n    }\r\n\r\n    public static bool IsDefined(\r\n        [NotNullWhen(true)] string? name,\r\n        StringComparison comparisonType)\r\n    {\r\n        return name switch\r\n        {\r\n");

    foreach (var curr in Model.Values)
    {

            this.Write("            { } s when s.Equals(\"");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberName));
            
            #line default
            #line hidden
            this.Write("\", comparisonType) => true,\r\n");

    }

            this.Write("            _ => false\r\n        };\r\n    }\r\n\r\n    public static bool IsDefinedIgnoreCase([NotNullWhen(true)] string? name)\r\n    {\r\n        return IsDefined(name, StringComparison.OrdinalIgnoreCase);\r\n    }\r\n\r\n    public static bool IsDefined([NotNullWhen(true)] string? name)\r\n    {\r\n        return name switch\r\n        {\r\n");

    foreach (var curr in Model.Values)
    {

            this.Write("            \"");
            
            this.Write(this.ToStringHelper.ToStringWithCulture(curr.MemberName));
            
            #line default
            #line hidden
            this.Write("\" => true,\r\n");

    }

            this.Write("            _ => false\r\n        };\r\n    }\r\n}\r\n");

    if (!string.IsNullOrEmpty(Model.Namespace))
    {
        PopIndent();
        WriteLine("}");
    }

            return this.GenerationEnvironment.ToString();
        }

    public EnumValidationWriter(StringBuilder builder) : base(builder)
    {
    }

    public override string GetFileName() => CodeWriterHelper.GetFileName(Model, "Validation");

    protected override bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != 0;

    }
}
