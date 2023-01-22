namespace AniPlug.API_Wrappers.Consumet.Models;

public class Headers
{
    public string Referer { get; set; }
}

public class WatchRoot
{
    public Headers headers { get; set; }

    public List<Source> sources { get; set; }
    public string download { get; set; }
}

public class Source
{
    public string url { get; set; }

    public bool? isM3U8 { get; set; }

    public string quality { get; set; }
}