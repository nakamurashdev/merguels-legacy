namespace MerguelsLegacy.Content.Guide;

public sealed class VeteranLongbowGlobalNPC : GlobalNPC
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.Demolitionist;

    /// <inheritdoc/>
    public override void TownNPCAttackProj(NPC npc, ref int projType, ref int attackDelay)
    {
        base.TownNPCAttackProj(npc, ref projType, ref attackDelay);

        projType = ModContent.ProjectileType<HollowArrowProjectile>();
    }

    /// <inheritdoc/>
    public override void TownNPCAttackShoot(NPC npc, ref bool inBetweenShots)
    {
        base.TownNPCAttackShoot(npc, ref inBetweenShots);

        inBetweenShots = true;
    }

    /// <inheritdoc/>
    public override void TownNPCAttackProjSpeed(NPC npc, ref float multiplier, ref float gravityCorrection, ref float randomOffset)
    {
        base.TownNPCAttackProjSpeed(npc, ref multiplier, ref gravityCorrection, ref randomOffset);

        multiplier *= 2f;
    }

    /// <inheritdoc/>
    public override void DrawTownAttackGun(NPC npc, ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)
    {
        base.DrawTownAttackGun(npc, ref item, ref itemFrame, ref scale, ref horizontalHoldoutOffset);

        var texture = Assets.Images.Content.Guide.Bows.VeteranLongbow.Asset.Value;

        item = texture;
        itemFrame = texture.Frame();
    }
}