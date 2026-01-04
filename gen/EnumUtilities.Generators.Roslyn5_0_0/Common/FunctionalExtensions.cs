namespace Raiqub.Generators.EnumUtilities.Common;

public static class FunctionalExtensions
{
    public static void IfNotNull<T>(this T? value, Action<T> action)
        where T : class
    {
        if (value is not null)
            action(value);
    }

    public static TOut? Map<TIn, TOut>(this TIn? value, Func<TIn, TOut> func)
        where TIn : class
    {
        return value is not null ? func(value) : default;
    }
}
