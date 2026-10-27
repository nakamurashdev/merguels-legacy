namespace MerguelsLegacy.Content.Guide;

public sealed class AdornedLongbowGlobalNPC : GlobalNPC
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.Guide;

    /// <inheritdoc/>
    public override void TownNPCAttackProj(NPC npc, ref int projType, ref int attackDelay)
    {
        base.TownNPCAttackProj(npc, ref projType, ref attackDelay);
        
        projType = ModContent.ProjectileType<InflammableArrowProjectile>();
    }

    /// <inheritdoc/>
    public override void DrawTownAttackGun(NPC npc, ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)
    {
        base.DrawTownAttackGun(npc, ref item, ref itemFrame, ref scale, ref horizontalHoldoutOffset);
        
        var texture = Assets.Images.Content.Guide.Bows.AdornedLongbow.Asset.Value;

        item = texture;
        itemFrame = texture.Frame();
    }
}