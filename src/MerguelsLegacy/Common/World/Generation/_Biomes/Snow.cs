using System.Collections.Generic;

namespace MerguelsLegacy.Common.World.Generation;

public static class Snow
{
    private static readonly int[] _tiles =
    [
        TileID.SnowBlock,
        TileID.IceBlock,
        TileID.BreakableIce
    ];
    
    /// <summary>
    ///     Gets a read-only collection of tile types that are considered part of the Snow biome.
    /// </summary>
    public static IReadOnlyCollection<int> Tiles => _tiles;
}