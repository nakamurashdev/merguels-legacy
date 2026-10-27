namespace MerguelsLegacy.Content.Accessories;

[Autoload(Side = ModSide.Client)]
public sealed class MoltenCharmSystem : ModSystem
{
    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        EquipLoader.AddEquipTexture(Mod, Assets.Images.Content.Accessories.MoltenCharm_Neck.KEY, EquipType.Neck, null, nameof(ItemID.MoltenCharm));
    }
}

public sealed class MoltenCharmPlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the visual effects of the Molten Charm are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the visual effects of the Molten Charm are enabled; otherwise, <see langword="false"/>.
    /// </value>
    public bool Enabled
    {
        get;
        set;
    }

    /// <inheritdoc/>
    public override void ResetEffects()
    {
        base.ResetEffects();

        Enabled = false;
    }

    /// <inheritdoc/>
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
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.MoltenCharm;

    /// <inheritdoc/>
    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<MoltenCharmPlayer>().Enabled = !hideVisual;
    }
}