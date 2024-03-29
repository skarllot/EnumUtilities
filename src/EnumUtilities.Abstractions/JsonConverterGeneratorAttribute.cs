﻿using System.Diagnostics.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities;

[AttributeUsage(AttributeTargets.Enum)]
[ExcludeFromCodeCoverage]
public sealed class JsonConverterGeneratorAttribute : Attribute
{
    public bool AllowIntegerValues { get; set; } = true;
    public object? DeserializationFailureFallbackValue { get; set; }
}
