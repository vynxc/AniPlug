using AniPlug.API_Wrappers.Consumet.Config;
using AniPlug.API_Wrappers.Consumet.Enums;
using AniPlug.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonkeyCache.FileStore;
using System.Diagnostics;

namespace AniPlug.Anime.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private List<AnimeCollectionModel> _mainAnime;
    [ObservableProperty] private List<MovieCollectionModel> _movies;

    [ObservableProperty] private List<API_Wrappers.Consumet.Models.Anime> _scoreAnimes;
    List<AnimeCollectionModel> collection = new List<AnimeCollectionModel>();
    List<MovieCollectionModel> moviesCollection = new List<MovieCollectionModel>();
    public MainPageViewModel()
    {
        var thread = new Thread(Init);
        thread.Start();
    }

    private async void Init()
    {
        _movies = new List<MovieCollectionModel>();

        var trendingTask = Task.Run(() => MauiProgram.Consumet.GetFlixTrendingAsync());
        var recentMoviesTask = Task.Run(() => MauiProgram.Consumet.GetFlixRecentMovieAsync());
        var recentShowsTask = Task.Run(() => MauiProgram.Consumet.GetFlixRecentShowAsync());
        var scoreTask = Task.Run(() =>
            MauiProgram.Consumet.GetAnimeSearchAsync(
                new AnimeSearchConfig { Sort = new List<Sort> { Sort.SCORE_DESC } }));
        var upcomingTask = Task.Run(() =>
            MauiProgram.Consumet.GetAnimeSearchAsync(new AnimeSearchConfig { Status = Status.NOT_YET_RELEASED }));
        var favoriteTask = Task.Run(() =>
            MauiProgram.Consumet.GetAnimeSearchAsync(new AnimeSearchConfig
            { Sort = new List<Sort> { Sort.FAVOURITES_DESC } }));
        var popularTask = Task.Run(() =>
            MauiProgram.Consumet.GetAnimeSearchAsync(new AnimeSearchConfig
            { Sort = new List<Sort> { Sort.POPULARITY_DESC } }));

        await Task.WhenAll(scoreTask, upcomingTask, favoriteTask, popularTask, trendingTask, recentMoviesTask,
            recentShowsTask);

        var score = await scoreTask;
        var upcoming = await upcomingTask;
        var favorite = await favoriteTask;
        var popular = await popularTask;
        var trendingMovies = await trendingTask;
        var recentMovie = await recentMoviesTask;
        var recentShow = await recentShowsTask;

        collection.Add(new AnimeCollectionModel { name = "Popular Animes", animes = popular.results });
        collection.Add(new AnimeCollectionModel { name = "Anime Favorites", animes = favorite.results });
        collection.Add(new AnimeCollectionModel { name = "Upcoming Animes", animes = upcoming.results });
        moviesCollection.Add(new MovieCollectionModel { name = "Trending Movies", movies = trendingMovies });
        moviesCollection.Add(new MovieCollectionModel { name = "Recent Movies", movies = recentMovie });
        moviesCollection.Add(new MovieCollectionModel { name = "Recent Shows", movies = recentShow });

        MainAnime = collection;
        Movies = moviesCollection;
        ScoreAnimes = score.results!.Take(5).ToList();
       
      
    }


    [RelayCommand]
    public async void GoToSearch()
    {
        await Shell.Current.GoToAsync("search");
    }
}