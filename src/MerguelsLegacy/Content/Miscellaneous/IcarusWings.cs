namespace MerguelsLegacy.Content.Miscellaneous;

public class IcarusWingsItem : ModItem
{
    /// <inheritdoc/>
    public override string Texture => Assets.Images.Common.Placeholder.KEY;

    /// <inheritdoc/>
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        // ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(10);
    }

    /// <inheritdoc/>
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.accessory = true;
        
        Item.rare = ItemRarityID.Gray;

        Item.value = Item.sellPrice(silver: 16);
    }

    /// <inheritdoc/>
    public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
    {
        base.HorizontalWingSpeeds(player, ref speed, ref acceleration);
    }
    
    /// <inheritdoc/>
    public override void VerticalWingSpeeds
    (
        Player player, 
        ref float ascentWhenFalling, 
        ref float ascentWhenRising,
        ref float maxCanAscendMultiplier, 
        ref float maxAscentMultiplier, 
        ref float constantAscend
    )
    {
        base.VerticalWingSpeeds(player, ref ascentWhenFalling, ref ascentWhenRising, ref maxCanAscendMultiplier, ref maxAscentMultiplier, ref constantAscend);
    }

    /// <inheritdoc/>
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.Gel, 400)
            .AddRecipeGroup(RecipeGroupID.Wood, 100)
            .AddIngredient(ItemID.Silk, 40)
            .AddIngredient(ItemID.Rope, 100)
            .AddTile(TileID.Loom)
            .Register();
        
        CreateRecipe()
            .AddIngredient(ItemID.Gel, 400)
            .AddRecipeGroup(RecipeGroupID.Wood, 100)
            .AddIngredient(ItemID.Silk, 40)
            .AddIngredient(ItemID.VineRope, 100)
            .AddTile(TileID.Loom)
            .Register();
    }
}