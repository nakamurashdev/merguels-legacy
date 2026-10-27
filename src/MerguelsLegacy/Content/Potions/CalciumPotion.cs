using MerguelsLegacy.Utilities;

namespace MerguelsLegacy.Content.Potions;

public class CalciumPotionItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Potions.CalciumPotionItem.KEY;

    /// <inheritdoc/> 
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Item.ResearchUnlockCount = 20;

        ItemID.Sets.DrinkParticleColors[Type] = [new(230, 222, 10), new(182, 226, 10), new(134, 230, 10)];
    }

    /// <inheritdoc/> 
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

        Item.buffTime = TimeUtilities.MinutesToFrames(8);
        Item.buffType = ModContent.BuffType<CalciumPotionBuff>();

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 4);
    }

    /// <inheritdoc/> 
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
    ///     The increase to the player's movement speed granted by the Calcium Potion.
    /// </summary>
    public const float MOVEMENT_SPEED_INCREASE = 0.25f;
    
    /// <summary>
    ///     The increase to the player's defense granted by the Calcium Potion.
    /// </summary>
    public const int DEFENSE_INCREASE = 8;
    
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Potions.CalciumPotionBuff.KEY;

    /// <inheritdoc/> 
    public override void Update(Player player, ref int buffIndex)
    {
        base.Update(player, ref buffIndex);

        player.statDefense += DEFENSE_INCREASE;

        player.moveSpeed += MOVEMENT_SPEED_INCREASE;
    }
}