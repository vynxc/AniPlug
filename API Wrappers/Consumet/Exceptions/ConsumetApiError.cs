using System.Net;
using System.Text.Json.Serialization;

namespace AniPlug.API_Wrappers.Consumet.Exceptions;

public class ConsumetApiError
{
    [JsonPropertyName("status")] public HttpStatusCode Status { get; set; }

    /// <summary>
    ///     Type of http error.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    ///     Message of the error.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    ///     Additional data.
    /// </summary>
    [JsonPropertyName("error")]
    public string Error { get; set; }
}