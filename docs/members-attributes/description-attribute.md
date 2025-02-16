# DescriptionAttribute

By applying the [`[Description]`](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.descriptionattribute) attribute to an enum member, Enum Utilities provides convenient methods for retrieving and parsing descriptions.

## Example

```csharp
using System.ComponentModel;

[EnumGenerator]
public enum PaymentMethod
{
    [Description("The payment by using physical cash")]
    Cash,
    Cheque
}
```

This will generate code on the following classes:
- [PaymentMethodExtensions](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.PaymentMethodExtensions.g.cs)
- [PaymentMethodFactory](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.PaymentMethodFactory.g.cs)

## Additional Features

1. **`GetDescription()`**
   - A generated extension method in `<EnumName>Extensions` that reads the text specified by `[Description("...")]`.
   - If `[Description]` is omitted on a member, the generator returns `null`.

2. **`TryCreateFromDescription()`**
   - A method in `<EnumName>Factory` that attempts to parse a string back into the enum based on the corresponding `DescriptionAttribute`.
   - Example:
     ```csharp
     bool success = PaymentMethodFactory.TryCreateFromDescription(
         "The payment by using physical cash",
         out var method
     );
     // success == true
     // method == PaymentMethod.Cash
     ```

## When to Use

Use `DescriptionAttribute` when you want a user-friendly label or explanation for an enum member, often displayed in UIs or printed in logs. This attribute is straightforward to apply and makes your enum values more descriptive for end users or developers.

