# Enum Utilities

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/EngRajabi/Enum.Source.Generator/master/LICENSE) [![Nuget](https://img.shields.io/nuget/v/Raiqub.Generators.EnumUtilities)](https://www.nuget.org/packages/Raiqub.Generators.EnumUtilities) [![Nuget](https://img.shields.io/nuget/dt/Raiqub.Generators.EnumUtilities?label=Nuget.org%20Downloads&style=flat-square&color=blue)](https://www.nuget.org/packages/Raiqub.Generators.EnumUtilities)

_A source generator for C# that uses Roslyn to create extensions and parsers for enumerations_

[🏃 Quickstart](#quickstart) &nbsp; | &nbsp; [📗 Guide](#guide) &nbsp; | &nbsp; [📦 NuGet](https://www.nuget.org/packages/Raiqub.Generators.EnumUtilities)

<hr />

A source generator for C# that uses Roslyn to create extensions and parsers for enumerations, allowing to get a value associated to enum member or parse back from attribute value to enum member. All code generated at compile time thus avoid using reflection or boilerplate code.

## Compatibility

Raiqub.Generators.EnumUtilities runs with Roslyn compiler so does not introduce a new dependency to your project besides a library containing the EnumGenerator attribute.

It requires at least the .NET 6 SDK to run, but you can target earlier frameworks.

## Quickstart

Add the package to your application using

```shell
dotnet add package Raiqub.Generators.EnumUtilities
```

Adding the package will automatically add a marker attribute, `[EnumGenerator]`, to your project.

To use the generator, add the `[EnumGenerator]` attribute to an enum. For example:
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

This will generate 3 classes with the follwing methods:
- [CategoriesExtensions](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.CategoriesExtensions.g.cs)
  - ToStringFast(this Categories)
  - IsDefined(this Categories)
- [CategoriesFactory](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.CategoriesFactory.g.cs)
  - TryParse(string?, StringComparison, out Categories)
  - TryParseIgnoreCase(string?, out Categories)
  - TryParse(string?, out Categories)
  - GetValues()
  - GetNames()
- [CategoriesValidation](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.CategoriesValidation.g.cs)
  - IsDefined(Categories)
  - IsDefined(string?, StringComparison)
  - IsDefinedIgnoreCase(string?)
  - IsDefined(string?)

All generated code are properly nullable annotated and removed from code coverage.

## Guide
The following attributes are supported:

### [EnumMemberAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute)

Example:

```csharp
[EnumGenerator]
public enum PaymentMethod
{
    [EnumMember(Value = "Credit card")]
    Credit,
    [EnumMember(Value = "Debit card")]
    Debit,
    Cash,
    Cheque
}
```

This will generate the following methods:
- [PaymentMethodExtensions](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.PaymentMethodExtensions.g.cs)
  - ToEnumMemberValue(this PaymentMethod)
- [PaymentMethodFactory](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.PaymentMethodFactory.g.cs)
  - TryParseFromEnumMemberValue(string?, StringComparison, out PaymentMethod)

### [DescriptionAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.descriptionattribute)

Example:

```csharp
[EnumGenerator]
public enum PaymentMethod
{
    Credit,
    Debit,
    [Description("The payment by using physical cash")]
    Cash,
    Cheque
}
```

This will generate the following methods:
- [PaymentMethodExtensions](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.PaymentMethodExtensions.g.cs)
  - GetDescription(this PaymentMethod)
- [PaymentMethodFactory](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.PaymentMethodFactory.g.cs)
  - TryCreateFromDescription(string?, StringComparison, out PaymentMethod)

### [DisplayAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute)

Example:

```csharp
[EnumGenerator]
public enum WeekDays
{
    [Display(
        Name = nameof(Strings.MondayFull),
        ShortName = nameof(Strings.MondayShort),
        Description = nameof(Strings.MondayDescription),
        ResourceType = typeof(Strings))]
    Monday,
    [Display(ShortName = "Tue")]
    Tuesday,
    [Display]
    Wednesday,
    [Display(Name = "Thursday")]
    Thursday,
    [Display(Name = "Friday", ShortName = "Fri")]
    Friday,
    [Display(ShortName = "Sat", Description = "Almost the last day of the week")]
    Saturday,
    [Display(Description = "The last day of the week")]
    Sunday
}
```

Note that if `ResourceType` is provided the generated code will correctly get the value from resource.

This will generate the following methods:
- [WeekDaysExtensions](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.WeekDaysExtensions.g.cs)
  - GetDisplayShortName(this WeekDays)
  - GetDisplayName(this WeekDays)
  - GetDescription(this WeekDays)
- [WeekDaysFactory](./tests/EnumUtilities.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Raiqub.Generators.EnumUtilities.IntegrationTests.Models.WeekDaysFactory.g.cs)
  - TryCreateFromDisplayShortName(string?, StringComparison, out WeekDays)
  - TryCreateFromDisplayName(string?, StringComparison, out WeekDays)
  - TryCreateFromDescription(string?, StringComparison, out WeekDays)

## Contributing

If something is not working for you or if you think that the source file
should change, feel free to create an issue or Pull Request.
I will be happy to discuss and potentially integrate your ideas!

## License

See the [LICENSE](./LICENSE) file for details.