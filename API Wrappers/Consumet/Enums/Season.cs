using System.ComponentModel;

namespace AniPlug.API_Wrappers.Consumet.Enums;

public enum Season
{
    /// <summary>
    ///     None
    /// </summary>
    None,

    /// <summary>
    ///     Season WINTER
    /// </summary>
    [Description("WINTER")] Winter,

    /// <summary>
    ///     Season SPRING
    /// </summary>
    [Description("SPRING")] Spring,

    /// <summary>
    ///     Season SUMMER
    /// </summary>
    [Description("SUMMER")] Summer,

    /// <summary>
    ///     Season FALL
    /// </summary>
    [Description("FALL")] Fall
}