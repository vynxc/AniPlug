using System.Text;
using AniPlug.API_Wrappers.Consumet.Enums;
using AniPlug.API_Wrappers.Consumet.Helpers;
using AniPlug.API_Wrappers.Extensions;
using Newtonsoft.Json;
using Type = AniPlug.API_Wrappers.Consumet.Enums.Type;

namespace AniPlug.API_Wrappers.Consumet.Config;

public class AnimeSearchConfig
{
    /// <summary>
    ///     Search query.
    /// </summary>
    public string Query { get; set; } = default;

    /// <summary>
    ///     Anime type of searched result.
    /// </summary>
    public Type Type { get; set; } = Type.Anime;

    /// <summary>
    ///     Index of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51
    ///     to 100 etc.)
    /// </summary>
    public int? Page { get; set; } = default;

    /// <summary>
    ///     Size of the page (20 is the default).
    /// </summary>
    public int? PerPage { get; set; } = default;

    /// <summary>
    ///     Seasons.
    /// </summary>
    public Season Season { get; set; } = default;

    /// <summary>
    ///     Format.
    /// </summary>
    public Format Format { get; set; } = default;

    /// <summary>
    ///     Sort.
    /// </summary>
    public ICollection<Sort> Sort { get; set; } = new List<Sort>();

    /// <summary>
    ///     Genres.
    /// </summary>
    public ICollection<Genres> Genres { get; set; } = new List<Genres>();

    /// <summary>
    ///     Status.
    /// </summary>
    public Status Status { get; set; } = default;


    public string ConfigToString()
    {
        var builder = new StringBuilder().Append('?');
        if (Page.HasValue)
        {
            Guard.IsGreaterThanZero(Page.Value, nameof(Page.Value));
            builder.Append($"page={Page.Value}&");
        }

        if (PerPage.HasValue)
        {
            Guard.IsGreaterThanZero(PerPage.Value, nameof(PerPage.Value));
            Guard.IsLesserOrEqualThan(PerPage.Value, 20, nameof(PerPage.Value));
            builder.Append($"limit={PerPage.Value}&");
        }

        if (!string.IsNullOrWhiteSpace(Query)) builder.Append($"q={Query}&");

        if (Type != Type.Anime)
        {
            Guard.IsValidEnum(Type, nameof(Type));
            builder.Append($"type={Type.GetDescription()}&");
        }

        if (Season != default)
        {
            Guard.IsValidEnum(Season, nameof(Season));
            builder.Append($"season={Season.GetDescription()}&");
        }

        if (Status != default)
        {
            Guard.IsValidEnum(Status, nameof(Status));
            builder.Append($"status={Status.GetDescription()}&");

            if (Format != default)
            {
                Guard.IsValidEnum(Format, nameof(Format));
                builder.Append($"format={Format.GetDescription()}&");
            }
        }

        if (Sort.Count > 0)
        {
            var SortsIds = Sort.GetEnumArray();

            var formattedSort = JsonConvert.SerializeObject(SortsIds);

            builder.Append($"sort={formattedSort}&");
        }

        if (Genres.Count > 0)
        {
            var genresIds = Genres.GetEnumArray();

            var formattedGenres = JsonConvert.SerializeObject(genresIds);

            builder.Append($"genres={formattedGenres}&");
        }

        return builder.ToString().Trim('&');
    }
}