# Generated Metadata

In addition to extension and parsing classes, Enum Utilities can generate a **metadata class** for your enum that provides constant or static information about each member. This class includes:

1. **Max String or Byte Length** – The largest possible size of the string or UTF-8 representation of an enum member.
2. **UTF-8 Span Fields** – Precomputed byte arrays for each member’s name to speed up formatting operations.
3. **Constant Strings** – If configured, each member’s name or an alternate text can be stored as a public constant.

## Example

Below is a simplified snippet of a generated metadata class for an enum `Categories`. All members are generated at compile time, providing a comprehensive, reflection-free resource for your enum’s textual data:

```csharp
/// <summary>
/// Provides metadata for <see cref="Categories" /> enumeration.
/// </summary>
[GeneratedCode("Raiqub.Generators.EnumUtilities", "1.10.0.0")]
public static partial class CategoriesMetadata
{
    /// <summary>
    /// Provides constant values for <see cref="Categories" /> members.
    /// </summary>
    public static partial class Name
    {
        public const string Electronics = "Electronics";
        public const string Food = "Food";
        public const string Automotive = "Automotive";
        // ...
    }

    /// <summary>
    /// Provides static values for <see cref="Categories" /> UTF-8 encoded members.
    /// </summary>
    public static partial class Utf8Name
    {
        public static ReadOnlySpan<byte> Electronics => new byte[] { 69, 108, 101, 99, 116, 114, 111, 110, 105, 99, 115 };
        // ...
    }
}
```

## When to Use

These metadata classes can be especially helpful for low-level operations where you rely on string lengths, raw UTF-8 data, or reflection-free name lookups. The `Utf8Name` class, in particular, helps avoid unnecessary allocations or string conversions, making it well-suited to performance-critical scenarios.

Additionally, having compile-time references for each member’s string name helps prevent typos and ensures consistent usage throughout your codebase.
