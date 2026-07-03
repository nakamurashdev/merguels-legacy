namespace MerguelsLegacy.Common.Accessories;

public sealed class MoltenCharmPlayer : ModPlayer
{
    private static readonly string TEXTURE_PATH = $"{nameof(MerguelsLegacy)}/Assets/Textures/Accessories/{nameof(ItemID.MoltenCharm)}_{EquipType.Neck}";
    
    /// <summary>
    ///     Gets or sets whether the effects of the <see cref="ItemID.MoltenCharm"/> are enabled.
    /// </summary>
    public bool Enabled { get; set; }
    
    public override void Load()
    {
        base.Load();

        if (Main.netMode == NetmodeID.Server)
        {
            return;
        }

        EquipLoader.AddEquipTexture(Mod, TEXTURE_PATH, EquipType.Neck, null, nameof(ItemID.MoltenCharm));
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

        Player.neck = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.MoltenCharm), EquipType.Neck);
    }
}

public sealed class MoltenCharmGlobalItem : GlobalItem
{
    public override bool AppliesToEntity(Item entity, bool lateInstantiation)
    {
        return entity.type == ItemID.MoltenCharm;
    }

    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<MoltenCharmPlayer>().Enabled = !hideVisual;
    }
}
