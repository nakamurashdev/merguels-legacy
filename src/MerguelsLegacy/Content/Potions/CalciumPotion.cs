using MerguelsLegacy.Common.Items;
using MerguelsLegacy.Utilities;

namespace MerguelsLegacy.Content.Potions;

public class CalciumPotionItem : ModItem
{
    /// <summary>
    ///     The duration of the buff applied by the item, in ticks.
    /// </summary>
    /// <remarks>
    ///     Equivalent to 8 minutes (8 * 60 seconds * 60 ticks).
    /// </remarks>
    public const int BUFF_TIME = 8 * TimeUtilities.MINUTE_IN_SECONDS * TimeUtilities.SECOND_IN_TICKS;

    /// <summary>
    ///     The colors of the particles that are emitted when the potion is consumed.
    /// </summary>
    public static readonly Color[] Colors =
    [
        new(230, 222, 10),
        new(182, 226, 10),
        new(134, 230, 10)
    ];

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Item.ResearchUnlockCount = ItemSacrifices.Potions;

        ItemID.Sets.DrinkParticleColors[Type] = Colors;
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.maxStack = Item.CommonMaxStack;

        Item.consumable = true;
        Item.useTurn = true;

        Item.width = 12;
        Item.height = 30;

        Item.UseSound = SoundID.Item3;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;

        Item.buffTime = BUFF_TIME;
        Item.buffType = ModContent.BuffType<CalciumPotionBuff>();

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 4);
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.SwiftnessPotion)
            .AddIngredient(ItemID.IronskinPotion)
            .AddIngredient(ItemID.FallenStar)
            .AddTile(TileID.Bottles)
            .Register();
    }
}

public class CalciumPotionBuff : ModBuff
{
    /// <summary>
    ///     The defense bonus provided by the buff.
    /// </summary>
    public const int DEFENSE_BONUS = 8;

    /// <summary>
    ///     The movement speed bonus provided by the buff.
    /// </summary>
    public const float MOVEMENT_SPEED_BONUS = 0.25f;

    public override void Update(Player player, ref int buffIndex)
    {
        base.Update(player, ref buffIndex);

        player.statDefense += DEFENSE_BONUS;

        player.moveSpeed += MOVEMENT_SPEED_BONUS;
    }
}