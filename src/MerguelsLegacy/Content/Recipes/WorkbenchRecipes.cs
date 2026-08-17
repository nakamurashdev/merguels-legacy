namespace MerguelsLegacy.Content.Recipes;

public sealed class WorkbenchRecipes : ModSystem
{
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();

        Recipe.Create(ItemID.GoldenChest)
            .AddIngredient(ItemID.GoldBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.IvyChest)
            .AddIngredient(ItemID.MudstoneBlock, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.WaterChest)
            .AddIngredient(ItemID.CoralstoneBlock, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.WebCoveredChest)
            .AddIngredient(ItemID.SpiderBlock, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.ShadowChest)
            .AddIngredient(ItemID.DemoniteBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.ShadowChest)
            .AddIngredient(ItemID.CrimtaneBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}