using System.Collections.Generic;

namespace MerguelsLegacy.Common.World.Generation;

public class Hallow
{
    private static readonly int[] _tiles =
    [
        TileID.HallowedGrass,
        TileID.HallowedPlants,
        TileID.HallowedPlants2,
        TileID.HallowedVines,
        TileID.HallowedIce,
        TileID.Pearlsand,
        TileID.Pearlstone,
        TileID.HallowSandstone,
        TileID.HallowHardenedSand
    ];
    
    /// <summary>
    ///     Gets a read-only collection of tile types that are considered part of the Hallow biome.
    /// </summary>
    public static IReadOnlyCollection<int> Tiles => _tiles;
}