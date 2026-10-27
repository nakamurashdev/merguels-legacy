namespace MerguelsLegacy.Content.Multitools;

public class PlatinumMultitoolItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Multitools.PlatinumMultitoolItem.KEY;
    
    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        Item.autoReuse = true;
        
        Item.DamageType = DamageClass.Melee;
        
        Item.damage = 8;
        Item.knockBack = 5.5f;
        
        Item.hammer = 59;
        Item.pick = 59;
        Item.axe = 12;

        Item.UseSound = SoundID.Item1;
        Item.useTime = 17;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.rare = ItemRarityID.White;
    }

    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 12)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils)
            .Register();
    }
}