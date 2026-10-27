using MerguelsLegacy.Utilities;

namespace MerguelsLegacy.Content.Miscellaneous;

public class UnstableCompassItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Miscellaneous.UnstableCompassItem.KEY;

    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.mana = 100;
        
        Item.width = 28;
        Item.height = 28;

        Item.UseSound = SoundID.Item1;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.HoldUp;
        
        Item.buffType = ModContent.BuffType<UnstableCompassBuff>();
        Item.buffTime = TimeUtilities.SecondsToFrames(3);
        
        Item.rare = ItemRarityID.Gray;
    }
}

public class UnstableCompassBuff : ModBuff
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Common.Placeholder.KEY;

    /// <inheritdoc/> 
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        
        Main.debuff[Type] = true;
    }

    /// <inheritdoc/> 
    public override void Update(Player player, ref int buffIndex)
    {
        base.Update(player, ref buffIndex);

        player.cursed = true;
        player.confused = true;
        
        var time = player.buffTime[buffIndex];
        
        var duration = TimeUtilities.SecondsToFrames(3);
        var threshold = TimeUtilities.SecondsToFrames(1);
        
        if (time <= duration - threshold)
        {
            return;
        }

        player.stoned = true;
    }
}