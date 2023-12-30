using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace Raiqub.Generators.EnumUtilities.Common;

public interface ILocalizableSource
{
    ImmutableArray<Location> Locations { get; }
}

public static class LocalizableSourceExtensions
{
    public static Location GetDefaultLocation(this ILocalizableSource? source) =>
        source?.Locations.FirstOrDefault(l => l.Kind == LocationKind.SourceFile) ?? Location.None;
}
