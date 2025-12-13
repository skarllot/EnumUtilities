# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

EnumUtilities is a C# Roslyn source generator that creates extension methods, factory methods, validation utilities, and JSON converters for enum types. The generator uses T4 templates and incremental source generation to produce high-performance, reflection-free code at compile time.

**Package:** Raiqub.Generators.EnumUtilities (distributed via NuGet)
**Language:** C# 13
**Targets:** netstandard2.0, net6.0, net8.0, net9.0

## Build Commands

### Prerequisites
- The project requires .NET SDK 9.0.307 (see global.json)
- If you don't have 9.0.307, you can use 9.0.308 or update global.json to match an installed SDK
- Dependencies use lock files (RestorePackagesWithLockFile=true)

### Essential Commands

```bash
# Restore dependencies (locked mode)
dotnet restore --locked-mode

# Build the solution
dotnet build

# Run all tests
dotnet test

# Run tests with code coverage
dotnet test /p:CollectCoverage=true

# Run specific test project
dotnet test tests/EnumUtilities.Generators.Tests
dotnet test tests/EnumUtilities.Generators.IntegrationTests

# Run single test
dotnet test --filter "FullyQualifiedName~TestClassName.TestMethodName"

# Build and pack NuGet package
dotnet pack

# Clean build artifacts
dotnet clean
```

### Working with T4 Templates

The code writers use T4 templates (`.tt` files). When modifying templates in `gen/EnumUtilities.Generators.Roslyn4_4_0/CodeWriters/`:

1. Edit the `.tt` file (not the `.cs` file)
2. The `.cs` file is generated from the `.tt` file
3. Visual Studio will auto-regenerate, or manually trigger regeneration
4. **After T4 generation**, run the cleanup script to remove unwanted lines:
   ```powershell
   .\tools\t4-cleanup.ps1
   ```
   This script removes `#line` directives and collapses multiple blank lines in all generated `.cs` files

## Architecture

### Project Structure

- **gen/** - Source generators (two Roslyn versions for compatibility)
  - `EnumUtilities.Generators.Roslyn4_3_1/` - Legacy generator (Roslyn 4.3.1, used with net6.0)
  - `EnumUtilities.Generators.Roslyn4_4_0/` - Current generator (Roslyn 4.4.0, used with net8.0+)
- **src/** - Runtime library
  - `EnumUtilities/` - Marker attributes and runtime helper utilities
- **tests/** - Test projects
  - `EnumUtilities.Generators.Tests/` - Unit tests for generator logic (xUnit, net8.0)
  - `EnumUtilities.Generators.IntegrationTests/` - End-to-end tests (xUnit, net6.0+net8.0)
  - `EnumUtilities.Tests/` - Runtime functionality tests
- **perf/** - BenchmarkDotNet performance tests
- **docs/** - Documentation site (VitePress)

### Generator Pipeline

The source generator follows this execution flow:

1. **Syntax Analysis** - Fast filter for enum declarations with `[EnumGenerator]` or `[JsonConverterGenerator]` attributes
2. **Semantic Analysis** - Extract enum metadata (members, values, attributes) via `EnumToGenerate.FromSymbol()`
3. **Incremental Filtering** - Remove invalid enums, combine with build configuration (RootNamespace)
4. **Code Generation** - Five code writers generate five output files per enum:
   - `{EnumName}EnumInfo.g.cs` - Metadata arrays (Names, Values collections)
   - `{EnumName}Extensions.g.cs` - Fast utility methods (ToStringFast, IsDefined, Interlocked operations)
   - `{EnumName}Factory.g.cs` - Parsing methods (Parse, TryParse, GetValues, GetNames)
   - `{EnumName}Validation.g.cs` - Validation methods (IsDefined with various overloads)
   - `{EnumName}JsonConverter.g.cs` - JSON converter (optional, only if requested)

### Key Components

**Generator Entry Point:**
- `gen/EnumUtilities.Generators.Roslyn4_4_0/EnumUtilitiesGenerator.cs` - Main IIncrementalGenerator implementation

**Data Models (Immutable Records):**
- `Models/EnumToGenerate.cs` - Complete enum metadata
- `Models/EnumValue.cs` - Per-member metadata
- `Models/DisplayAttribute.cs` - Display attribute metadata
- `Models/JsonConverterGeneratorOptions.cs` - JSON converter configuration

**Code Writers (T4-based):**
- `CodeWriters/EnumExtensionsWriter.tt/.cs` - Extensions generation
- `CodeWriters/EnumFactoryWriter.tt/.cs` - Factory/parsing generation
- `CodeWriters/EnumValidationWriter.tt/.cs` - Validation generation
- `CodeWriters/EnumJsonConverterWriter.tt/.cs` - JSON converter generation
- `CodeWriters/EnumInfoWriter.tt/.cs` - Metadata generation
- `CodeWriters/Extensions/*.ttinclude` - Reusable T4 template blocks

### Multi-Version Support

The project maintains two complete generator implementations:

- **Roslyn 4.3.1** - Legacy API using `CreateSyntaxProvider`, used with .NET 6.0
- **Roslyn 4.4.0** - Modern API using `ForAttributeWithMetadataName`, used with .NET 8.0+

Both versions:
- Generate identical output code
- Use the same namespace (`Raiqub.Generators.EnumUtilities`)
- Are packaged together in the NuGet package
- Only one is activated per compilation (based on Roslyn version)

### Testing Architecture

**Integration Tests Special Configuration:**
- Target frameworks: net6.0 (uses Roslyn 4.3.1) and net8.0 (uses Roslyn 4.4.0)
- `EmitCompilerGeneratedFiles=true` on net8.0 to output generated files to `Generated/` folder
- Generated files are excluded from compilation but committed for inspection
- Each target framework tests a different generator version

## Code Patterns and Conventions

### Attribute Support

The generator recognizes these attributes on enum members:
- `[EnumMember(Value = "...")]` - Custom serialization value
- `[Description("...")]` - Description text
- `[Display(Name = "...", ShortName = "...", ...)]` - Display metadata
- `[JsonPropertyName("...")]` - JSON property name

### Generated Code Characteristics

- All generated code is marked with `[GeneratedCode]` attribute
- Excluded from code coverage with `[ExcludeFromCodeCoverage]`
- Uses switch expressions for O(1) performance
- Supports both regular enums and `[Flags]` enums
- Nullable annotations enabled
- File-scoped namespaces (when applicable)

### Incremental Generation

The generator uses tracking names for incremental caching:
- `ExtractForEnumGeneratorAttribute` - Initial extraction
- `ExtractForJsonConverterGeneratorAttribute` - JSON converter extraction
- `RemoveNulls` - Filter invalid symbols
- `FillRootNamespace` - Combine with build config
- `SkipGeneratedByMainGenerator` - Avoid duplication

Changes to these pipelines should maintain cache invalidation correctness.

## Development Guidelines

### When Modifying Generators

1. **Both Versions:** If changing generator logic, update BOTH Roslyn4_3_1 and Roslyn4_4_0 versions to maintain compatibility
2. **Model Changes:** Changes to `Models/` typically require updates to code writers
3. **Template Changes:** Edit `.tt` files, not generated `.cs` files. After T4 regeneration, run `.\tools\t4-cleanup.ps1` to clean up the generated `.cs` files
4. **Test Coverage:** Add integration tests in `tests/EnumUtilities.Generators.IntegrationTests/Models/`
5. **Generated Output:** Review generated files in `tests/EnumUtilities.Generators.IntegrationTests/Generated/` after changes

### When Adding Features

1. Add new enum test case in `tests/EnumUtilities.Generators.IntegrationTests/Models/`
2. Update appropriate code writer template(s) in `gen/EnumUtilities.Generators.Roslyn4_4_0/CodeWriters/`
3. Add test cases in `tests/EnumUtilities.Generators.IntegrationTests/`
4. Consider performance impact (check `perf/EnumUtilities.Benchmark/`)
5. Update documentation in `docs/`

### Code Style

- Enforced via `.editorconfig` (automatically applied by most IDEs)
- Warnings treated as errors (`TreatWarningsAsErrors=true`)
- Nullable reference types enabled
- Implicit usings enabled
- C# 13 language version

### Commit Conventions

Follow [Conventional Commits](https://www.conventionalcommits.org/):
- `feat:` - New features
- `fix:` - Bug fixes
- `perf:` - Performance improvements
- `test:` - Test changes
- `docs:` - Documentation changes
- `refactor:` - Code refactoring
- `ci:` - CI/CD changes

## Common Issues and Solutions

### Generator Not Running
- Ensure the enum has `[EnumGenerator]` or `[JsonConverterGenerator]` attribute
- Verify enum is public or internal (not private)
- Check that project references the EnumUtilities package
- Clean and rebuild the solution

### Generated Files Not Visible
- Integration tests output to `Generated/` folder only on net8.0 target
- In consuming projects, generated files are in `obj/{config}/{tfm}/generated/`
- Use "Show All Files" in Solution Explorer or navigate to obj folder directly

### Tests Failing After Generator Changes
- Rebuild solution (`dotnet build`)
- Clean and rebuild if incremental generation cached old results
- Check that both Roslyn versions were updated for cross-version compatibility
- Review generated output in `tests/EnumUtilities.Generators.IntegrationTests/Generated/`

### T4 Template Not Regenerating
- Visual Studio: Right-click .tt file → "Run Custom Tool"
- Or rebuild the project containing the template
- Ensure T4 tooling is installed

## Key Files Reference

**Entry Points:**
- `gen/EnumUtilities.Generators.Roslyn4_4_0/EnumUtilitiesGenerator.cs:13` - Generator Initialize() method
- `gen/EnumUtilities.Generators.Roslyn4_4_0/Models/EnumToGenerate.cs:117` - FromSymbol() semantic analysis

**Example Outputs:**
- `tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/*/Models.CategoriesExtensions.g.cs`
- `tests/EnumUtilities.Generators.IntegrationTests/Generated/Raiqub.Generators.EnumUtilities/*/Models.CategoriesFactory.g.cs`

**Test Enums:**
- `tests/EnumUtilities.Generators.IntegrationTests/Models/Categories.cs` - Basic enum
- `tests/EnumUtilities.Generators.IntegrationTests/Models/Colours.cs` - Flags enum
- `tests/EnumUtilities.Generators.IntegrationTests/Models/Season.cs` - JSON converter example
