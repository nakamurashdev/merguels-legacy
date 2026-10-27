namespace MerguelsLegacy.Content.Accessories;

[Autoload(Side = ModSide.Client)]
public sealed class HerculesBeetleSystem : ModSystem
{
    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        EquipLoader.AddEquipTexture(Mod, Assets.Images.Content.Accessories.HerculesBeetle_Head.KEY, EquipType.Head, null, nameof(ItemID.HerculesBeetle));
    }
}

public sealed class HerculesBeetlePlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the visual effects of the Hercules Beetle are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the visual effects of the Hercules Beetle are enabled; otherwise, <see langword="false"/>.
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

        Player.shoe = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.HerculesBeetle), EquipType.Head);
    }
}

public sealed class HerculesBeetleGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.HerculesBeetle;

    /// <inheritdoc/>
    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<HerculesBeetlePlayer>().Enabled = !hideVisual;
    }
}