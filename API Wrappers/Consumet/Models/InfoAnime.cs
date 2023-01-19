using Newtonsoft.Json;

namespace AniPlug.API_Wrappers.Consumet.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Character
{
    public int? id { get; set; }
    public string role { get; set; }
    public Name name { get; set; }
    public string image { get; set; }
    public List<VoiceActor> voiceActors { get; set; }
}

public class EndDate
{
    public int? year { get; set; }
    public int? month { get; set; }
    public int? day { get; set; }
}

public class Episode
{
    public string id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int? number { get; set; }
    public string image { get; set; }
    public DateTime? airDate { get; set; }
}

public class Mappings
{
    public int? mal { get; set; }
    public int? anidb { get; set; }
    public int? kitsu { get; set; }
    public int? anilist { get; set; }
    public int? thetvdb { get; set; }
    public int? anisearch { get; set; }
    public int? livechart { get; set; }

    [JsonProperty("notify.moe")] public string notifymoe { get; set; }

    [JsonProperty("anime-planet")] public string animeplanet { get; set; }
}

public class Name
{
    public string first { get; set; }
    public string last { get; set; }
    public string full { get; set; }
    public string native { get; set; }
    public string userPreferred { get; set; }
}

public class Recommendation
{
    public int? id { get; set; }
    public int? malId { get; set; }
    public Title title { get; set; }
    public string status { get; set; }
    public int? episodes { get; set; }
    public string image { get; set; }
    public string cover { get; set; }
    public int? rating { get; set; }
    public string type { get; set; }
}

public class Relation
{
    public int? id { get; set; }
    public string relationType { get; set; }
    public int? malId { get; set; }
    public Title title { get; set; }
    public string status { get; set; }
    public int? episodes { get; set; }
    public string image { get; set; }
    public string color { get; set; }
    public string type { get; set; }
    public string cover { get; set; }
    public int? rating { get; set; }
}

public class InfoRoot
{
    public string id { get; set; }
    public Title title { get; set; }
    public int? malId { get; set; }
    public List<string> synonyms { get; set; }
    public bool? isLicensed { get; set; }
    public bool? isAdult { get; set; }
    public string countryOfOrigin { get; set; }
    public string image { get; set; }
    public int? popularity { get; set; }
    public string color { get; set; }
    public string cover { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public int? releaseDate { get; set; }
    public StartDate startDate { get; set; }
    public EndDate endDate { get; set; }
    public int? totalEpisodes { get; set; }
    public int? rating { get; set; }
    public int? duration { get; set; }
    public List<string> genres { get; set; }
    public string season { get; set; }
    public List<string> studios { get; set; }
    public string subOrDub { get; set; }
    public string type { get; set; }
    public List<Recommendation> recommendations { get; set; }
    public List<Character> characters { get; set; }
    public List<Relation> relations { get; set; }
    public Mappings mappings { get; set; }
    public List<Episode> episodes { get; set; }
}

public class StartDate
{
    public int? year { get; set; }
    public int? month { get; set; }
    public int? day { get; set; }
}

public class VoiceActor
{
    public int? id { get; set; }
    public string language { get; set; }
    public Name name { get; set; }
    public string image { get; set; }
}