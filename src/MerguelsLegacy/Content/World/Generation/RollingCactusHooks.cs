using MerguelsLegacy.Common.Configuration;

namespace MerguelsLegacy.Content.World.Generation;

public sealed class RollingCactusGlobalProjectile : GlobalProjectile
{
    /// <inheritdoc/> 
    public override bool AppliesToEntity(Projectile entity, bool lateInstantiation) => entity.type == ProjectileID.RollingCactus || entity.type == ProjectileID.RollingCactusSpike;

    /// <inheritdoc/> 
    public override void SetDefaults(Projectile entity)
    {
        base.SetDefaults(entity);

        if (!ServerSideConfiguration.Instance.EnableRollingCactus)
        {
            return;
        }

        entity.hostile = false;
        entity.friendly = true;
    }
}