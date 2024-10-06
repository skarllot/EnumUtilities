using NetEscapades.EnumGenerators;
using Raiqub.Generators.EnumUtilities;

namespace EnumUtilities.Benchmark.Models;

[EnumExtensions(ExtensionClassName = "ValarNetEscapades")]
[EnumGenerator]
public enum Valar
{
    Manwe = 1,
    Varda,
    Ulmo,
    Aule,
    Yavanna,
    Mandos,
    Nienna,
    Orome,
}
