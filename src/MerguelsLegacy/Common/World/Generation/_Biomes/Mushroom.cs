using System.Collections.Generic;

namespace MerguelsLegacy.Common.World.Generation;

public static class Mushroom
{
    private static readonly int[] _tiles =
    [
        TileID.MushroomBlock,
        TileID.MushroomGrass,
        TileID.MushroomPlants,
        TileID.MushroomVines
    ];
    
    /// <summary>
    ///     Gets a read-only collection of tile types that are considered part of the Mushroom biome.
    /// </summary>
    public static IReadOnlyCollection<int> Tiles => _tiles;
}