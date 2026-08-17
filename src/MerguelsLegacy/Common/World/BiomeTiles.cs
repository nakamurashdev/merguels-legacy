namespace MerguelsLegacy.Common.World;

public static class BiomeTiles
{
    /// <summary>
    ///     The tile types that represent the <see href="https://terraria.wiki.gg/wiki/Jungle">Jungle</see>
    ///     biome.
    /// </summary>
    public static readonly int[] Jungle =
    [
        TileID.JungleGrass,
        TileID.JunglePlants,
        TileID.JunglePlants2,
        TileID.JungleThorns,
        TileID.JungleVines,
        TileID.Mud
    ];

    /// <summary>
    ///     The tiles that represent the <see href="https://terraria.wiki.gg/wiki/Desert">Desert</see>
    ///     biome.
    /// </summary>
    public static readonly int[] Desert =
    [
        TileID.Sand,
        TileID.HardenedSand,
        TileID.Sandstone,
        TileID.FossilOre,
        TileID.DesertFossil
    ];

    /// <summary>
    ///     The tiles that represent the <see href="https://terraria.wiki.gg/wiki/Snow_biome">Snow</see>
    ///     biome.
    /// </summary>
    public static readonly int[] Snow =
    [
        TileID.SnowBlock,
        TileID.IceBlock
    ];

    /// <summary>
    ///     The tiles that represent the
    ///     <see href="https://terraria.wiki.gg/wiki/Glowing_Mushroom">Glowing Mushroom</see> biome.
    /// </summary>
    public static readonly int[] Mushroom =
    [
        TileID.Mud,
        TileID.MushroomGrass
    ];

    /// <summary>
    ///     The tiles that represent the <see href="https://terraria.wiki.gg/wiki/The_Hallow">Hallow</see>
    ///     biome.
    /// </summary>
    public static readonly int[] Hallow =
    [
        TileID.Pearlsand,
        TileID.Pearlstone,
        TileID.HallowedGrass,
        TileID.HallowedIce,
        TileID.HallowedPlants,
        TileID.HallowedPlants2,
        TileID.HallowedVines,
        TileID.HallowHardenedSand,
        TileID.HallowSandstone
    ];
}