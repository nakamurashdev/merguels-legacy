namespace MerguelsLegacy.Common.Accessories;

public sealed class VolatileGelatinPlayer : ModPlayer
{
    private static readonly string TEXTURE_PATH = $"{nameof(MerguelsLegacy)}/Assets/Textures/Accessories/{nameof(ItemID.VolatileGelatin)}_{EquipType.Head}";
    
    /// <summary>
    ///     Gets or sets whether the effects of the <see cref="ItemID.VolatileGelatin"/> are enabled.
    /// </summary>
    public bool Enabled { get; set; }
    
    public override void Load()
    {
        base.Load();

        if (Main.netMode == NetmodeID.Server)
        {
            return;
        }

        EquipLoader.AddEquipTexture(Mod, TEXTURE_PATH, EquipType.Head, null, nameof(ItemID.VolatileGelatin));
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
        
        Player.head = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.VolatileGelatin), EquipType.Head);
    }
}

public sealed class VolatileGelatinGlobalItem : GlobalItem
{
    public override bool AppliesToEntity(Item entity, bool lateInstantiation)
    {
        return entity.type == ItemID.VolatileGelatin;
    }

    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<VolatileGelatinPlayer>().Enabled = !hideVisual;
    }
}