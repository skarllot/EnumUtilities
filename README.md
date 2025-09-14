# Enum Utilities

[![Build status](https://github.com/skarllot/EnumUtilities/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/skarllot/EnumUtilities/actions)
[![OpenSSF Scorecard](https://api.securityscorecards.dev/projects/github.com/skarllot/EnumUtilities/badge)](https://securityscorecards.dev/viewer/?uri=github.com/skarllot/EnumUtilities)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/EngRajabi/Enum.Source.Generator/master/LICENSE)
[![Nuget](https://img.shields.io/nuget/v/Raiqub.Generators.EnumUtilities)](https://www.nuget.org/packages/Raiqub.Generators.EnumUtilities)
[![Nuget](https://img.shields.io/nuget/dt/Raiqub.Generators.EnumUtilities?label=Nuget.org%20Downloads&style=flat-square&color=blue)](https://www.nuget.org/packages/Raiqub.Generators.EnumUtilities)

_A source generator for C# that uses Roslyn to create extensions and parsers for enumerations_

[🏃 Quickstart](#quickstart) &nbsp; | &nbsp; [📖 Documentation](https://fgodoy.me/EnumUtilities/) &nbsp; | &nbsp; [📦 NuGet](https://www.nuget.org/packages/Raiqub.Generators.EnumUtilities)

<hr />

A source generator for C# that uses Roslyn to create extensions and parsers for enumerations, allowing to get a value associated to enum member or parse back from attribute value to enum member. All code generated at compile time thus avoid using reflection or boilerplate code.

## Compatibility

Raiqub.Generators.EnumUtilities runs with Roslyn compiler so does not introduce a new dependency to your project besides a library containing the EnumGenerator attribute.

It requires at least the .NET 6 SDK to run, but you can target earlier frameworks.

## Documentation
This README aims to give a quick overview of some Raiqub Enum Utilities features. For deeper detail of available features, be sure also to check out [Documentation Page](https://fgodoy.me/EnumUtilities/).

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

This will generate 3 classes with the following methods:
- [CategoriesExtensions](./tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.CategoriesExtensions.g.cs)
  - ToStringFast(this Categories)
  - GetStringCount(this Categories)
  - IsDefined(this Categories)
  - InterlockedAdd(this ref Categories, int)
  - InterlockedDecrement(this ref Categories)
  - InterlockedIncrement(this ref Categories)
  - InterlockedCompareExchange(this ref Categories, Categories, Categories)
  - InterlockedExchange(this ref Categories, Categories)
  - Match(this Categories, ...)
- [CategoriesFactory](./tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.CategoriesFactory.g.cs)
  - Parse(string, bool = false)
  - Parse(ReadOnlySpan<char>, bool = false)
  - ParseOrNull(string?, bool = false)
  - TryParse(string?, bool, out Categories)
  - TryParse(string?, out Categories)
  - TryParse(string?, bool = false)
  - TryParse(ReadOnlySpan<char>, bool, out Categories)
  - TryParse(ReadOnlySpan<char>, out Categories)
  - TryParse(ReadOnlySpan<char>, bool = false)
  - GetValues()
  - GetNames()
- [CategoriesValidation](./tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.CategoriesValidation.g.cs)
  - IsDefined(Categories)
  - IsDefined(string?, StringComparison)
  - IsDefinedIgnoreCase(string?)
  - IsDefined(string?)

Bit flags enums are supported too:
```csharp
[Flags]
[EnumGenerator]
public enum Colours
{
    Red = 1,
    Blue = 2,
    Green = 4,
}
```

Then 3 classes will be generated with the following methods:
- [ColoursExtensions](./tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.ColoursExtensions.g.cs)
  - ToStringFast(this Colours)
  - HasFlagFast(this Colours, Colours)
  - GetStringCount(this Colours)
  - IsDefined(this Colours)
  - InterlockedAnd(this ref Colours, Colours)
  - InterlockedOr(this ref Colours, Colours)
  - InterlockedCompareExchange(this ref Colours, Colours, Colours)
  - InterlockedExchange(this ref Colours, Colours)
- [ColoursFactory](./tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.ColoursFactory.g.cs)
  - Parse(string, bool = false)
  - Parse(ReadOnlySpan<char>, bool = false)
  - ParseOrNull(string?, bool = false)
  - TryParse(string?, bool, out Categories)
  - TryParse(string?, out Categories)
  - TryParse(string?, bool = false)
  - TryParse(ReadOnlySpan<char>, bool, out Categories)
  - TryParse(ReadOnlySpan<char>, out Categories)
  - TryParse(ReadOnlySpan<char>, bool = false)
  - GetValues()
  - GetNames()
- [ColoursValidation](./tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.ColoursValidation.g.cs)
  - IsDefined(Colours)
  - IsDefined(string?, StringComparison)
  - IsDefinedIgnoreCase(string?)
  - IsDefined(string?)

All generated code are properly nullable annotated and removed from code coverage.

## Supported members attributes

The following attributes are supported:
- [`[EnumMember]`](https://fgodoy.me/EnumUtilities/members-attributes/enum-member-attribute.html)
- [`[Description]`](https://fgodoy.me/EnumUtilities/members-attributes/description-attribute.html)
- [`[Display]`](https://fgodoy.me/EnumUtilities/members-attributes/display-attribute.html)

### JSON Serialization

Besides the member name, supports the [EnumMemberAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute) and [JsonPropertyNameAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonpropertynameattribute) attributes.

Example:

```csharp
[JsonConverterGenerator]
[JsonConverter(typeof(SeasonJsonConverter))]
public enum Season
{
    [EnumMember(Value = "\ud83c\udf31")]
    Spring = 1,
    [EnumMember(Value = "\u2600\ufe0f")]
    Summer,
    [EnumMember(Value = "\ud83c\udf42")]
    Autumn,
    [EnumMember(Value = "\u26c4")]
    Winter
}
```

This will generate the following JSON converter: [SeasonJsonConverter](./tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.SeasonJsonConverter.g.cs).

## Contributing

If something is not working for you or if you think that the source file
should change, feel free to create an issue or Pull Request.
I will be happy to discuss and potentially integrate your ideas!

## License

See the [LICENSE](./LICENSE) file for details.
