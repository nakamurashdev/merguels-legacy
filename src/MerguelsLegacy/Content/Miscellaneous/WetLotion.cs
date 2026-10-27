using MerguelsLegacy.Content.Transmutation;

namespace MerguelsLegacy.Content.Miscellaneous;

public class WetLotionItem : ModItem
{
    /// <inheritdoc/>
    public override string Texture => Assets.Images.Content.Miscellaneous.WetLotionItem.KEY;

    /// <inheritdoc/>
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.maxStack = Item.CommonMaxStack;

        Item.consumable = true;

        Item.width = 24;
        Item.height = 22;
        
        Item.rare = ItemRarityID.Blue;
        
        Item.value = Item.sellPrice(silver: 75);
    }

    /// <inheritdoc/>
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.WaterBucket)
            .AddIngredient(ItemID.WaterGun)
            .AddTile<TransmutationStationTile>()
            .Register();
    }
}