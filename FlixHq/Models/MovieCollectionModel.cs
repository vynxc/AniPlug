using AniPlug.API_Wrappers.Consumet.Models;

namespace AniPlug.Models;

public class MovieCollectionModel
{
    public string name { get; set; }
    public ICollection<Movie> movies { get; set; }
}