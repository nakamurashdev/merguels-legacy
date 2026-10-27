using MerguelsLegacy.Common.Configuration;

namespace MerguelsLegacy.Common.Inventory;

public sealed class SafeHooks : ILoadable
{
    /// <inheritdoc/> 
    void ILoadable.Load(Mod mod) => On_Player.QuickBuff += QuickBuff_Hook;

    /// <inheritdoc/> 
    void ILoadable.Unload() => On_Player.QuickBuff -= QuickBuff_Hook;
    
    private static void QuickBuff_Hook(On_Player.orig_QuickBuff orig, Player self)
    {
        orig(self);

        if (!Enabled(self))
        {
            return;
        }
        
        Apply(self);
    }

    private static bool Enabled(Player player)
    {
        if (ServerSideConfiguration.Instance.EnableSafePotions)
        {
            return false;
        }
        
        var inactive = player.cursed || player.CCed || player.dead;

        if (inactive)
        {
            return false;
        }

        return player.CountBuffs() != Player.maxBuffs;
    }

    private static void Apply(Player player)
    {
        for (var i = 0; i < player.bank2.item.Length; i++)
        {
            ref var item = ref player.bank2.item[i];
            
            var type = item.buffType;
            var time = item.buffTime;

            if (type <= 0 || Main.debuff[type])
            {
                continue;
            }

            player.AddBuff(type, time);

            if (!item.consumable)
            {
                continue;
            }

            item.stack--;
        }
    }
}