namespace MerguelsLegacy.Content.Accessories;

[Autoload(Side = ModSide.Client)]
public sealed class LuckyHorseshoeSystem : ModSystem
{
    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        EquipLoader.AddEquipTexture(Mod, Assets.Images.Content.Accessories.LuckyHorseshoe_Shoes.KEY, EquipType.Shoes, null, nameof(ItemID.LuckyHorseshoe));
    }
}

public sealed class LuckyHorseshoePlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the visual effects of the Lucky Horseshoe are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the visual effects of the Lucky Horseshoe are enabled; otherwise, <see langword="false"/>.
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

        Player.shoe = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.LuckyHorseshoe), EquipType.Shoes);
    }
}

public sealed class LuckyHorseshoeGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.LuckyHorseshoe;

    /// <inheritdoc/>
    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<LuckyHorseshoePlayer>().Enabled = !hideVisual;
    }
}