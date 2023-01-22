using AniPlug.Shared.Pages;

namespace AniPlug;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("search", typeof(SearchPage));
    }
}