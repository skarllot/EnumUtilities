namespace Raiqub.Generators.EnumUtilities.IntegrationTests.Models;

[EnumGenerator]
[Flags]
public enum RgbColors
{
    None = 0,

    // Primary colors
    Red = 1 << 0,
    Orange = 1 << 1,
    Yellow = 1 << 2,
    Lime = 1 << 3,
    Green = 1 << 4,
    Teal = 1 << 5,
    Cyan = 1 << 6,
    Blue = 1 << 7,
    Indigo = 1 << 8,
    Violet = 1 << 9,

    // Secondary colors (adjacent pair on the color wheel)
    Amber = Red | Orange,
    Saffron = Orange | Yellow,
    Chartreuse = Yellow | Lime,
    Fern = Lime | Green,
    Emerald = Green | Teal,
    Turquoise = Teal | Cyan,
    Azure = Cyan | Blue,
    Periwinkle = Blue | Indigo,
    Lavender = Indigo | Violet,
    Magenta = Violet | Red,

    // Tertiary colors (adjacent triplet on the color wheel)
    Gold = Red | Orange | Yellow,
    Citrus = Orange | Yellow | Lime,
    Peridot = Yellow | Lime | Green,
    Jade = Lime | Green | Teal,
    Marine = Green | Teal | Cyan,
    SkyBlue = Teal | Cyan | Blue,
    Cerulean = Cyan | Blue | Indigo,
    Purple = Blue | Indigo | Violet,
    Crimson = Indigo | Violet | Red,
    Vermillion = Violet | Red | Orange,
}
