using MerguelsLegacy.Common.Configuration;

namespace MerguelsLegacy.Content.Recipes;

public sealed class WorkbenchRecipeSystem : ModSystem
{
    /// <inheritdoc/>
    public override bool IsLoadingEnabled(Mod mod) => ServerSideConfiguration.Instance.EnableVanillaRecipes;

    /// <inheritdoc/>
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();
        
        Recipe.Create(ItemID.GoldenChest)
            .AddIngredient(ItemID.GoldBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.IvyChest)
            .AddIngredient(ItemID.MudstoneBlock, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.WaterChest)
            .AddIngredient(ItemID.CoralstoneBlock, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.WebCoveredChest)
            .AddIngredient(ItemID.SpiderBlock, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.ShadowChest)
            .AddIngredient(ItemID.DemoniteBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ItemID.ShadowChest)
            .AddIngredient(ItemID.CrimtaneBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}

public sealed class AnvilRecipeSystem : ModSystem
{
    /// <inheritdoc/>
    public override bool IsLoadingEnabled(Mod mod) => ServerSideConfiguration.Instance.EnableVanillaRecipes;

    /// <inheritdoc/>
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();

        Recipe.Create(ItemID.BallOHurt)
            .AddIngredient(ItemID.DemoniteBar, 10)
            .AddIngredient(ItemID.ShadowScale, 5)
            .AddTile(TileID.Anvils)
            .Register();

        Recipe.Create(ItemID.Hellforge)
            .AddIngredient(ItemID.Furnace)
            .AddIngredient(ItemID.HellstoneBar, 20)
            .AddTile(TileID.Anvils)
            .Register();
    }
}

public sealed class MythrilAnvilRecipeSystem : ModSystem
{
    /// <inheritdoc/>
    public override bool IsLoadingEnabled(Mod mod) => ServerSideConfiguration.Instance.EnableVanillaRecipes;

    /// <inheritdoc/>
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();

        Recipe.Create(ItemID.Pwnhammer)
            .AddIngredient(ItemID.HallowedBar, 18)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.EnchantedSword)
            .AddIngredient(ItemID.EnchantedBoomerang)
            .AddIngredient(ItemID.GoldBroadsword)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.EnchantedSword)
            .AddIngredient(ItemID.EnchantedBoomerang)
            .AddIngredient(ItemID.PlatinumBroadsword)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.BloodySpine)
            .AddIngredient(ItemID.ViciousPowder, 30)
            .AddIngredient(ItemID.Vertebrae, 15)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.WormFood)
            .AddIngredient(ItemID.VilePowder, 30)
            .AddIngredient(ItemID.RottenChunk, 15)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.DeerThing)
            .AddIngredient(ItemID.FlinxFur, 3)
            .AddIngredient(ItemID.Lens, 5)
            .AddIngredient(ItemID.CrimtaneOre)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.DeerThing)
            .AddIngredient(ItemID.FlinxFur, 3)
            .AddIngredient(ItemID.Lens, 5)
            .AddIngredient(ItemID.DemoniteOre)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.NightsEdge)
            .AddIngredient(ItemID.LightsBane)
            .AddIngredient(ItemID.Muramasa)
            .AddIngredient(ItemID.BladeofGrass)
            .AddIngredient(ItemID.FieryGreatsword)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.NightsEdge)
            .AddIngredient(ItemID.BloodButcherer)
            .AddIngredient(ItemID.Muramasa)
            .AddIngredient(ItemID.BladeofGrass)
            .AddIngredient(ItemID.FieryGreatsword)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.SlimeCrown)
            .AddIngredient(ItemID.Gel, 20)
            .AddIngredient(ItemID.PlatinumCrown)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.SlimeCrown)
            .AddIngredient(ItemID.Gel, 20)
            .AddIngredient(ItemID.GoldCrown)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.SuspiciousLookingEye)
            .AddIngredient(ItemID.Lens, 6)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.VoidLens)
            .AddIngredient(ItemID.Bone, 30)
            .AddIngredient(ItemID.JungleSpores, 15)
            .AddIngredient(ItemID.ShadowScale, 30)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.VoidLens)
            .AddIngredient(ItemID.Bone, 8)
            .AddIngredient(ItemID.JungleSpores, 8)
            .AddIngredient(ItemID.TissueSample, 15)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.VoidVault)
            .AddIngredient(ItemID.Bone, 30)
            .AddIngredient(ItemID.JungleSpores, 15)
            .AddIngredient(ItemID.ShadowScale, 30)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.VoidVault)
            .AddIngredient(ItemID.Bone, 8)
            .AddIngredient(ItemID.JungleSpores, 8)
            .AddIngredient(ItemID.TissueSample, 15)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        Recipe.Create(ItemID.GuideVoodooDoll)
            .AddIngredient(ItemID.RedHat)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}
