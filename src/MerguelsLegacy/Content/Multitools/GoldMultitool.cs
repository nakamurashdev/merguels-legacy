namespace MerguelsLegacy.Content.Multitools;

public class GoldMultitoolItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Multitools.GoldMultitoolItem.KEY;
    
    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        Item.autoReuse = true;
        
        Item.DamageType = DamageClass.Melee;

        Item.damage = 7;
        Item.knockBack = 5.5f;
        
        Item.hammer = 55;
        Item.pick = 55;
        Item.axe = 11;

        Item.UseSound = SoundID.Item1;
        Item.useTime = 18;
        Item.useAnimation = 26;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.rare = ItemRarityID.White;
    }

    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 12)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils)
            .Register();
    }
}