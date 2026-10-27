namespace MerguelsLegacy.Content.Accessories;

[Autoload(Side = ModSide.Client)]
public sealed class VolatileGelatinSystem : ModSystem
{
    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        EquipLoader.AddEquipTexture(Mod, Assets.Images.Content.Accessories.VolatileGelatin_Head.KEY, EquipType.Head, null, nameof(ItemID.VolatileGelatin));
    }
}

public sealed class VolatileGelatinPlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the visual effects of the Volatile Gelatin are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the visual effects of the Volatile Gelatin are enabled; otherwise, <see langword="false"/>.
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

        Player.head = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.VolatileGelatin), EquipType.Head);
    }
}

public sealed class VolatileGelatinGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.VolatileGelatin;

    /// <inheritdoc/>
    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<VolatileGelatinPlayer>().Enabled = !hideVisual;
    }
}