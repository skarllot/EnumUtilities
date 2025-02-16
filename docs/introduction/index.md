# Getting Started

Welcome to Enum Utilities! This guide will help you get up and running quickly.

## What is a Source Generator?

A **Source Generator** is a component that runs during compilation to inspect and produce C# source code. It is bundled with your project as a .NET Standard assembly that the C# compiler loads. The generated code is compiled into your final assembly just like any other source code in your project. If you use Visual Studio, you can see it under **Dependencies \ Analyzers**.

## Quick Example

1. Add the `[EnumGenerator]` attribute to your enum:

```csharp
[EnumGenerator]
public enum Categories
{
    Electronics,
    Food,
    Automotive,
    Arts,
    BeautyCare,
    Fashion
}
```

2. The source generator will create helpful extension classes, parsing utilities, validation, etc. in the build output, fully compiled as part of your assembly. You can inspect the generated code under the `Dependencies/Analyzers` node in Visual Studio.

3. For example, you can use `CategoriesFactory.Parse("Food")` to parse from string to an enum, or call `CategoriesExtensions.ToStringFast()` to get a fast string representation.

## Next Steps

- Explore the [Members Attributes](../members-attributes/) section to see how `[EnumMember]`, `[Description]`, and `[Display]` can enrich your enums.
- Check out the [JSON Serialization](../json/) docs for details on adding an advanced JSON converter to your enums.
- Have fun simplifying your enums with Enum Utilities!

## Support

If you have any issues, reach out on [GitHub Issues](https://github.com/skarllot/EnumUtilities/issues) or open a Pull Request. Enjoy!

