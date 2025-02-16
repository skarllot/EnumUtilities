# DisplayAttribute

When you apply [`[Display]`](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute) to an enum member, Enum Utilities can generate methods that utilize each property of `DisplayAttribute`:

- **Name**
- **ShortName**
- **Description**
- **ResourceType** _(optional, for resource-based localization)_

## Example

```csharp
using System.ComponentModel.DataAnnotations;

[EnumGenerator]
public enum WeekDays
{
    [Display(
        Name = nameof(Strings.MondayFull),
        ShortName = nameof(Strings.MondayShort),
        Description = nameof(Strings.MondayDescription),
        ResourceType = typeof(Strings)
    )]
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

By setting [`ResourceType`](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute.resourcetype#system-componentmodel-dataannotations-displayattribute-resourcetype) and referencing a .NET resource class (like `Strings` above), the generator calls the resource manager to retrieve localized values for `Name`, `ShortName`, or `Description`. This simplifies translation of enum fields.

This will generate code on the following classes:
- [WeekDaysExtensions](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.WeekDaysExtensions.g.cs)
- [WeekDaysFactory](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.WeekDaysFactory.g.cs)

## Additional Features

1. **`GetDisplayName()`**
   - Retrieves `DisplayAttribute.Name`. If `ResourceType` is set, it attempts to get the localized text.

2. **`GetDisplayShortName()`**
   - Returns `DisplayAttribute.ShortName`, localized if a `ResourceType` is provided.

3. **`GetDescription()`**
   - Reads `DisplayAttribute.Description`, also supporting localization via `ResourceType`.

4. **`TryCreateFromDisplayName()`, `TryCreateFromDisplayShortName()`, `TryCreateFromDescription()`**
   - Methods in `<EnumName>Factory` that parse an input string to the matching enum member. They also factor in localized values when available.

## When to Use

`DisplayAttribute` is ideal for presenting user-friendly text in UIs, logs, or exported data. By specifying a `ResourceType`, you have a convenient way to localize enum values, short names, and descriptions into multiple languages without duplicating code. This approach unites domain logic with customizable presentation.
