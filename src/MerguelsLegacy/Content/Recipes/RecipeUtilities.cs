namespace MerguelsLegacy.Content.Recipes;

public static class RecipeUtilities
{
    public static void Exchange(int left, int right, int tile)
    {
        Recipe.Create(left)
            .AddIngredient(right)
            .AddTile(tile)
            .Register();

        Recipe.Create(right)
            .AddIngredient(left)
            .AddTile(tile)
            .Register();
    }
}