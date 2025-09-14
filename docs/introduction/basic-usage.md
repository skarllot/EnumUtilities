# Basic Usage

This section takes a closer look at the code generated for a straightforward enum where no special .NET attributes (like `[EnumMember]`, `[Description]`, or `[Display]`) are applied.

## Overview

When you add `[EnumGenerator]` to an enum, a set of classes is automatically generated:

- **&lt;EnumName>Extensions** – Provides extension methods for rapid string conversions, pattern matching, and concurrency utilities.
- **&lt;EnumName>Factory** – Offers versatile parsing methods for `string` and `ReadOnlySpan<char>`, and also enables you to list all members.
- **&lt;EnumName>Validation** – Helps verify whether specific string or numeric inputs match defined members.

These classes are created at compile time, which eliminates the need for reflection-based code or extensive boilerplate.

## Features

Here’s an example of a simple enum:

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

Below are the key features you can expect from this generator.

### Parsing

A variety of parsing methods (`Parse`, `TryParse`, `ParseOrNull`) become available in `<EnumName>Factory`. These work with both `string` and `ReadOnlySpan<char>`, covering everything from user input to performance-critical parsing.

```csharp
var parsed = CategoriesFactory.Parse("Food");
// returns Categories.Food

bool success = CategoriesFactory.TryParse("Automotive", out var cat);
// success == true, cat == Categories.Automotive
```

Such methods help you handle data coming from files, APIs, or any text-based source.

### Validation

Using `<EnumName>Validation` allows you to check whether a string or enum value is recognized:

```csharp
bool isDefined = CategoriesValidation.IsDefined("Electronics");
// isDefined == true

isDefined = CategoriesValidation.IsDefined(Categories.Fashion);
// isDefined == true
```

With `IsDefined`, you can bypass unintended exceptions and gracefully handle unknown or invalid inputs.

### String Conversions

#### `ToStringFast()`

The generator provides a quick alternative to the standard `Enum.ToString()`:

```csharp
var str = Categories.Fashion.ToStringFast();
// returns "Fashion"
```

`ToStringFast()` often outperforms the built-in method, making it beneficial for scenarios with frequent conversions.

#### `GetStringLength()`

If you need the size of the string representation without creating a new string object, `GetStringLength()` comes in handy:

```csharp
int len = Categories.Electronics.GetStringLength();
// returns 11
```

This method is useful for buffer management, logging, or any scenario where you need precise control over allocations.

### Pattern Matching

The generator provides `Match` extension methods for functional-style pattern matching, eliminating the need for verbose switch statements or if-else chains:

```csharp
// Direct value matching
var message = Categories.Food.Match(
    Electronics: "Tech products available",
    Food: "Fresh food items",
    Automotive: "Car parts and accessories",
    Arts: "Creative supplies",
    BeautyCare: "Beauty products",
    Fashion: "Clothing and accessories"
);
// returns "Fresh food items"

// Function-based matching for more complex logic
var discount = Categories.Electronics.Match(
    Electronics: v => CalculateDiscount(v, 0.15),
    Food: v => CalculateDiscount(v, 0.05),
    Automotive: v => CalculateDiscount(v, 0.10),
    Arts: v => CalculateDiscount(v, 0.20),
    BeautyCare: v => CalculateDiscount(v, 0.12),
    Fashion: v => CalculateDiscount(v, 0.25)
);
```

The `Match` methods are only generated for non-flag enumerations, providing a clean and type-safe alternative to traditional conditional logic.

### Concurrent/Atomic Operations

To handle multi-threaded situations, the source generator leverages .NET’s `Interlocked` class through user-friendly wrappers:

```csharp
Categories current = Categories.Electronics;

// Atomic increment
Categories incrementedVal = current.InterlockedIncrement();

// Atomic compare-and-exchange
Categories originalVal = current.InterlockedCompareExchange(
    Categories.BeautyCare,
    Categories.Food
);
```

These operations allow you to manipulate the underlying integer of your enum in a thread-safe manner, useful in low-level systems or any environment that demands concurrency safety.

## In Summary

Even without specialized attributes, Enum Utilities streamlines core tasks such as parsing, validation, string conversion, and thread-safe operations. To discover more advanced capabilities—like custom textual values or user-friendly descriptions—explore the next sections on attributes and beyond.
