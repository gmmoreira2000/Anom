namespace Anom.Core.Utils.Extensios;

public static class EnumerableExtensions
{
    public static bool IsNullorEmpty<T>(this IEnumerable<T>? obj) =>  obj is null || !obj.Any();
}