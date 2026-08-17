using MerguelsLegacy.Core.Announcements;

namespace MerguelsLegacy.Content.Announcements;

public sealed class OceanTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{
    public override bool MeetsConditions(NPC npc)
    {
        var position = npc.Center.ToTileCoordinates();

        return WorldGen.oceanDepths(position.X, position.Y);
    }
}

/*
public sealed class JungleTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{
    public override bool MeetsConditions(NPC npc)
    {
    }
}
*/

public sealed class CavernsTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{
    public override bool MeetsConditions(NPC npc)
    {
        var position = npc.Center.ToTileCoordinates();

        var underground = position.Y <= Main.rockLayer && position.Y > Main.worldSurface;
        var caverns = (double)position.Y <= Main.UnderworldLayer && position.Y > Main.rockLayer;

        return underground || caverns;
    }
}

/*
public sealed class DesertTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{

}

public sealed class SnowTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{

}

public sealed class MushroomTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{

}
*/

public sealed class UnderworldTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{
    public override bool MeetsConditions(NPC npc)
    {
        var position = npc.Center.ToTileCoordinates();

        return position.Y > Main.UnderworldLayer;
    }
}

/*
public sealed class HallowTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{

}

public sealed class ShimmerTravellingMerchantAnnouncement : ModTownNPCAnnouncement
{
    public override bool MeetsConditions(NPC npc)
    {
        var position = npc.Center.ToTileCoordinates();

        (double)position.Y > Main.worldSurface + 50.0 && position.Y / 16f < (float)(Main.maxTilesY - 330 - 100);
    }
}
*/