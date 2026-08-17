namespace MerguelsLegacy.Content.Transmutation;

public class TransmutationStationRecipes : ModSystem
{
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();

        #region Ores

        AddSwap(ItemID.CopperOre, ItemID.TinOre);
        AddSwap(ItemID.IronOre, ItemID.LeadOre);
        AddSwap(ItemID.SilverOre, ItemID.TungstenOre);
        AddSwap(ItemID.GoldOre, ItemID.PlatinumOre);
        AddSwap(ItemID.DemoniteOre, ItemID.CrimtaneOre);
        AddSwap(ItemID.CobaltOre, ItemID.PalladiumOre);
        AddSwap(ItemID.MythrilOre, ItemID.OrichalcumOre);
        AddSwap(ItemID.AdamantiteOre, ItemID.TitaniumOre);

        #endregion

        #region Bars

        AddSwap(ItemID.CopperBar, ItemID.TinBar);
        AddSwap(ItemID.IronBar, ItemID.LeadBar);
        AddSwap(ItemID.SilverBar, ItemID.TungstenBar);
        AddSwap(ItemID.GoldBar, ItemID.PlatinumBar);
        AddSwap(ItemID.DemoniteBar, ItemID.CrimtaneBar);
        AddSwap(ItemID.CobaltBar, ItemID.PalladiumBar);
        AddSwap(ItemID.MythrilBar, ItemID.OrichalcumBar);
        AddSwap(ItemID.AdamantiteBar, ItemID.TitaniumBar);

        #endregion

        #region Evil

        AddSwap(ItemID.CursedFlame, ItemID.Ichor);
        AddSwap(ItemID.TissueSample, ItemID.ShadowScale);
        AddSwap(ItemID.Vertebrae, ItemID.RottenChunk);
        AddSwap(ItemID.BoneRattle, ItemID.EatersBone);
        AddSwap(ItemID.CrimsonSeeds, ItemID.CorruptSeeds);
        AddSwap(ItemID.CrimsonKey, ItemID.CorruptionKey);
        AddSwap(ItemID.CrimstoneBlock, ItemID.EbonstoneBlock);
        AddSwap(ItemID.ViciousMushroom, ItemID.VileMushroom);
        AddSwap(ItemID.Ebonwood, ItemID.Shadewood);
        AddSwap(ItemID.WormScarf, ItemID.BrainOfConfusion);
        AddSwap(ItemID.Musket, ItemID.TheUndertaker);
        AddSwap(ItemID.ShadowOrb, ItemID.CrimsonHeart);
        AddSwap(ItemID.Vilethorn, ItemID.CrimsonRod);
        AddSwap(ItemID.BallOHurt, ItemID.TheRottedFork);
        AddSwap(ItemID.BandofStarpower, ItemID.PanicNecklace);
        AddSwap(ItemID.DartPistol, ItemID.DartRifle);
        AddSwap(ItemID.WormHook, ItemID.TendonHook);
        AddSwap(ItemID.ChainGuillotines, ItemID.FetidBaghnakhs);
        AddSwap(ItemID.ClingerStaff, ItemID.SoulDrain);
        AddSwap(ItemID.PutridScent, ItemID.FleshKnuckles);

        #endregion

        #region Ammo

        AddSwap(ItemID.SilverBullet, ItemID.TungstenBullet);

        #endregion
    }

    /// <summary>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown if <paramref name="a" /> or <paramref name="b" /> is negative or zero.
    /// </exception>
    private static void AddSwap(int a, int b)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(a);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(b);

        Recipe.Create(a)
            .AddIngredient(b)
            .AddTile<TransmutationStationTile>()
            .Register();

        Recipe.Create(b)
            .AddIngredient(a)
            .AddTile<TransmutationStationTile>()
            .Register();
    }
}

public class TransmutationStationItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Green;

        Item.value = Item.sellPrice(gold: 4);
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.Solidifier, 2)
            .AddIngredient(ItemID.HeavyWorkBench)
            .AddTile(TileID.Bookcases)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}

public class TransmutationStationTile : ModTile
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}