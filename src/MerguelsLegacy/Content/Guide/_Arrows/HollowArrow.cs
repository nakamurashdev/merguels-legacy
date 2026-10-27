using Terraria.GameContent;

namespace MerguelsLegacy.Content.Guide;

public class HollowArrowProjectile : ModProjectile
{
    /// <inheritdoc/>
    public override string Texture => Assets.Images.Content.Guide.Arrows.HollowArrowProjectile.KEY;

    /// <inheritdoc/>
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        ProjectileID.Sets.TrailingMode[Type] = 2;
        ProjectileID.Sets.TrailCacheLength[Type] = 8;
    }

    /// <inheritdoc/>
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.friendly = true;
        Projectile.hostile = false;

        Projectile.width = 8;
        Projectile.height = 8;

        Projectile.penetrate = -1;

        Projectile.aiStyle = ProjAIStyleID.Arrow;

        AIType = ProjectileID.WoodenArrowFriendly;
    }

    /// <inheritdoc/>
    public override bool PreDraw(ref Color lightColor)
    {
        DrawTrail(in lightColor);
        DrawProjectile(in lightColor);
        
        return false;
    }
    
    private void DrawTrail(in Color color)
    {
        var texture = TextureAssets.Projectile[Type].Value;
        var length = ProjectileID.Sets.TrailCacheLength[Type];

        const int step = 2;

        for (var i = 0; i < length; i += step)
        {
            var center = Projectile.oldPos[i] + Projectile.Size / 2f;
            
            var position = center - Main.screenPosition + new Vector2(DrawOffsetX, Projectile.gfxOffY);
            var origin = texture.Size() / 2f + new Vector2(DrawOriginOffsetX, DrawOriginOffsetY);
            
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        
            var multiplier = (length - i) / (float)length;
            
            Main.EntitySpriteDraw(texture, position, null, Projectile.GetAlpha(color) * multiplier, Projectile.rotation, origin, Projectile.scale, effects);
        }
    }

    private void DrawProjectile(in Color color)
    {
        var texture = TextureAssets.Projectile[Type].Value;

        var position = Projectile.Center - Main.screenPosition + new Vector2(DrawOffsetX, Projectile.gfxOffY);
        var origin = texture.Size() / 2f + new Vector2(DrawOriginOffsetX, DrawOriginOffsetY);
        
        var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        
        Main.EntitySpriteDraw(texture, position, null, Projectile.GetAlpha(color), Projectile.rotation, origin, Projectile.scale, effects);
    }
}