using MerguelsLegacy.Common.World.Generation;
using MonoMod.Cil;

namespace MerguelsLegacy.Content.World.Town;

public sealed class SpawnMessageHooks : ILoadable
{
    /// <inheritdoc/> 
    void ILoadable.Load(Mod mod) => IL_WorldGen.SpawnTravelNPC += SpawnTravelNPC_Edit;
    
    /// <inheritdoc/> 
    void ILoadable.Unload() => IL_WorldGen.SpawnTravelNPC -= SpawnTravelNPC_Edit;
    
    private static void SpawnTravelNPC_Edit(ILContext il)
    {
        var c = new ILCursor(il);

        c.GotoNext(MoveType.After, static i => i.MatchLdstr("Announcement.HasArrived"));

        c.EmitLdloc(7);
        c.EmitLdloc(8);
        
        c.EmitDelegate(Fetch);
        
        c.GotoNext(MoveType.After, static i => i.MatchLdstr("Announcement.HasArrived"));

        c.EmitLdloc(7);
        c.EmitLdloc(8);
        
        c.EmitDelegate(Fetch);
    }

    private static string Fetch(string value, int x, int y)
    {
        var beach = x < WorldGen.beachDistance || x > Main.maxTilesX - WorldGen.beachDistance;

        if (beach)
        {
            return Mods.MerguelsLegacy.Announcements.TravellingMerchant.Beach.KEY;
        }
        
        var tiles = new TileCounter();
        
        tiles.Register(Desert.Tiles);
        tiles.Register(Hallow.Tiles);
        tiles.Register(Jungle.Tiles);
        tiles.Register(Mushroom.Tiles);
        tiles.Register(Snow.Tiles);
        
        var liquids = new LiquidCounter();
        
        liquids.Register(LiquidID.Shimmer);
        
        const int width = 64;
        const int height = 64;
        
        tiles.Scan(x, y, width, height);
        liquids.Scan(x, y, width, height);

        const int threshold = 100;
        
        if (tiles.Count(Desert.Tiles) >= threshold)
        {
            return Mods.MerguelsLegacy.Announcements.TravellingMerchant.Desert.KEY;
        }
        
        if (tiles.Count(Hallow.Tiles) >= threshold)
        {
            return Mods.MerguelsLegacy.Announcements.TravellingMerchant.Hallow.KEY;
        }

        if (tiles.Count(Jungle.Tiles) >= threshold)
        {
            return Mods.MerguelsLegacy.Announcements.TravellingMerchant.Jungle.KEY;
        }
        
        if (tiles.Count(Mushroom.Tiles) >= threshold)
        {
            return Mods.MerguelsLegacy.Announcements.TravellingMerchant.Mushroom.KEY;
        }
        
        if (tiles.Count(Snow.Tiles) >= threshold)
        {
            return Mods.MerguelsLegacy.Announcements.TravellingMerchant.Snow.KEY;
        }
        
        if (liquids.Count(LiquidID.Shimmer) >= threshold)
        {
            return Mods.MerguelsLegacy.Announcements.TravellingMerchant.Shimmer.KEY;
        }
        
        return value;
    }
}
