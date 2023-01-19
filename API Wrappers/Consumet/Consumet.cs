using System.Text;
using AniPlug.API_Wrappers.Consumet.Config;
using AniPlug.API_Wrappers.Consumet.Enums;
using AniPlug.API_Wrappers.Consumet.Helpers;
using AniPlug.API_Wrappers.Consumet.Models;
using AniPlug.API_Wrappers.Extensions;
using MonkeyCache.FileStore;
using Newtonsoft.Json;

namespace AniPlug.API_Wrappers.Consumet;

public class Consumet
{
    #region Settings

    private Provider Provider { get; } = Provider.GogoAnime;
    private bool IsDub { get; } = false;

    #endregion

    #region Fields

    /// <summary>
    ///     Http client class to call REST request and receive REST response.
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    ///     Client configuration.
    /// </summary>
    private readonly ConsumetClientConfiguration _consumetConfiguration;

    #endregion Fields

    #region Constructors

    /// <summary>
    ///     Constructor.
    /// </summary>
    public Consumet() : this(new ConsumetClientConfiguration())
    {
    }

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="consumetClientConfiguration">Options.</param>
    /// <param name="httpClient">Http client.</param>
    private Consumet(ConsumetClientConfiguration consumetClientConfiguration, HttpClient httpClient = null)
    {
        _consumetConfiguration = consumetClientConfiguration;
        _httpClient = httpClient ?? DefaultHttpClientProvider.GetDefaultHttpClient();
    }

    #endregion Constructors

    #region Private Methods
    private SemaphoreSlim _barrelSemaphore = new SemaphoreSlim(1);

    private async Task<T> GetAsync<T>(string endpoint, int hours = 24, bool forceRefresh = false)
    {
        await _barrelSemaphore.WaitAsync();

        try
        {
            var json = string.Empty;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                json = Barrel.Current.Get<string>(endpoint);

            if (!forceRefresh && !Barrel.Current.IsExpired(endpoint))
                json = Barrel.Current.Get<string>(endpoint);

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await _httpClient.GetStringAsync(endpoint);
                    if (!forceRefresh) Barrel.Current.Add(endpoint, json, TimeSpan.FromHours(hours));
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Unable to get information from server {ex}");
                //probably re-throw here :)
            }
        }
        finally { _barrelSemaphore.Release(); }
        

        return default;
    }


    private string ConsumetConfigToString()
    {
        var builder = new StringBuilder().Append('?');
        builder.Append($"provider={Provider.GetDescription()}&");
        builder.Append($"dub={IsDub.ToString().ToLower()}");
        return builder.ToString().Trim('&');
    }

    #endregion Private Methods


    #region Public Methods

    public async Task<RootAnime> GetAnimeSearchAsync(AnimeSearchConfig searchConfig)
    {
        Guard.IsNotNull(searchConfig, nameof(searchConfig));

        return await GetAsync<RootAnime>("meta/anilist/advanced-search" + searchConfig.ConfigToString());
    }

    public async Task<RootAnime> GetAnimeGenreSearchAsync(ICollection<Genres> genres)
    {
        if (genres.Count > 0)
        {
            var formattedGenres = JsonConvert.SerializeObject(genres.GetEnumArray());

            return await GetAsync<RootAnime>("meta/anilist/genre?genres=" + formattedGenres);
        }

        return default;
    }

    public async Task<InfoRoot> GetAnimeInfoAsync(string id)
    {
        return await GetAsync<InfoRoot>("meta/anilist/info/" + id + ConsumetConfigToString());
    }

    public async Task<List<Episode>> GetAnimeEpisodesAsync(string id)
    {
        return await GetAsync<List<Episode>>("meta/anilist/episodes/" + id + ConsumetConfigToString());
    }

    public async Task<List<Movie>> GetFlixTrendingAsync()
    {
        var results = await GetAsync<RootMovie>("movies/flixhq/trending");
        return results.results;
    }

    public async Task<List<Movie>> GetFlixRecentMovieAsync()
    {
        return await GetAsync<List<Movie>>("movies/flixhq/recent-movies");
    }

    public async Task<List<Movie>> GetFlixRecentShowAsync()
    {
        return await GetAsync<List<Movie>>("movies/flixhq/recent-shows");
    }

    #endregion
}