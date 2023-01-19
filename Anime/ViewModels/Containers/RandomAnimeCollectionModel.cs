using CommunityToolkit.Mvvm.ComponentModel;

namespace AniPlug.Anime.ViewModels;

public partial class RandomAnimeCollectionModel : ObservableObject
{
    [ObservableProperty] private List<API_Wrappers.Consumet.Models.Anime> animes;

    public RandomAnimeCollectionModel()
    {
        Animes = new List<API_Wrappers.Consumet.Models.Anime>();
    }
}