using MerguelsLegacy.Common.Items;
using Terraria.Enums;
using Terraria.ObjectData;

namespace MerguelsLegacy.Content.Asphalt;

public class AsphaltPlatformItem : ModItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Item.ResearchUnlockCount = Sacrifices.Blocks;
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<AsphaltPlatformTile>());
        
        Item.width = 24;
        Item.height = 12;
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe(2)
            .AddIngredient(ItemID.AsphaltBlock)
            .Register();
    }
}

public class AsphaltPlatformTile : ModTile
{
    /// <summary>
    ///     The color of the tile on the map.
    /// </summary>
    public static readonly Color Color = new(32, 33, 34);
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.tileFrameImportant[Type] = true;
        Main.tileLighted[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileTable[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        
        TileID.Sets.Platforms[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        HitSound = SoundID.Dig;
        DustType = DustID.Asphalt;
        
        AdjTiles = [TileID.Platforms];
        
        VanillaFallbackOnModDeletion = TileID.Platforms;
        
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
        
        AddMapEntry(Color);
        
        TileObjectData.newTile.CoordinateHeights = [16];
        TileObjectData.newTile.CoordinateWidth = 16;
        
        TileObjectData.newTile.CoordinatePadding = 2;
        
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleMultiplier = 27;
        TileObjectData.newTile.StyleWrapLimit = 27;
        
        TileObjectData.newTile.LavaDeath = true;
        
        TileObjectData.newTile.UsesCustomCanPlace = false;

        TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        
        TileObjectData.addTile(Type);
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }

    public override void FloorVisuals(Player player)
    {
        base.FloorVisuals(player);

        player.powerrun = true;
    }
}