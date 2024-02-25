namespace Raiqub.Generators.EnumUtilities;

[AttributeUsage(AttributeTargets.Enum)]
public sealed class EnumGeneratorAttribute : Attribute
{
    public bool GenerateJsonConverter { get; set; }
}
