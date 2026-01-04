namespace Raiqub.Generators.EnumUtilities.Models;

[Flags]
public enum SelectedGenerators
{
    MainGenerator = 1 << 0,
    JsonConverter = 1 << 1,
}
