# JSON Serialization

Raiqub Enum Utilities makes it easy to customize JSON serialization and deserialization for your enums. By adding `[JsonConverterGenerator]`, the source generator can produce specialized converters that keep JSON I/O aligned with [`[JsonPropertyName]`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonpropertynameattribute), [`[EnumMember]`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute), or the literal member names.

## Example

```csharp
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverterGenerator]
[JsonConverter(typeof(SeasonJsonConverter))]
public enum Season
{
    [JsonPropertyName("springTime")]
    [EnumMember(Value = "🌱")]
    Spring,

    [EnumMember(Value = "☀️")]
    Summer,

    [EnumMember(Value = "🍂")]
    Autumn,

    [EnumMember(Value = "⛄")]
    Winter
}
```

Here, `[JsonPropertyName("springTime")]` takes precedence over `[EnumMember]` and the literal `Spring`, so it’s serialized as `springTime`. Meanwhile, `Summer` defaults to `\u2600\uFE0F` (Unicode for ☀️).

This will generate code on the following classes:
- [SeasonJsonConverter](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.SeasonJsonConverter.g.cs)
- [SeasonExtensions](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.SeasonExtensions.g.cs)
- [SeasonFactory](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.SeasonFactory.g.cs)

### What’s Generated?

When you decorate your enum with `[JsonConverterGenerator]`, a class like `SeasonJsonConverter` is generated at build time. This converter:

1. Reads from JSON strings or numeric values (if `AllowIntegerValues` is `true`).
2. Writes out members following `[JsonPropertyName]` → `[EnumMember]` → the member name.
3. Integrates seamlessly with `System.Text.Json`.

## Using `[JsonPropertyName]` and `[EnumMember]`

Because these attributes are recognized by the generated code, your enums can use custom string identifiers in JSON. When both attributes are present, `[JsonPropertyName]` overrides `[EnumMember]`.

### Order of Precedence for Member Names

1. `[JsonPropertyName]`
2. `[EnumMember]`
3. Literal enum name

```json
{
  "currentSeason": "springTime"
}
```

This `"springTime"` value maps back to `Season.Spring` during deserialization.

## Example Usage

```csharp
var json = JsonSerializer.Serialize(new { currentSeason = Season.Spring });
// => { "currentSeason": "springTime" }

var obj = JsonSerializer.Deserialize<SomeModel>(json);
// obj.currentSeason == Season.Spring
```

## Generator Custom Options

The `[JsonConverterGenerator]` attribute offers additional settings for your converter:

- **`AllowIntegerValues`** (default: `true`)
  - Indicates whether integer values are allowed during deserialization.
  - If `false`, numeric representations are rejected in favor of strings.

- **`IgnoreCase`** (default: `false`)
  - Specifies whether comparisons ignore case.
  - When `true`, values like `"SpringTime"` or `"springtime"` still deserialize to `Season.Spring`.

- **`DeserializationFailureFallbackValue`** (default: `null`)
  - Assigns a fallback enum member if deserialization fails.
  - If not specified, a failure triggers an exception.

```csharp
[JsonConverterGenerator(
    AllowIntegerValues = false,
    IgnoreCase = true,
    DeserializationFailureFallbackValue = (int)Season.Autumn
)]
public enum Season
{
    // ...
}
```

## When to Use

Consider `[JsonConverterGenerator]` if you:
- Prefer zero-reflection or zero-boilerplate solutions.
- Need to handle custom strings via `[JsonPropertyName]` or `[EnumMember]`.
- Want granular control over case sensitivity and integer parsing.
- Require a fallback value on deserialization errors.

By relying on source-generated JSON converters, you ensure robust, efficient integration with `System.Text.Json`, allowing your enums to behave precisely as intended.

