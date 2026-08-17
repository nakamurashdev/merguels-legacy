using MerguelsLegacy.Common.Configuration;
using MerguelsLegacy.Utilities.Extensions;
using Terraria.GameInput;

namespace MerguelsLegacy.Common.Potions;

/// <summary>
///     Handles allowing players to use the Quick Buff keybind to apply buffs from potions in the Safe.
/// </summary>
public sealed class SafeQuickBuffPlayer : ModPlayer
{
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        base.ProcessTriggers(triggersSet);

        if (!PlayerInput.Triggers.Current.QuickBuff || !ServerSideConfiguration.Instance.EnableSafeQuickBuff)
        {
            return;
        }

        Apply(Player.bank2);
    }

    private void Apply(Chest chest)
    {
        foreach (var (item, _) in chest.Enumerate())
        {
            if (item.buffType <= 0 || Main.debuff[item.buffType])
            {
                continue;
            }

            Player.AddBuff(item.buffType, item.buffTime);

            if (!item.consumable)
            {
                continue;
            }

            item.stack--;
        }
    }
}