using AwesomeAssertions;
using Raiqub.Generators.EnumUtilities.Formatters;

namespace Raiqub.Generators.EnumUtilities.Tests.Formatters;

public class EnumStringFormatterTest
{
    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldFormatSingleItemCorrectly()
    {
        // Arrange
        var names = new[] { "Green", "Blue", "Red" };
        Span<FoundMember> foundItems = stackalloc FoundMember[1];
        foundItems[0] = new FoundMember(false, 1); // "Blue"
        var count = names[1].Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(names, [], foundItems, count);

        // Assert
        result.Should().Be("Blue");
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldFormatMultipleItemsCorrectly()
    {
        // Arrange
        var names = new[] { "Green", "Blue", "Red" };
        Span<FoundMember> foundItems = stackalloc FoundMember[3];
        foundItems[0] = new FoundMember(false, 0); // "Green"
        foundItems[1] = new FoundMember(false, 1); // "Blue"
        foundItems[2] = new FoundMember(false, 2); // "Red"
        var count = names[0].Length + names[1].Length + names[2].Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(names, [], foundItems, count);

        // Assert
        result.Should().Be("Red, Blue, Green"); // Note: reverse order of write
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldHandleTwoItems()
    {
        // Arrange
        var names = new[] { "Green", "Blue", "Red" };
        Span<FoundMember> foundItems = stackalloc FoundMember[2];
        foundItems[0] = new FoundMember(false, 1); // "Blue"
        foundItems[1] = new FoundMember(false, 2); // "Red"
        var count = names[1].Length + names[2].Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(names, [], foundItems, count);

        // Assert
        result.Should().Be("Red, Blue");
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldThrowOverflowException_WhenCountExceedsIntMax()
    {
        var names = new[] { "Green", "Blue", "Red" };

        Assert.Throws<OverflowException>(() =>
        {
            Span<FoundMember> foundItems = stackalloc FoundMember[2];
            foundItems[0] = new FoundMember(false, 0);
            foundItems[1] = new FoundMember(false, 1);

            var count = int.MaxValue; // Force overflow in `checked`

            EnumStringFormatter.WriteMultipleFoundFlagsNames(names, [], foundItems, count);
        });
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldFormatSingleCompositeItemCorrectly()
    {
        // Arrange
        var singleNames = new string?[] { "Green", "Blue", "Red" };
        var compositeNames = new[] { "GreenBlue" };
        Span<FoundMember> foundItems = stackalloc FoundMember[1];
        foundItems[0] = new FoundMember(true, 0);
        var count = compositeNames[0].Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(singleNames, compositeNames, foundItems, count);

        // Assert
        result.Should().Be("GreenBlue");
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldUseCompositeNameWhenItIsFirstInFoundItems()
    {
        // Arrange
        var singleNames = new string?[] { "Green", "Blue", "Red" };
        var compositeNames = new[] { "GreenBlue" };
        Span<FoundMember> foundItems = stackalloc FoundMember[2];
        foundItems[0] = new FoundMember(true, 0);  // composite "GreenBlue"
        foundItems[1] = new FoundMember(false, 2); // single "Red"
        var count = compositeNames[0].Length + singleNames[2]!.Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(singleNames, compositeNames, foundItems, count);

        // Assert
        result.Should().Be("GreenBlue, Red");
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldUseCompositeNameWhenItIsLastInFoundItems()
    {
        // Arrange
        var singleNames = new string?[] { "Green", "Blue", "Red" };
        var compositeNames = new[] { "GreenBlue" };
        Span<FoundMember> foundItems = stackalloc FoundMember[2];
        foundItems[0] = new FoundMember(false, 2); // single "Red"
        foundItems[1] = new FoundMember(true, 0);  // composite "GreenBlue"
        var count = singleNames[2]!.Length + compositeNames[0].Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(singleNames, compositeNames, foundItems, count);

        // Assert
        result.Should().Be("Red, GreenBlue");
    }
}
