namespace Raiqub.Generators.EnumUtilities.Models;

[Flags]
public enum SelectedGenerators
{
    None = 0,
    MainGenerator = 1 << 0,
    JsonConverter = 1 << 1,
}
