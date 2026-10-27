using System.Collections.Generic;

namespace MerguelsLegacy.Common.World.Generation;

public static class Desert
{
    private static readonly int[] _tiles =
    [
        TileID.Cactus,
        TileID.Sand,
        TileID.Sandstone,
        TileID.HardenedSand
    ];
    
    /// <summary>
    ///     Gets a read-only collection of tile types that are considered part of the Desert biome.
    /// </summary>
    public static IReadOnlyCollection<int> Tiles => _tiles;
}