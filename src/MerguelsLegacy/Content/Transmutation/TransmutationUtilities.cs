using MerguelsLegacy.Content.Recipes;

namespace MerguelsLegacy.Content.Transmutation;

public static class TransmutationUtilities
{
    public static void Exchange(int left, int right) => RecipeUtilities.Exchange(left, right, ModContent.TileType<TransmutationStationTile>());
}