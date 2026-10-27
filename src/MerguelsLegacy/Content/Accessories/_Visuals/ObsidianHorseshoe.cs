namespace MerguelsLegacy.Content.Accessories;

[Autoload(Side = ModSide.Client)]
public sealed class ObsidianHorseshoeSystem : ModSystem
{
    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        EquipLoader.AddEquipTexture(Mod, Assets.Images.Content.Accessories.ObsidianHorseshoe_Shoes.KEY, EquipType.Shoes, null, nameof(ItemID.ObsidianHorseshoe));
    }
}

public sealed class ObsidianHorseshoePlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the visual effects of the Obsidian Horseshoe are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the visual effects of the Obsidian Horseshoe are enabled; otherwise, <see langword="false"/>.
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

        Player.shoe = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.ObsidianHorseshoe), EquipType.Shoes);
    }
}

public sealed class ObsidianHorseshoeGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.ObsidianHorseshoe;

    /// <inheritdoc/>
    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<ObsidianHorseshoePlayer>().Enabled = !hideVisual;
    }
}