namespace MerguelsLegacy.Content.Accessories;

[Autoload(Side = ModSide.Client)]
public sealed class RoyalGelSystem : ModSystem
{
    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        EquipLoader.AddEquipTexture(Mod, Assets.Images.Content.Accessories.RoyalGel_Head.KEY, EquipType.Head, null, nameof(ItemID.RoyalGel));
    }
}

public sealed class RoyalGelPlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the visual effects of the Royal Gel are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the visual effects of the Royal Gel are enabled; otherwise, <see langword="false"/>.
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

        Player.head = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.RoyalGel), EquipType.Head);
    }
}

public sealed class RoyalGelGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.RoyalGel;

    /// <inheritdoc/>
    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<RoyalGelPlayer>().Enabled = !hideVisual;
    }
}