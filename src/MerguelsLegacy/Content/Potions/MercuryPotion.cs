using MerguelsLegacy.Utilities;

namespace MerguelsLegacy.Content.Potions;

public class MercuryPotionItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Potions.MercuryPotionItem.KEY;
    
    /// <inheritdoc/> 
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Item.ResearchUnlockCount = 20;

        ItemID.Sets.DrinkParticleColors[Type] = [new(255, 56, 162), new(195, 143, 86), new(134, 230, 10)];
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
        Item.buffType = ModContent.BuffType<MercuryPotionBuff>();

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 4);
    }

    /// <inheritdoc/> 
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
    ///     The increase to the player's movement speed granted by the Mercury Potion.
    /// </summary>
    public const float MOVEMENT_SPEED_INCREASE = 0.25f;
    
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Potions.MercuryPotionBuff.KEY;

    /// <inheritdoc/> 
    public override void Update(Player player, ref int buffIndex)
    {
        base.Update(player, ref buffIndex);

        player.moveSpeed += MOVEMENT_SPEED_INCREASE;

        player.GetModPlayer<MercuryPotionPlayer>().Enabled = true;
    }
}

public sealed class MercuryPotionPlayer : ModPlayer
{
    /// <summary>
    ///     The increase to the player's life regeneration granted by the Mercury Potion.
    /// </summary>
    public const int LIFE_REGENERATION_INCREASE = 2;

    /// <summary>
    ///     Gets or sets a value indicating whether the player has the effects of the Mercury Potion.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the player has the effects of the Mercury Potion; otherwise, <see langword="false"/>.
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