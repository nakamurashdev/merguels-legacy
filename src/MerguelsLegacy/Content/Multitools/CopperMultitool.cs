namespace MerguelsLegacy.Content.Multitools;

public class CopperMultitoolItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Multitools.CopperMultitoolItem.KEY;
    
    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        Item.autoReuse = true;
        
        Item.DamageType = DamageClass.Melee;

        Item.damage = 3;
        Item.knockBack = 5.5f;
        
        Item.hammer = 35;
        Item.pick = 35;
        Item.axe = 7;

        Item.tileBoost = -1;

        Item.UseSound = SoundID.Item1;
        Item.useTime = 21;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.rare = ItemRarityID.White;
    }

    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.CopperBar, 12)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils)
            .Register();
    }
}