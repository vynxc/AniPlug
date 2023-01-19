namespace AniPlug.Anime.Views.ViewCells;

public partial class AnimeBase : ContentView
{
    public AnimeBase()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        // access the anime object when clicked or tapped 
        var anime = BindingContext as API_Wrappers.Consumet.Models.Anime;
        Application.Current.MainPage.DisplayAlert(anime.title.english, anime.description, "Okay");
    }
}