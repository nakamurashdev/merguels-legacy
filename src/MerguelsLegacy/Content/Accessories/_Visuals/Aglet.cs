namespace MerguelsLegacy.Content.Accessories;

[Autoload(Side = ModSide.Client)]
public sealed class AgletSystem : ModSystem
{
    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        EquipLoader.AddEquipTexture(Mod, Assets.Images.Content.Accessories.Aglet_Shoes.KEY, EquipType.Shoes, null, nameof(ItemID.Aglet));
    }
}

public sealed class AgletPlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the visual effects of the Aglet are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the visual effects of the Aglet are enabled; otherwise, <see langword="false"/>.
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

        Player.shoe = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.Aglet), EquipType.Shoes);
    }
}

public sealed class AgletGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.Aglet;

    /// <inheritdoc/>
    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<AgletPlayer>().Enabled = !hideVisual;
    }
}