using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader.UI;
using Terraria.UI;

namespace MerguelsLegacy.Common.Inventory;

public sealed class UISellSlot : UIElement
{
    /// <summary>
    ///     The scale of the sell slot.
    /// </summary>
    public readonly float Scale;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="UISellSlot"/> class.
    /// </summary>
    /// <param name="scale">
    ///     The scale of the sell slot.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="scale"/> is negative or zero.
    /// </exception>
    public UISellSlot(float scale)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(scale);
        
        Scale = scale;
    }
    
    /// <inheritdoc/>
    public override void OnInitialize()
    {
        base.OnInitialize();

        const float opacity = 0.75f;

        var backgroundTexture = TextureAssets.InventoryBack;

        backgroundTexture.Wait();
        
        Width.Set(backgroundTexture.Width(), 0f);
        Height.Set(backgroundTexture.Height(), 0f);

        var backgroundImage = new UIImage(backgroundTexture)
        {
            HAlign = 0.5f,
            VAlign = 0.5f,
            ImageScale = Scale,
            Color = Color.White * opacity
        };
        
        Append(backgroundImage);

        var iconTexture = Assets.Images.Common.Inventory.Selling.Icon.Asset;

        iconTexture.Wait();
        
        var iconImage = new UIImage(iconTexture)
        {
            HAlign = 0.5f,
            VAlign = 0.5f,
            ImageScale = Scale,
            Color = Color.White * opacity
        };
        
        Append(iconImage);
    }

    /// <inheritdoc/>
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        var player = Main.LocalPlayer;

        player.mouseInterface |= IsMouseHovering;
    }

    /// <inheritdoc/>
    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        
        if (!IsMouseHovering)
        {
            return;
        }
        
        var tooltip = UISellSlotUtilities.Format(Main.mouseItem);
        var hovering = !string.IsNullOrEmpty(tooltip) && !Main.mouseItem.IsAir;
        
        if (hovering)
        {
            UICommon.TooltipMouseText(tooltip);
        }
        
        var item = new Item(ItemID.None);
        
        ItemSlot.LeftClick(ref item, ItemSlot.Context.ShopItem);
                                                                          
        if (Main.mouseLeftRelease && Main.mouseLeft)
        {
            Recipe.FindRecipes();
        }

        ItemSlot.MouseHover(ref item, ItemSlot.Context.ShopItem);
    }
}