namespace MerguelsLegacy.Content.Potions;

public class ResurrectionPotionItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Potions.ResurrectionPotionItem.KEY;
    
    /// <inheritdoc />
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Item.ResearchUnlockCount = 20;

        ItemID.Sets.DrinkParticleColors[Type] = [new(28, 216, 94), new(141, 171, 72), new(246, 203, 52)];
    }

    /// <inheritdoc />
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.maxStack = Item.CommonMaxStack;

        Item.consumable = true;
        Item.useTurn = true;

        Item.width = 20;
        Item.height = 26;

        Item.UseSound = SoundID.Item3;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 2);
    }

    /// <inheritdoc />
    public override bool CanUseItem(Player player) => player.lastDeathPostion != Vector2.Zero;

    /// <inheritdoc />
    public override bool? UseItem(Player player)
    {
        player.Teleport(player.lastDeathPostion - player.Size / 2f, TeleportationStyleID.DebugTeleport);

        return true;
    }

    /// <inheritdoc />
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.Gravestone, 2)
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(ItemID.FallenStar, 2)
            .AddIngredient(ItemID.DaybloomSeeds, 2)
            .AddTile(TileID.Bottles)
            .Register();
    }
}