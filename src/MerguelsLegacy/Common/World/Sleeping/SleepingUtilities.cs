using MerguelsLegacy.Common.Configuration;

namespace MerguelsLegacy.Common.World.Sleeping;

public static class SleepingUtilities
{
    /// <summary>
    ///     Gets the number of players currently sleeping.
    /// </summary>
    public static int Count => Main.CurrentFrameFlags.SleepingPlayersCount;

    /// <summary>
    ///     
    /// </summary>
    public static bool Skip => ServerSideConfiguration.Instance.SleepingMode switch
    {
        SleepingMode.All => Count == Main.CurrentFrameFlags.ActivePlayersCount,
        SleepingMode.Half => Count >= Main.CurrentFrameFlags.ActivePlayersCount / 2,
        SleepingMode.Single => Count > 0,
        _ => false
    };
}