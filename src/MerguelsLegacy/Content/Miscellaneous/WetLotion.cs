namespace MerguelsLegacy.Content.Miscellaneous;

public class WetLotionItem : ModItem
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Item.rare = ItemRarityID.Blue;
        
        Item.value = Item.sellPrice(silver: 75);
    }

    public override void UpdateInventory(Player player)
    {
        base.UpdateInventory(player);

        player.AddBuff(BuffID.Wet, 2);
    }

    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddIngredient(ItemID.WaterBucket)
            .AddIngredient(ItemID.SlimeGun)
            .Register();
    }
}