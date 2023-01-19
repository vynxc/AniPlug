namespace AniPlug.Anime;

public class AnimeCollectionModel
{
    public string name { get; set; }
    public ICollection<API_Wrappers.Consumet.Models.Anime> animes { get; set; }
}