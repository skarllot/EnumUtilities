using Raiqub.Generators.EnumUtilities.Common;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Common;

public class CharIgnoreCaseEqualityComparerTest
{
    [Fact]
    public void ShouldGroupRegardlessCasingWhenUsingLookup()
    {
        var values = new[] { "Py1", "pay" };
        var lookup = values.ToLookup(x => x[0], CharIgnoreCaseEqualityComparer.Instance);

        Assert.Equal(1, lookup.Count);
        Assert.Single(lookup.OrderBy(x => x.Key));
    }
}
