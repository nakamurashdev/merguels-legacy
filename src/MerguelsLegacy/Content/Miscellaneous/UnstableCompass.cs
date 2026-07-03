using MerguelsLegacy.Utilities;

namespace MerguelsLegacy.Content.Miscellaneous;

public class UnstableCompassItem : ModItem
{
    /// <summary>
    ///     The duration of the buff applied by the item, in ticks.
    /// </summary>
    /// <remarks>
    ///     Equivalent to 3 seconds (3 seconds * 60 ticks).
    /// </remarks>
    public const int BUFF_TIME = 3 * TimeUtilities.SECOND_IN_TICKS;
    
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.useTurn = true;
        
        Item.mana = 100;

        Item.width = 34;
        Item.height = 34;

        Item.UseSound = SoundID.Item117;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.HoldUp;
        
        Item.buffTime = BUFF_TIME;
        Item.buffType = ModContent.BuffType<UnstableCompassBuff>();

        Item.rare = ItemRarityID.Gray;
    }

    public override bool? UseItem(Player player)
    {
        return base.UseItem(player);
    }
}

public class UnstableCompassBuff : ModBuff
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Main.debuff[Type] = true;
        
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        base.Update(player, ref buffIndex);
        
        player.cursed = true;
        player.confused = true;
        
        var time = player.buffTime[buffIndex];

        if (time <= UnstableCompassItem.BUFF_TIME - TimeUtilities.SECOND_IN_TICKS)
        {
            return;
        }

        player.stoned = true;
    }
}
