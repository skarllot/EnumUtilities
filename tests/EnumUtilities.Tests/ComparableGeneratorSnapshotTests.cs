namespace Raiqub.Generators.EnumUtilities.Tests;

[UsesVerify]
public class ComparableGeneratorSnapshotTests
{
    [Fact]
    public Task GeneratesMembersForMarkedEnum()
    {
        const string source = @"using Raiqub.Generators.EnumUtilities;

namespace TestNamespace;

[EnumGenerator]
public enum Colour
{
    Red,
    Blue
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task DoesNotGenerateMembersWithoutAttribute()
    {
        const string source = @"namespace TestNamespace;

public enum Colour
{
    Red,
    Blue
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task DoesNotGenerateForEnumWithoutMembers()
    {
        const string source = @"using Raiqub.Generators.EnumUtilities;

namespace TestNamespace;

[EnumGenerator]
public enum Colour
{
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task DoesNotGenerateMembersWhenMissingUsing()
    {
        const string source = @"namespace TestNamespace;

[EnumGenerator]
public enum Colour
{
    Red,
    Blue
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task GeneratesMembersForTwoEnumsOnSameFile()
    {
        const string source = @"using Raiqub.Generators.EnumUtilities;

namespace TestNamespace;

[EnumGenerator]
public enum Colour
{
    Red,
    Blue
}

[EnumGenerator]
public enum HumanStates
{
    Idle,
    Working,
    Sleeping,
    Eating,
    Dead
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task GeneratesMembersForOneEnumWhenTwoExistsOnSameFile()
    {
        const string source = @"using Raiqub.Generators.EnumUtilities;

namespace TestNamespace;

public enum Colour
{
    Red,
    Blue
}

[EnumGenerator]
public enum HumanStates
{
    Idle,
    Working,
    Sleeping,
    Eating,
    Dead
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task GeneratesMembersWhenEnumHasRepeatedValues()
    {
        const string source = @"using Raiqub.Generators.EnumUtilities;

namespace TestNamespace;

[EnumGenerator]
public enum HumanStates
{
    Idle = 1,
    Working,
    Sleeping,
    Eating,
    Dead,
    Relaxing = 1
}";

        return TestHelper.Verify(source);
    }
}