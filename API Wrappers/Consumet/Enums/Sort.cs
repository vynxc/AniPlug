using System.ComponentModel;

namespace AniPlug.API_Wrappers.Consumet.Enums;

public enum Sort
{
    /// <summary>
    ///     None
    /// </summary>
    None,

    /// <summary>
    ///     Sort by popularity in descending order
    /// </summary>
    [Description("POPULARITY_DESC")] POPULARITY_DESC,

    /// <summary>
    ///     Sort by popularity in ascending order
    /// </summary>
    [Description("POPULARITY")] POPULARITY,

    /// <summary>
    ///     Sort by trending in descending order
    /// </summary>
    [Description("TRENDING_DESC")] TRENDING_DESC,

    /// <summary>
    ///     Sort by trending in ascending order
    /// </summary>
    [Description("TRENDING")] TRENDING,

    /// <summary>
    ///     Sort by updated at in descending order
    /// </summary>
    [Description("UPDATED_AT_DESC")] UPDATED_AT_DESC,

    /// <summary>
    ///     Sort by updated at in ascending order
    /// </summary>
    [Description("UPDATED_AT")] UPDATED_AT,

    /// <summary>
    ///     Sort by start date in descending order
    /// </summary>
    [Description("START_DATE_DESC")] START_DATE_DESC,

    /// <summary>
    ///     Sort by start date in ascending order
    /// </summary>
    [Description("START_DATE")] START_DATE,

    /// <summary>
    ///     Sort by end date in descending order
    /// </summary>
    [Description("END_DATE_DESC")] END_DATE_DESC,

    /// <summary>
    ///     Sort by end date in ascending order
    /// </summary>
    [Description("END_DATE")] END_DATE,

    /// <summary>
    ///     Sort by favorites in descending order
    /// </summary>
    [Description("FAVOURITES_DESC")] FAVOURITES_DESC,

    /// <summary>
    ///     Sort by favorites in ascending order
    /// </summary>
    [Description("FAVOURITES")] FAVOURITES,

    /// <summary>
    ///     Sort by score in descending order
    /// </summary>
    [Description("SCORE_DESC")] SCORE_DESC,

    /// <summary>
    ///     Sort by score in ascending order
    /// </summary>
    [Description("SCORE")] SCORE,

    /// <summary>
    ///     Sort by title in romaji in descending order
    /// </summary>
    [Description("TITLE_ROMAJI_DESC")] TITLE_ROMAJI_DESC,

    /// <summary>
    ///     Sort by title in romaji in ascending order
    /// </summary>
    [Description("TITLE_ROMAJI")] TITLE_ROMAJI,

    /// <summary>
    ///     Sort by title in english in descending order
    /// </summary>
    [Description("TITLE_ENGLISH_DESC")] TITLE_ENGLISH_DESC,

    /// <summary>
    ///     Sort by title in english in ascending order
    /// </summary>
    [Description("TITLE_ENGLISH")] TITLE_ENGLISH,

    /// <summary>
    ///     Sort by title in native language in descending order
    /// </summary>
    [Description("TITLE_NATIVE_DESC")] TITLE_NATIVE_DESC,

    /// <summary>
    ///     Sort by title in native language in ascending order
    /// </summary>
    [Description("TITLE_NATIVE")] TITLE_NATIVE,

    /// <summary>
    ///     Sort by number of episodes in descending order
    /// </summary>
    [Description("EPISODES_DESC")] EPISODES_DESC,

    /// <summary>
    ///     Sort by number of episodes in ascending order
    /// </summary>
    [Description("EPISODES")] EPISODES,

    /// <summary>
    ///     Sort by ID in ascending order
    /// </summary>
    [Description("ID")] ID,

    /// <summary>
    ///     Sort by ID in descending order
    /// </summary>
    [Description("ID_DESC")] ID_DESC
}