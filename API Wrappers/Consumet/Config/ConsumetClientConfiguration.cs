namespace AniPlug.API_Wrappers.Consumet.Config;

/// <summary>
///     Object containing information of client configuration.
/// </summary>
public class ConsumetClientConfiguration
{
    /// <summary>
    ///     Should exception be thrown in case of failed request.
    /// </summary>
    public bool SuppressException { get; set; }
}