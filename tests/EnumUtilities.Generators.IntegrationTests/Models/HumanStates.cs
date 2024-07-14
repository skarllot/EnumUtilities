namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

#pragma warning disable CA1069

[EnumGenerator]
public enum HumanStates
{
    Idle = 1,
    Working,
    Sleeping,
    Eating,
    Dead,
    Relaxing = 1
}
