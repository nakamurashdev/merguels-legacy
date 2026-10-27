using System.IO;
using System.Runtime.CompilerServices;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;

namespace MerguelsLegacy.Content.Guide;

public class InflammableArrowProjectile : ModProjectile
{
    private readonly VertexStrip _strip = new();

    /// <summary>
    ///     Gets or sets a value indicating whether the projectile is stuck.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the projectile is stuck; otherwise, <see langword="false"/>.
    /// </value>
    public bool Stick
    {
        get;
        set;
    }

    /// <summary>
    ///     
    /// </summary>
    public int Target
    {
        get;
        set;
    }
    
    /// <inheritdoc/>
    public override string Texture => Assets.Images.Content.Guide.Arrows.InflammableArrowProjectile.KEY;

    /// <inheritdoc/>
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        ProjectileID.Sets.TrailingMode[Type] = 3;
        ProjectileID.Sets.TrailCacheLength[Type] = 64;
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
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        base.OnHitNPC(target, hit, damageDone);

        if (Stick)
        {
            return;
        }
        
        Stick = true;
        
        Target = target.whoAmI;
    }

    /// <inheritdoc/>
    public override void SendExtraAI(BinaryWriter writer)
    {
        base.SendExtraAI(writer);
        
        writer.Write(Stick);
        writer.Write7BitEncodedInt(Target);
    }

    /// <inheritdoc/>
    public override void ReceiveExtraAI(BinaryReader reader)
    {
        base.ReceiveExtraAI(reader);
        
        Stick = reader.ReadBoolean();
        Target = reader.Read7BitEncodedInt();
    }

    /// <inheritdoc/>
    public override void AI()
    {
        base.AI();

        if (!Stick)
        {
            return;
        }
        
        var target = Main.npc[Target];

        Projectile.Center = target.Center;
    }

    /// <inheritdoc/>
    public override bool PreDraw(ref Color lightColor)
    {
        DrawTrail();
        DrawProjectile(in lightColor);
        
        return false;
    }
    
    private void DrawTrail()
    {
        var data = GameShaders.Misc["FlameLash"];

        data.UseSaturation(-2f);
        data.Apply();
        
        _strip.PrepareStripWithProceduralPadding(Projectile.oldPos, Projectile.oldRot, DrawTrail_Color, DrawTrail_Width, -Main.screenPosition + Projectile.Size / 2f);
        _strip.DrawTrail();
        
        Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    private void DrawProjectile(in Color color)
    {
        var texture = TextureAssets.Projectile[Type].Value;

        var position = Projectile.Center - Main.screenPosition + new Vector2(DrawOffsetX, Projectile.gfxOffY);
        var origin = texture.Size() / 2f + new Vector2(DrawOriginOffsetX, DrawOriginOffsetY);
        
        var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        
        Main.EntitySpriteDraw(texture, position, null, Projectile.GetAlpha(color), Projectile.rotation, origin, Projectile.scale, effects);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Color DrawTrail_Color(float progress) => Color.Lerp(Color.Orange, Color.Red, progress) * (1f - progress);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static float DrawTrail_Width(float progress) => MathHelper.SmoothStep(32f, 8f, progress);
}