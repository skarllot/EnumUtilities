# EnumMemberAttribute

When you apply [`[EnumMember]`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute) to an enum member, the source generator can create additional methods that use the custom string value specified. If a member is not decorated with `[EnumMember]`, the generator will simply use the literal enum name instead.

## Example

```csharp
using System.Runtime.Serialization;

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

This will generate code on the following classes:
- [PaymentMethodExtensions](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.PaymentMethodExtensions.g.cs)
- [PaymentMethodFactory](https://github.com/skarllot/EnumUtilities/blob/main/tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/Raiqub.Generators.EnumUtilities.EnumUtilitiesGenerator/Models.PaymentMethodFactory.g.cs)

## Additional Features

1. **`ToEnumMemberValue()`**
   - A generated method in `<EnumName>Extensions` that returns the `[EnumMember]` `Value` (or the literal name if none is provided).
   - Example:
     ```csharp
     string text = PaymentMethod.Credit.ToEnumMemberValue();
     // text == "Credit card"
     ```

2. **`TryParseFromEnumMemberValue()`**
   - A generated method in `<EnumName>Factory` that parses a string based on the `[EnumMember]` `Value`, falling back to the literal name otherwise.
   - Example:
     ```csharp
     bool success = PaymentMethodFactory
         .TryParseFromEnumMemberValue("Debit card", out var result);
     // success == true, result == PaymentMethod.Debit
     ```

## When to Use

Use `EnumMemberAttribute` when you want an enum’s string representation to differ from its actual member name, commonly for:
- User-facing text (e.g., "Credit card" vs. `Credit`)
- Integration with external systems or data contracts that require specific string values

This approach simplifies code maintenance and keeps your domain logic aligned with external or user-friendly naming conventions.

