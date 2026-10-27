using MerguelsLegacy.Utilities;

namespace MerguelsLegacy.Content.Potions;

public class TrinityPotionItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Potions.TrinityPotionItem.KEY;
    
    /// <inheritdoc/> 
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Item.ResearchUnlockCount = 20;

        ItemID.Sets.DrinkParticleColors[Type] = [new(230, 222, 10), new(255, 56, 162), new(134, 230, 10)];
    }

    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.maxStack = Item.CommonMaxStack;

        Item.consumable = true;
        Item.useTurn = true;

        Item.width = 16;
        Item.height = 30;

        Item.UseSound = SoundID.Item3;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;

        Item.buffTime = TimeUtilities.MinutesToFrames(10);
        Item.buffType = ModContent.BuffType<TrinityPotionBuff>();

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 6);
    }

    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.SwiftnessPotion)
            .AddIngredient(ItemID.RegenerationPotion)
            .AddIngredient(ItemID.IronskinPotion)
            .AddIngredient(ItemID.FallenStar, 2)
            .AddTile(TileID.Bottles)
            .Register();
    }
}

public class TrinityPotionBuff : ModBuff
{
    /// <summary>
    ///     The increase to the player's movement speed granted by the Trinity Potion.
    /// </summary>
    public const float MOVEMENT_SPEED_INCREASE = 0.25f;
    
    /// <summary>
    ///     The increase to the player's defense granted by the Trinity Potion.
    /// </summary>
    public const int DEFENSE_INCREASE = 8;
    
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Potions.TrinityPotionBuff.KEY;

    /// <inheritdoc/> 
    public override void Update(Player player, ref int buffIndex)
    {
        base.Update(player, ref buffIndex);

        player.statDefense += DEFENSE_INCREASE;

        player.moveSpeed += MOVEMENT_SPEED_INCREASE;

        player.GetModPlayer<TrinityPotionPlayer>().Enabled = true;
    }
}

public class TrinityPotionPlayer : ModPlayer
{
    /// <summary>
    ///     The increase to the player's life regeneration granted by the Trinity Potion.
    /// </summary>
    public const int LIFE_REGENERATION_INCREASE = 2;

    /// <summary>
    ///     Gets or sets a value indicating whether the player has the effects of the Trinity Potion.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the player has the effects of the Trinity Potion; otherwise, <see langword="false"/>.
    /// </value>
    public bool Enabled
    {
        get;
        set;
    }

    /// <inheritdoc/> 
    public override void ResetEffects()
    {
        base.ResetEffects();

        Enabled = false;
    }

    /// <inheritdoc/> 
    public override void UpdateLifeRegen()
    {
        base.UpdateLifeRegen();

        if (!Enabled)
        {
            return;
        }

        Player.lifeRegen += LIFE_REGENERATION_INCREASE;
        Player.lifeRegenTime += LIFE_REGENERATION_INCREASE;
    }
}