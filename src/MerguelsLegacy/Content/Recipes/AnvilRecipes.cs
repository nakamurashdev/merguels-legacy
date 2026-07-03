namespace MerguelsLegacy.Content.Recipes;

public sealed class AnvilRecipes : ModSystem
{
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();

        Recipe.Create(ItemID.BallOHurt)
            .AddIngredient(ItemID.DemoniteBar, 10)
            .AddIngredient(ItemID.ShadowScale, 5)
            .AddTile(TileID.Anvils)
            .Register();

        Recipe.Create(ItemID.Hellforge)
            .AddIngredient(ItemID.Furnace)
            .AddIngredient(ItemID.HellstoneBar, 20)
            .AddTile(TileID.Anvils)
            .Register();
    }
}