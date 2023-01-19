namespace AniPlug.API_Wrappers.Consumet.Models;

public class Movie
{
    public string id { get; set; }
    public string title { get; set; }
    public string url { get; set; }
    public string image { get; set; }
    public string releaseDate { get; set; }
    public string duration { get; set; }
    public string type { get; set; }
    public string season { get; set; }
    public string latestEpisode { get; set; }
}

public class RootMovie
{
    public List<Movie> results { get; set; }
}