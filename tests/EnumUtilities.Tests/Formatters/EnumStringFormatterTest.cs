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
        Span<int> foundItems = stackalloc int[1];
        foundItems[0] = 1; // "Blue"
        var count = names[1].Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(names, foundItems, count);

        // Assert
        result.Should().Be("Blue");
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldFormatMultipleItemsCorrectly()
    {
        // Arrange
        var names = new[] { "Green", "Blue", "Red" };
        Span<int> foundItems = stackalloc int[3];
        foundItems[0] = 0; // "Green"
        foundItems[1] = 1; // "Blue"
        foundItems[2] = 2; // "Red"
        var count = names[0].Length + names[1].Length + names[2].Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(names, foundItems, count);

        // Assert
        result.Should().Be("Red, Blue, Green"); // Note: reverse order of write
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldHandleTwoItems()
    {
        // Arrange
        var names = new[] { "Green", "Blue", "Red" };
        Span<int> foundItems = stackalloc int[2];
        foundItems[0] = 1; // "Blue"
        foundItems[1] = 2; // "Red"
        var count = names[1].Length + names[2].Length;

        // Act
        var result = EnumStringFormatter.WriteMultipleFoundFlagsNames(names, foundItems, count);

        // Assert
        result.Should().Be("Red, Blue");
    }

    [Fact]
    public void WriteMultipleFoundFlagsNames_ShouldThrowOverflowException_WhenCountExceedsIntMax()
    {
        var names = new[] { "Green", "Blue", "Red" };

        Assert.Throws<OverflowException>(
            () =>
            {
                Span<int> foundItems = stackalloc int[2];
                foundItems[0] = 0;
                foundItems[1] = 1;

                var count = int.MaxValue; // Force overflow in `checked`

                EnumStringFormatter.WriteMultipleFoundFlagsNames(names, foundItems, count);
            });
    }
}
