using MerguelsLegacy.Common.Items;
using Terraria.GameContent.Drawing;

namespace MerguelsLegacy.Content.Potions;

public class ResurrectionPotionItem : ModItem
{
    /// <summary>
    ///     The colors of the particles that are emitted when the potion is consumed.
    /// </summary>
    public static readonly Color[] Colors = 
    [
        new Color(28, 216, 94),
        new Color(141, 171, 72),
        new Color(246, 203, 52)
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

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 2);
    }

    public override bool CanUseItem(Player player)
    {
        return player.lastDeathPostion != Vector2.Zero;
    }

    public override bool? UseItem(Player player)
    {
        ParticleOrchestrator.BroadcastOrRequestParticleSpawn(ParticleOrchestraType.TerraBlade, new ParticleOrchestraSettings()
        {
            IndexOfPlayerWhoInvokedThis = (byte)player.whoAmI,
            PositionInWorld = player.Center
        });

        player.Teleport(player.lastDeathPostion - player.Size / 2f, TeleportationStyleID.DebugTeleport);
        
        ParticleOrchestrator.BroadcastOrRequestParticleSpawn(ParticleOrchestraType.TerraBlade, new ParticleOrchestraSettings()
        {
            IndexOfPlayerWhoInvokedThis = (byte)player.whoAmI,
            PositionInWorld = player.lastDeathPostion
        });

        return true;
    }

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