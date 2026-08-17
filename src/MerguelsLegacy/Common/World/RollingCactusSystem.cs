using MerguelsLegacy.Common.Configuration;
using Terraria.DataStructures;

namespace MerguelsLegacy.Common.World;

public sealed class RollingCactusGlobalTile : GlobalTile
{
    public override bool CanPlace(int i, int j, int type)
    {
        var enabled = ServerSideConfiguration.Instance.EnableRollingCactus ? type != TileID.RollingCactus : true;

        return enabled;
    }
}

public sealed class RollingCactusGlobalProjectile : GlobalProjectile
{
    public override bool AppliesToEntity(Projectile entity, bool lateInstantiation) => entity.type == ProjectileID.RollingCactus;

    public override void OnSpawn(Projectile projectile, IEntitySource source)
    {
        base.OnSpawn(projectile, source);

        Kill(projectile);
    }

    public override void AI(Projectile projectile)
    {
        base.AI(projectile);

        Kill(projectile);
    }

    private static void Kill(Projectile projectile)
    {
        if (ServerSideConfiguration.Instance.EnableRollingCactus)
        {
            return;
        }

        projectile.Kill();
    }
}