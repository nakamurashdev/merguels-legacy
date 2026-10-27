using Terraria.DataStructures;

namespace MerguelsLegacy.Content.Miscellaneous;

public sealed class DeadmansCoinGlobalNPC : GlobalNPC
{
    /// <inheritdoc/> 
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.SkeletonMerchant;

    /// <inheritdoc/> 
    public override void ModifyShop(NPCShop shop)
    {
        base.ModifyShop(shop);

        shop.Add(ModContent.ItemType<DeadmansCoinItem>(), Condition.BloodMoon, Condition.MoonPhaseFull);
    }
}

public class DeadmansCoinItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Common.Placeholder.KEY;

    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.value = Item.buyPrice(gold: 5);
    }
}

public sealed class DeadmansCoinPlayer : ModPlayer
{
    /// <summary>
    ///     The amount of time, in frames, removed from the player's respawn timer when a boss is active.
    /// </summary>
    public const int BOSS_RESPAWN_TIMER_REDUCTION = 10 * 60;

    /// <summary>
    ///     The amount of time, in frames, removed from the player's respawn timer when no boss is active.
    /// </summary>
    public const int RESPAWN_TIMER_REDUCTION = 5 * 60;
    
    public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
    {
        base.Kill(damage, hitDirection, pvp, damageSource);

        if (!Player.HasItemInInventoryOrOpenVoidBag(ModContent.ItemType<DeadmansCoinItem>()))
        {
            return;
        }
        
        Player.respawnTimer -= Main.CurrentFrameFlags.AnyActiveBossNPC ? BOSS_RESPAWN_TIMER_REDUCTION : RESPAWN_TIMER_REDUCTION;
    }
}