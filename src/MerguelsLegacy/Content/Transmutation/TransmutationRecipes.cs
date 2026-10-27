using MerguelsLegacy.Common.Configuration;

namespace MerguelsLegacy.Content.Transmutation;

public sealed class BarTransmutationSystem : ModSystem
{
    /// <inheritdoc/> 
    public override bool IsLoadingEnabled(Mod mod) => ServerSideConfiguration.Instance.EnableTransmutationRecipes;
    
    /// <inheritdoc/> 
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();
        
        TransmutationUtilities.Exchange(ItemID.CopperBar, ItemID.TinBar);
        TransmutationUtilities.Exchange(ItemID.IronBar, ItemID.LeadBar);
        TransmutationUtilities.Exchange(ItemID.SilverBar, ItemID.TungstenBar);
        TransmutationUtilities.Exchange(ItemID.GoldBar, ItemID.PlatinumBar);
        TransmutationUtilities.Exchange(ItemID.DemoniteBar, ItemID.CrimtaneBar);
        TransmutationUtilities.Exchange(ItemID.CobaltBar, ItemID.PalladiumBar);
        TransmutationUtilities.Exchange(ItemID.MythrilBar, ItemID.OrichalcumBar);
        TransmutationUtilities.Exchange(ItemID.AdamantiteBar, ItemID.TitaniumBar);
    }
}

public sealed class OreTransmutationSystem : ModSystem
{
    /// <inheritdoc/> 
    public override bool IsLoadingEnabled(Mod mod) => ServerSideConfiguration.Instance.EnableTransmutationRecipes;

    /// <inheritdoc/> 
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();
        
        TransmutationUtilities.Exchange(ItemID.CopperOre, ItemID.TinOre);
        TransmutationUtilities.Exchange(ItemID.IronOre, ItemID.LeadOre);
        TransmutationUtilities.Exchange(ItemID.SilverOre, ItemID.TungstenOre);
        TransmutationUtilities.Exchange(ItemID.GoldOre, ItemID.PlatinumOre);
        TransmutationUtilities.Exchange(ItemID.DemoniteOre, ItemID.CrimtaneOre);
        TransmutationUtilities.Exchange(ItemID.CobaltOre, ItemID.PalladiumOre);
        TransmutationUtilities.Exchange(ItemID.MythrilOre, ItemID.OrichalcumOre);
        TransmutationUtilities.Exchange(ItemID.AdamantiteOre, ItemID.TitaniumOre);
    }
}

public sealed class AmmoTransmutationSystem : ModSystem
{
    /// <inheritdoc/> 
    public override bool IsLoadingEnabled(Mod mod) => ServerSideConfiguration.Instance.EnableTransmutationRecipes;

    /// <inheritdoc/> 
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();
        
        TransmutationUtilities.Exchange(ItemID.SilverBullet, ItemID.TungstenBullet);
    }
}

public sealed class EvilTransmutationSystem : ModSystem
{
    /// <inheritdoc/> 
    public override bool IsLoadingEnabled(Mod mod) => ServerSideConfiguration.Instance.EnableTransmutationRecipes;

    /// <inheritdoc/> 
    public override void PostAddRecipes()
    {
        base.PostAddRecipes();
        
        TransmutationUtilities.Exchange(ItemID.CursedFlame, ItemID.Ichor);
        TransmutationUtilities.Exchange(ItemID.TissueSample, ItemID.ShadowScale);
        TransmutationUtilities.Exchange(ItemID.Vertebrae, ItemID.RottenChunk);
        TransmutationUtilities.Exchange(ItemID.BoneRattle, ItemID.EatersBone);
        TransmutationUtilities.Exchange(ItemID.CrimsonSeeds, ItemID.CorruptSeeds);
        TransmutationUtilities.Exchange(ItemID.CrimsonKey, ItemID.CorruptionKey);
        TransmutationUtilities.Exchange(ItemID.CrimstoneBlock, ItemID.EbonstoneBlock);
        TransmutationUtilities.Exchange(ItemID.ViciousMushroom, ItemID.VileMushroom);
        TransmutationUtilities.Exchange(ItemID.Ebonwood, ItemID.Shadewood);
        TransmutationUtilities.Exchange(ItemID.WormScarf, ItemID.BrainOfConfusion);
        TransmutationUtilities.Exchange(ItemID.Musket, ItemID.TheUndertaker);
        TransmutationUtilities.Exchange(ItemID.ShadowOrb, ItemID.CrimsonHeart);
        TransmutationUtilities.Exchange(ItemID.Vilethorn, ItemID.CrimsonRod);
        TransmutationUtilities.Exchange(ItemID.BallOHurt, ItemID.TheRottedFork);
        TransmutationUtilities.Exchange(ItemID.BandofStarpower, ItemID.PanicNecklace);
        TransmutationUtilities.Exchange(ItemID.DartPistol, ItemID.DartRifle);
        TransmutationUtilities.Exchange(ItemID.WormHook, ItemID.TendonHook);
        TransmutationUtilities.Exchange(ItemID.ChainGuillotines, ItemID.FetidBaghnakhs);
        TransmutationUtilities.Exchange(ItemID.ClingerStaff, ItemID.SoulDrain);
        TransmutationUtilities.Exchange(ItemID.PutridScent, ItemID.FleshKnuckles);
    }
}