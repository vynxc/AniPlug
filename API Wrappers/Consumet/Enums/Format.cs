using System.ComponentModel;

namespace AniPlug.API_Wrappers.Consumet.Enums;

public enum Format
{
    /// <summary>
    ///     None
    /// </summary>
    None,

    /// <summary>
    ///     Format Tv
    /// </summary>
    [Description("TV")] Tv,

    /// <summary>
    ///     Format TV_SHORT
    /// </summary>
    [Description("TV_SHORT")] TvShort,

    /// <summary>
    ///     Format OVA
    /// </summary>
    [Description("OVA")] OVA,

    /// <summary>
    ///     Format ONA
    /// </summary>
    [Description("ONA")] ONA,

    /// <summary>
    ///     Format MOVIE
    /// </summary>
    [Description("MOVIE")] Movie,

    /// <summary>
    ///     Format SPECIAL
    /// </summary>
    [Description("SPECIAL")] Special,

    /// <summary>
    ///     Format MUSIC
    /// </summary>
    [Description("MUSIC")] Music
}