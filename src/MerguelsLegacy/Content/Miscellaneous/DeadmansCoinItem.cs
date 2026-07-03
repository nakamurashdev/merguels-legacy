using MerguelsLegacy.Utilities;
using Terraria.Enums;

namespace MerguelsLegacy.Content.Miscellaneous;

public sealed class DeadmansCoinGlobalNPC : GlobalNPC
{
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
    {
        return entity.type == NPCID.SkeletonMerchant;
    }

    public override void SetupTravelShop(int[] shop, ref int nextSlot)
    {
        base.SetupTravelShop(shop, ref nextSlot);
        
        if (!Main.bloodMoon && Main.GetMoonPhase() != MoonPhase.Full)
        {
            return;
        }

        shop[nextSlot] = ModContent.ItemType<DeadmansCoinItem>();
        nextSlot++;
    }
}

public class DeadmansCoinSystem : ModSystem
{
    /// <summary>
    ///     The duration of the respawn time when a boss is not alive.
    /// </summary>
    /// <remarks>
    ///     Equivalent to 5 seconds (5 seconds * 60 ticks).
    /// </remarks>
    public const int RESPAWN_TIME = 5 * TimeUtilities.SECOND_IN_TICKS;

    /// <summary>
    ///     The duration of the respawn time when a boss is alive.
    /// </summary>
    /// <remarks>
    ///     Equivalent to 10 seconds (10 seconds * 60 ticks).
    /// </remarks>
    public const int RESPAWN_TIME_BOSS = 10 * TimeUtilities.SECOND_IN_TICKS;
    
    public override void Load()
    {
        base.Load();
        
        On_Player.GetRespawnTime += Player_GetRespawnTime_Hook;
    }

    private static int Player_GetRespawnTime_Hook(On_Player.orig_GetRespawnTime orig, Player self, bool pvp)
    {
        var time = orig(self, pvp);
        
        var has = self.HasItemInInventoryOrOpenVoidBag(ModContent.ItemType<DeadmansCoinItem>());

        if (!has)
        {
            return time;
        }
        
        var boss = Main.CurrentFrameFlags.AnyActiveBossNPC;

        return boss ? RESPAWN_TIME_BOSS : RESPAWN_TIME;
    }
}

public class DeadmansCoinItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.value = Item.buyPrice(gold: 5);
    }
}