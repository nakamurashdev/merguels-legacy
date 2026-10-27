namespace MerguelsLegacy.Content.Multitools;

public class TinMultitoolItem : ModItem
{
    /// <inheritdoc/>
    public override string Texture => Assets.Images.Content.Multitools.TinMultitoolItem.KEY;
    
    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        Item.autoReuse = true;
        
        Item.DamageType = DamageClass.Melee;

        Item.damage = 4;
        Item.knockBack = 5.5f;
        
        Item.hammer = 38;
        Item.pick = 35;
        Item.axe = 8;

        Item.UseSound = SoundID.Item1;
        Item.useTime = 20;
        Item.useAnimation = 28;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.rare = ItemRarityID.White;
    }

    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.TinBar, 12)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils)
            .Register();
    }
}