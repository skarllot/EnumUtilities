# Examples

This page demonstrates various ways to combine Enum Utilities features, from simple `[EnumGenerator]` usage to more advanced attribute combinations.

---
## 1. Basic Enum

```csharp
[EnumGenerator]
public enum OrderStatus
{
    Pending,
    Processing,
    Completed,
    Cancelled
}
```

- **Extensions**: `OrderStatusExtensions`
- **Parsing**: `OrderStatusFactory` with `Parse`, `TryParse`, etc.
- **Validation**: `OrderStatusValidation` with `IsDefined`

**Example Usage**:
```csharp
var status = OrderStatusFactory.Parse("Completed");
var isValid = OrderStatusValidation.IsDefined("Shipped"); // false
```

---
## 2. Flags Enum with Attributes

```csharp
[Flags]
[EnumGenerator]
public enum AccessRights
{
    None    = 0,
    Read    = 1,
    Write   = 2,
    Execute = 4
}
```

- **Flag Parsing**: `AccessRightsFactory.Parse("Read,Write")` => `AccessRights.Read | AccessRights.Write`
- **Fast Flag Check**: `(AccessRights.Read | AccessRights.Write).HasFlagFast(AccessRights.Read)` => `true`
- **Interlocked**: Provided for concurrency usage

---
## 3. EnumMember for Custom String Values

```csharp
using System.Runtime.Serialization;

[EnumGenerator]
public enum ShipmentType
{
    [EnumMember(Value = "Ground Shipping")]
    Ground,
    [EnumMember(Value = "Next-day Air")]
    Air,
    [EnumMember(Value = "No Rush")]
    Slow
}
```

- **`ShipmentTypeExtensions.ToEnumMemberValue()`** => `"Ground Shipping"` for `Ground`
- **`ShipmentTypeFactory.TryParseFromEnumMemberValue("Next-day Air", out var type)`** => `true` and `type == ShipmentType.Air`

---
## 4. DescriptionAttribute for Friendly Text

```csharp
using System.ComponentModel;

[EnumGenerator]
public enum PaymentMethod
{
    [Description("Credit or Debit card, electronically processed")]
    Card,
    [Description("Cash payment at the store")]
    Cash,
    Cheque
}
```

- **`PaymentMethodExtensions.GetDescription()`** => `"Credit or Debit card, electronically processed"` for `Card`
- **`PaymentMethodFactory.TryCreateFromDescription("Cash payment at the store", out var pm)`** => `true` and `pm == PaymentMethod.Cash`

---
## 5. DisplayAttribute with Localization

```csharp
using System.ComponentModel.DataAnnotations;

[EnumGenerator]
public enum Days
{
    [Display(
        Name = nameof(Strings.MondayName),
        ShortName = nameof(Strings.MondayShort),
        Description = nameof(Strings.MondayDesc),
        ResourceType = typeof(Strings)
    )]
    Monday,
    [Display(ShortName = "Tue")]
    Tuesday
}
```

- **`DaysExtensions.GetDisplayName(Days.Monday)`** => e.g., `"Lunes"` if the resource is Spanish
- **`DaysFactory.TryCreateFromDisplayShortName("Tue", out var day)`** => `day == Days.Tuesday`

---
## 6. JSON Serialization

```csharp
using System.Text.Json.Serialization;

[JsonConverterGenerator(AllowIntegerValues = false, IgnoreCase = true)]
[JsonConverter(typeof(SeasonJsonConverter))]
public enum Season
{
    [JsonPropertyName("springTime")]
    Spring,
    [EnumMember(Value = "\u2600\uFE0F")] // ☀️
    Summer
}
```

- **Serialization**: `Spring` => `"springTime"`
- **Deserialization**: `"\u2600\uFE0F"` => `Season.Summer`

---
## 7. Metadata Class

```csharp
[EnumGenerator]
public enum ProductCategory
{
    Electronics,
    Food,
    BeautyCare
}
```

- **`ProductCategoryMetadata.Name.Electronics`** => `"Electronics"`
- **`ProductCategoryMetadata.Utf8Name.Food`** => a byte array representing `"Food"`

**When to Use**: Low-level string or byte manipulations.

---
## Summary

These examples illustrate the range of possibilities with Enum Utilities. Whether you need simple parsing, advanced localization, custom JSON serialization, or efficient bitwise operations on flags, the code generator seamlessly integrates with your workflow.
