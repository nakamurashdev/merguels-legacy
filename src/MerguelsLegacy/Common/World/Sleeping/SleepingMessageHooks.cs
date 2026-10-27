using MerguelsLegacy.Common.Configuration;

namespace MerguelsLegacy.Common.World.Sleeping;

public sealed class SleepingMessageHooks : ILoadable
{
    private static bool _flag;

    /// <inheritdoc/>
    void ILoadable.Load(Mod mod) => On_Main.UpdateTime += UpdateTime_Hook;

    /// <inheritdoc/>
    void ILoadable.Unload() => On_Main.UpdateTime -= UpdateTime_Hook;

    private static void UpdateTime_Hook(On_Main.orig_UpdateTime orig)
    {
        orig();

        if (Main.gameMenu)
        {
            _flag = false;
            return;
        }

        var mode = ServerSideConfiguration.Instance.SleepingMode;

        var sleeping = mode switch
        {
            SleepingMode.All => Main.CurrentFrameFlags.SleepingPlayersCount == Main.CurrentFrameFlags.ActivePlayersCount,
            SleepingMode.Half => Main.CurrentFrameFlags.SleepingPlayersCount >= Main.CurrentFrameFlags.ActivePlayersCount / 2,
            SleepingMode.Single => Main.CurrentFrameFlags.SleepingPlayersCount > 0,
            _ => false
        };

        if (!sleeping)
        {
            _flag = false;
            return;
        }

        if (_flag)
        {
            return;
        }

        _flag = true;
        
        Main.NewText("The players are sleeping. Time is passing faster!", Color.LightBlue);
    }
}