namespace MerguelsLegacy.Content.Accessories;

[Autoload(Side = ModSide.Client)]
public sealed class EyeoftheGolemSystem : ModSystem
{
    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        EquipLoader.AddEquipTexture(Mod, Assets.Images.Content.Accessories.EyeoftheGolem_Head.KEY, EquipType.Head, null, nameof(ItemID.EyeoftheGolem));
    }
    
    /// <inheritdoc/>
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        var slot = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.EyeoftheGolem), EquipType.Head);
        
        ArmorIDs.Head.Sets.DrawHead[slot] = true;
        ArmorIDs.Head.Sets.DrawFullHair[slot] = true;
    }
}

public sealed class EyeoftheGolemPlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the visual effects of the Eye of the Golem are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the visual effects of the Eye of the Golem are enabled; otherwise, <see langword="false"/>.
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

        Player.head = EquipLoader.GetEquipSlot(Mod, nameof(ItemID.EyeoftheGolem), EquipType.Head);
    }
}

public sealed class EyeoftheGolemGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.EyeoftheGolem;
    
    /// <inheritdoc/>
    public override void UpdateAccessory(Item item, Player player, bool hideVisual)
    {
        base.UpdateAccessory(item, player, hideVisual);

        player.GetModPlayer<EyeoftheGolemPlayer>().Enabled = !hideVisual;
    }
}