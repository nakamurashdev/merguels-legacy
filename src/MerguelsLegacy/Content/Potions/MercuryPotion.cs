using MerguelsLegacy.Common.Items;
using MerguelsLegacy.Utilities;

namespace MerguelsLegacy.Content.Potions;

public class MercuryPotionItem : ModItem
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
        new Color(255, 56, 162),
        new Color(195, 143, 86),
        new Color(134, 230, 10)
    ];
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Item.ResearchUnlockCount = Sacrifices.Potions;
        
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
        Item.buffType = ModContent.BuffType<MercuryPotionBuff>();

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 4);
    }
    
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.SwiftnessPotion)
            .AddIngredient(ItemID.RegenerationPotion)
            .AddIngredient(ItemID.FallenStar)
            .AddTile(TileID.Bottles)
            .Register();
    }
}

public class MercuryPotionBuff : ModBuff
{
    /// <summary>
    ///     The movement speed bonus provided by the buff.
    /// </summary>
    public const float MOVEMENT_SPEED_BONUS = 0.25f;
    
    public override void Update(Player player, ref int buffIndex)
    {
        base.Update(player, ref buffIndex);

        player.moveSpeed += MOVEMENT_SPEED_BONUS;

        player.GetModPlayer<MercuryPotionPlayer>().Enabled = true;
    }
}


public sealed class MercuryPotionPlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the player is currently under the effect of the Untouchable buff.
    /// </summary>
    public bool Enabled { get; set; }

    public override void ResetEffects()
    {
        base.ResetEffects();

        Enabled = false;
    }

    public override void UpdateLifeRegen()
    {
        base.UpdateLifeRegen();

        if (!Enabled)
        {
            return;
        }
        
        Player.lifeRegen += 2;
        Player.lifeRegenTime += 2f;
    }
}