using Terraria.Localization;

namespace MerguelsLegacy.Content.Miscellaneous;

public sealed class HeartwarmingCampfireSystem : ModSystem
{
    private const string NAME = "Merguels Legacy: Campfires";
    
    private static readonly int[] _items = 
    [
        ItemID.Campfire,
        ItemID.BoneCampfire,
        ItemID.CoralCampfire,
        ItemID.CorruptCampfire,
        ItemID.CrimsonCampfire,
        ItemID.CursedCampfire,
        ItemID.DesertCampfire,
        ItemID.DemonCampfire,
        ItemID.FrozenCampfire,
        ItemID.HallowedCampfire,
        ItemID.IchorCampfire,
        ItemID.JungleCampfire,
        ItemID.MushroomCampfire,
        ItemID.RainbowCampfire,
        ItemID.ShimmerCampfire,
        ItemID.UltraBrightCampfire
    ];

    /// <summary>
    ///     Gets the recipe group of the Heartwarming Campfire's crafting recipe.
    /// </summary>
    public static RecipeGroup Group { get; private set; } = null!;

    /// <inheritdoc/> 
    public override void AddRecipeGroups()
    {
        base.AddRecipeGroups();
        
        Group = new RecipeGroup(static () => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Campfire)}", _items);

        RecipeGroup.RegisterGroup(NAME, Group);
    }
}

public class HeartwarmingCampfire : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Miscellaneous.HeartwarmingCampfireItem.KEY;

    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.width = 26;
        Item.height = 8;

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(gold: 2);
    }

    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddRecipeGroup(HeartwarmingCampfireSystem.Group)
            .AddIngredient(ItemID.GrayBrick, 20)
            .AddIngredient(ItemID.HeartLantern)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}