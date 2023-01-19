using MonkeyCache.FileStore;

[assembly: ExportFont("FontAwesome6.otf", Alias = "FontAwesome")]


namespace AniPlug;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Barrel.ApplicationId = AppInfo.PackageName;
        MainPage = new AppShell();
    }
}