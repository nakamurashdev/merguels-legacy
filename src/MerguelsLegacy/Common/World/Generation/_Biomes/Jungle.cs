using System.Collections.Generic;

namespace MerguelsLegacy.Common.World.Generation;

public static class Jungle
{
    private static readonly int[] _tiles =
    [
        TileID.JungleGrass,
        TileID.JungleVines,
        TileID.JunglePlants,
        TileID.JungleThorns
    ];

    /// <summary>
    ///     Gets a read-only collection of tile types that are considered part of the Jungle biome.
    /// </summary>
    public static IReadOnlyCollection<int> Tiles => _tiles;
}