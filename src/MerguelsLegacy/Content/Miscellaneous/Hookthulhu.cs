using Terraria.GameContent.ItemDropRules;

namespace MerguelsLegacy.Content.Miscellaneous;

public sealed class HookthulhuGlobalNPC : GlobalNPC
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.EyeofCthulhu;

    /// <inheritdoc/>
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        base.ModifyNPCLoot(npc, npcLoot);
        
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HookthulhuItem>(), 20));
    }
}

public sealed class HookthulhuGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.EyeOfCthulhuBossBag;

    /// <inheritdoc/>
    public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
    {
        base.ModifyItemLoot(item, itemLoot);
        
        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HookthulhuItem>(), 20));
    }
}

public class HookthulhuItem : ModItem
{
    /// <inheritdoc/>
    public override string Texture => Assets.Images.Common.Placeholder.KEY;

    /// <inheritdoc/>
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(gold: 4);
    }
}