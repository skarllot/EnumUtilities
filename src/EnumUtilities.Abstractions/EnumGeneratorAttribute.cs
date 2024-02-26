using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities;

[AttributeUsage(AttributeTargets.Enum)]
[ExcludeFromCodeCoverage]
public sealed class EnumGeneratorAttribute : Attribute;
