namespace MerguelsLegacy.Content.Multitools;

public class LeadMultitoolItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Multitools.LeadMultitoolItem.KEY;
    
    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        Item.autoReuse = true;
        
        Item.DamageType = DamageClass.Melee;
        
        Item.damage = 6;
        Item.knockBack = 5.5f;
        
        Item.hammer = 43;
        Item.pick = 43;
        Item.axe = 10;

        Item.UseSound = SoundID.Item1;
        Item.useTime = 19;
        Item.useAnimation = 28;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.rare = ItemRarityID.White;
    }

    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.LeadBar, 12)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils)
            .Register();
    }
}