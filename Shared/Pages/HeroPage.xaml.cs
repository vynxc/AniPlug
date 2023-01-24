using AniPlug.Anime.ViewModels;

namespace AniPlug;

public partial class HeroPage : ContentPage
{
    public HeroPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }


}