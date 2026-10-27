namespace MerguelsLegacy.Content.Accessories;

public class RedHorseshoeBallonItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Common.Placeholder.KEY;

    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.accessory = true;
        
        Item.rare = ItemRarityID.Orange;

        Item.value = Item.sellPrice(gold: 2, silver: 4);
    }

    /// <inheritdoc/> 
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        base.UpdateAccessory(player, hideVisual);

        player.jumpBoost = true;
        player.noFallDmg = true;
    }

    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.ShinyRedBalloon)
            .AddIngredient(ItemID.LuckyHorseshoe)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}