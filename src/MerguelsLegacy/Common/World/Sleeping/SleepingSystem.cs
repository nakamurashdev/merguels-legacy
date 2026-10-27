using MerguelsLegacy.Common.Configuration;
using Terraria.GameContent.Creative;

namespace MerguelsLegacy.Common.World.Sleeping;

public sealed class SleepingSystem : ModSystem
{
    /// <inheritdoc/> 
    public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
    {
        base.ModifyTimeRate(ref timeRate, ref tileUpdateRate, ref eventUpdateRate);

        if (Main.gameMenu || !SleepingUtilities.Skip)
        {
            return;
        }

        var multiplier = ServerSideConfiguration.Instance.SleepingMultiplier;
        var freeze = CreativePowerManager.Instance.GetPower<CreativePowers.FreezeTime>().Enabled;

        if (freeze)
        {
            return;
        }

        var rate = (float)CreativePowerManager.Instance.GetPower<CreativePowers.ModifyTimeRate>().TargetTimeRate;

        const float cycle = 86400;
        
        rate *= multiplier;
        rate = MathHelper.Clamp(rate, 1f, cycle);

        timeRate = rate;
    }
}