using AniPlug.Anime;
using AniPlug.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniPlug.Shared.ViewModels
{
    public partial class SearchPageViewModel : ObservableObject
    {
        [ObservableProperty] private List<AnimeCollectionModel> _mainAnime;
        [ObservableProperty] private List<MovieCollectionModel> _movies;
    }
}