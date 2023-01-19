using System.ComponentModel;

namespace AniPlug.API_Wrappers.Consumet.Enums;

public enum Genres
{
    /// <summary>
    ///     None
    /// </summary>
    None,

    /// <summary>
    ///     Action genre
    /// </summary>
    [Description("Action")] Action,

    /// <summary>
    ///     Adventure genre
    /// </summary>
    [Description("Adventure")] Adventure,

    /// <summary>
    ///     Cars genre
    /// </summary>
    [Description("Cars")] Cars,

    /// <summary>
    ///     Comedy genre
    /// </summary>
    [Description("Comedy")] Comedy,

    /// <summary>
    ///     Drama genre
    /// </summary>
    [Description("Drama")] Drama,

    /// <summary>
    ///     Fantasy genre
    /// </summary>
    [Description("Fantasy")] Fantasy,

    /// <summary>
    ///     Horror genre
    /// </summary>
    [Description("Horror")] Horror,

    /// <summary>
    ///     Mahou Shoujo genre
    /// </summary>
    [Description("Mahou Shoujo")] MahouShoujo,

    /// <summary>
    ///     Mecha genre
    /// </summary>
    [Description("Mecha")] Mecha,

    /// <summary>
    ///     Music genre
    /// </summary>
    [Description("Music")] Music,

    /// <summary>
    ///     Mystery genre
    /// </summary>
    [Description("Mystery")] Mystery,

    /// <summary>
    ///     Psychological genre
    /// </summary>
    [Description("Psychological")] Psychological,

    /// <summary>
    ///     Romance genre
    /// </summary>
    [Description("Romance")] Romance,

    /// <summary>
    ///     Sci-Fi genre
    /// </summary>
    [Description("Sci-Fi")] SciFi,

    /// <summary>
    ///     Slice of Life genre
    /// </summary>
    [Description("Slice of Life")] SliceOfLife,

    /// <summary>
    ///     Sports genre
    /// </summary>
    [Description("Sports")] Sports,

    /// <summary>
    ///     Supernatural genre
    /// </summary>
    [Description("Supernatural")] Supernatural,

    /// <summary>
    ///     Thriller genre
    /// </summary>
    [Description("Thriller")] Thriller
}