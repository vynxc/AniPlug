using System.ComponentModel;

namespace AniPlug.API_Wrappers.Consumet.Enums;

public enum Status
{
    /// <summary>
    ///     None
    /// </summary>
    None,

    /// <summary>
    ///     The series is currently releasing
    /// </summary>
    [Description("RELEASING")] RELEASING,

    /// <summary>
    ///     The series has not yet been released
    /// </summary>
    [Description("NOT_YET_RELEASED")] NOT_YET_RELEASED,

    /// <summary>
    ///     The series has finished releasing
    /// </summary>
    [Description("FINISHED")] FINISHED,

    /// <summary>
    ///     The series has been cancelled
    /// </summary>
    [Description("CANCELLED")] CANCELLED,

    /// <summary>
    ///     The series is on hiatus
    /// </summary>
    [Description("HIATUS")] HIATUS
}