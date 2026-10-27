namespace MerguelsLegacy.Content.Accessories;

public sealed class BraceleofCompassionPlayer : ModPlayer
{
    /// <summary>
    ///     The increase to the player's life regeneration granted by the Regrowth Potion.
    /// </summary>
    public const int LIFE_REGENERATION_INCREASE = 1;
    
    /// <summary>
    ///     Gets or sets a value indicating whether the player has the effects of the Bracelet of Compassion.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the player has the effects of the Bracelet of Compassion; otherwise, <see langword="false"/>
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
    public override void UpdateLifeRegen()
    {
        base.UpdateLifeRegen();

        if (!Enabled)
        {
            return;
        }

        Player.lifeRegen += LIFE_REGENERATION_INCREASE;
        Player.lifeRegenTime += LIFE_REGENERATION_INCREASE;
    }
}

public class BraceletofCompassionItem : ModItem
{
    /// <summary>
    ///     The increase to the player's defense granted by the Bracelet of Compassion.
    /// </summary>
    public const int DEFENSE_INCREASE = 8;
    
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Common.Placeholder.KEY;

    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.accessory = true;
        
        Item.rare = ItemRarityID.Green;

        Item.value = Item.sellPrice(gold: 1, silver: 15);
    }

    /// <inheritdoc/> 
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        base.UpdateAccessory(player, hideVisual);

        player.statDefense += DEFENSE_INCREASE;

        player.GetModPlayer<BraceleofCompassionPlayer>().Enabled = true;
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.Shackle)
            .AddIngredient(ItemID.BandofRegeneration)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}