namespace MerguelsLegacy.Common.Accessories;

public sealed class LuckyHorseshoePlayer : ModPlayer
{
    private static readonly string TEXTURE_PATH = $"{nameof(MerguelsLegacy)}/Assets/Textures/Accessories/{nameof(ItemID.LuckyHorseshoe)}_{EquipType.Shoes}";
    
    /// <summary>
    ///     Gets or sets whether the effects of the <see cref="ItemID.LuckyHorseshoe"/> are enabled.
    /// </summary>
    public bool Enabled { get; set; }
    
    public override void Load()
    {
        base.Load();

        if (Main.netMode == NetmodeID.Server)
        {
            return;
        }

        EquipLoader.AddEquipTexture(Mod, TEXTURE_PATH, EquipType.Shoes, null, nameof(ItemID.LuckyHorseshoe));
    }

    public override void ResetEffects()
    {
        base.ResetEffects();

        Enabled = false;
    }

    public override void FrameEffects()
    {
        base.FrameEffects();

        if (!Enabled)
        {
            return;
        }

        Player.shoe = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.LuckyHorseshoe), EquipType.Shoes);
    }
}

public sealed class LuckyHorseshoeGlobalItem : GlobalItem
{
    public override bool AppliesToEntity(Item entity, bool lateInstantiation)
    {
        return entity.type == ItemID.LuckyHorseshoe;
    }

    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<LuckyHorseshoePlayer>().Enabled = !hideVisual;
    }
}
