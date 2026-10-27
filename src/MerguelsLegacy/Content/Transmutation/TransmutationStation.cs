namespace MerguelsLegacy.Content.Transmutation;

public class TransmutationStationItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Common.Placeholder.KEY;
    
    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<TransmutationStationTile>());
        
        Item.UseSound = SoundID.Item1;
        Item.useTime = 18;
        Item.useAnimation = 18;
        Item.useStyle = ItemUseStyleID.Swing;
        
        Item.rare = ItemRarityID.Green;

        Item.value = Item.sellPrice(gold: 4);
    }

    /// <inheritdoc/> 
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
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Common.Placeholder.KEY;
    
    /// <inheritdoc/> 
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;
    }

    /// <inheritdoc/> 
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}