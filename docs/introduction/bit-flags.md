# Flags Enums

Bit flags are a special category of enums that allow combining multiple values via bitwise operations. This can be especially useful for representing sets of permissions or other multi-select functionalities.

## Declaration

To declare a flags enum that the source generator will process, apply both the `[Flags]` attribute and `[EnumGenerator]`:

```csharp
[Flags]
[EnumGenerator]
public enum Colours
{
    Red   = 1,
    Blue  = 2,
    Green = 4
}
```

## Additional Features

With a flagged enum, the generator produces methods tailored to combined values.

### Parsing Combined Values

By default, the generator will parse comma-separated values, or attempt to parse multi-flag strings if relevant. For instance:

```csharp
var combined = ColoursFactory.Parse("Red,Green");
// returns Colours.Red | Colours.Green
```

`TryParse`, `ParseOrNull`, etc. all accommodate multi-flag parsing.

### Fast Flag Checks

The generated `<EnumName>Extensions` class includes bitwise helpers:

```csharp
bool hasFlag = Colours.Red.HasFlagFast(Colours.Blue);
// returns false

bool combinedHasFlag = (Colours.Red | Colours.Green).HasFlagFast(Colours.Red);
// returns true
```

### Interlocked Bitwise Operations

If your .NET environment is .NET 5 or higher, the generator can offer atomic `Interlocked`-style AND, OR, and compare-exchange:

```csharp
Colours current = Colours.Red | Colours.Blue;
// Interlocked OR
Colours oldValue = current.InterlockedOr(Colours.Green);
// oldValue == Colours.Red | Colours.Blue
// current == Colours.Red | Colours.Blue | Colours.Green
```

This ensures thread-safe manipulation of flags across multiple threads.

## Summary

Flags enums let you combine multiple enum members into a single value. Using the `[EnumGenerator]` with `[Flags]` broadens your enum’s capabilities with specialized parsing, fast checks, and concurrency-friendly operations.
