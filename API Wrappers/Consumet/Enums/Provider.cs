using System.ComponentModel;

namespace AniPlug.API_Wrappers.Consumet.Enums;

public enum Provider
{
    /// <summary>
    ///     Use provider GogoAnime
    /// </summary>
    [Description("gogoanime")] GogoAnime,

    /// <summary>
    ///     Use provider Zoro
    /// </summary>
    [Description("zoro")] Zoro,

    /// <summary>
    ///     Use provider AnimePahe
    /// </summary>
    [Description("animepahe")] AnimePahe
}