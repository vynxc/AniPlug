namespace AniPlug.API_Wrappers.Consumet.Exceptions;

public class ConsumetValidationException : Exception
{
    /// <summary>
    ///     Constructor with exception message and name of the argument that  failed validation.
    /// </summary>
    public ConsumetValidationException(string message, string argumentName) : base(message)
    {
        ArgumentName = argumentName;
    }

    /// <summary>
    ///     Name of the argument that failed validation.
    /// </summary>
    public string ArgumentName { get; }
}