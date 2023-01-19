using System.ComponentModel;
using System.Reflection;

namespace AniPlug.API_Wrappers.Extensions;

internal static class EnumExtensions
{
    public static string GetDescription<T>(this T source) where T : Enum
    {
        return typeof(T)
            .GetField(source.ToString())
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description;
    }


    public static string[] GetEnumArray<T>(this IEnumerable<T> values) where T : struct, Enum
    {
        return values.Select(enumValue => enumValue.GetDescription()).ToArray();
    }
}