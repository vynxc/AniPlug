namespace AniPlug.API_Wrappers.Consumet.Models;

public class Anime
{
    public string? id { get; set; }
    public int? malId { get; set; }
    public Title title { get; set; }
    public string? image { get; set; }
    public Trailer trailer { get; set; }
    public string? description { get; set; }
    public string? status { get; set; }
    public string? cover { get; set; }
    public int? rating { get; set; }
    public int? releaseDate { get; set; }
    public List<string?> genres { get; set; }
    public int? totalEpisodes { get; set; }
    public int? duration { get; set; }
    public string? type { get; set; }
}

public class RootAnime
{
    public int? currentPage { get; set; }
    public bool? hasNextPage { get; set; }
    public List<Anime>? results { get; set; }
    public int? totalPages { get; set; }
    public int? totalResults { get; set; }
}

public class Title
{
    public string? romaji { get; set; }
    public string? english { get; set; }
    public string? native { get; set; }
    public string? userPreferred { get; set; }
}

public class Trailer
{
    public string? id { get; set; }
    public string? site { get; set; }
    public string? thumbnail { get; set; }
}