namespace MerguelsLegacy.Content.Miscellaneous;

public class CrudePortableMagicalBucketItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Miscellaneous.CrudePortableMagicalBucketItem.KEY;

    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.width = 24;
        Item.height = 24;
        
        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 75);
    }
}

public class PortableMagicalBucketItem : ModItem
{
    /// <inheritdoc/> 
    public override string Texture => Assets.Images.Content.Miscellaneous.PortableMagicalBucketItem.KEY;

    /// <inheritdoc/> 
    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.width = 24;
        Item.height = 22;

        Item.rare = ItemRarityID.Blue;

        Item.value = Item.sellPrice(silver: 75);
    }

    /// <inheritdoc/> 
    public override void UpdateInventory(Player player)
    {
        base.UpdateInventory(player);

        player.GetModPlayer<PortableMagicalBucketPlayer>().Enabled = true;
    }
    
    /// <inheritdoc/> 
    public override void AddRecipes()
    {
        base.AddRecipes();

        CreateRecipe()
            .AddCondition(Condition.NearWater)
            .AddCondition(Condition.NearLava)
            .AddCondition(Condition.NearHoney)
            .AddCondition(Condition.NearShimmer)
            .Register();
    }
}

public class PortableMagicalBucketPlayer : ModPlayer
{
    /// <summary>
    ///     Gets or sets a value indicating whether the player has the effects of the Portable Magical Bucket.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the player has the effects of the Portable Magical Bucket; otherwise, <see langword="false"/>.
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
    public override void PostUpdateMiscEffects()
    {
        base.PostUpdateMiscEffects();

        if (!Enabled && !Player.HasItemInInventoryOrOpenVoidBag(ModContent.ItemType<PortableMagicalBucketItem>()))
        {
            return;
        }
        
        Player.adjWater = true;
        Player.adjLava = true;
        Player.adjHoney = true;
        Player.adjShimmer = true;
    }
}