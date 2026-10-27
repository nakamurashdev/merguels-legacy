using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria.UI;

namespace MerguelsLegacy.Common.Inventory;

public sealed class UIInventorySellSlot : UIState
{
    /// <summary>
    ///     Gets a value indicating whether the inventory sell slot is visible.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if the inventory sell slot is visible; otherwise, <see langword="false"/>.
    /// </value>
    public static bool Visible => Main.playerInventory && Main.LocalPlayer.chest == -1;
    
    /// <inheritdoc/>
    public override void OnInitialize()
    {
        base.OnInitialize();

        const float scale = 0.85f;

        const float x = 466f;
        const float y = 300f;

        var slot = new UISellSlot(scale)
        {
            Left = StyleDimension.FromPixels(x * scale),
            Top = StyleDimension.FromPixels(y * scale)
        };
        
        Append(slot);
    }

    /// <inheritdoc/>
    public override void Update(GameTime gameTime)
    {
        if (!Visible)
        {
            return;
        }
        
        base.Update(gameTime);
    }

    /// <inheritdoc/>
    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!Visible)
        {
            return;
        }
        
        base.Draw(spriteBatch);
    }
}

[Autoload(Side = ModSide.Client)]
public sealed class UIInventorySellSlotSystem : ModSystem
{
    /// <summary>
    ///     
    /// </summary>
    public const string INSERTION_LAYER_NAME = "Vanilla: Inventory";

    /// <summary>
    ///     
    /// </summary>
    public const int INSERTION_LAYER_OFFSET = 1;
    
    /// <summary>
    ///     
    /// </summary>
    public const string INTERFACE_LAYER_NAME = "Merguels Legacy: Inventory Selling";

    private static UserInterface _userInterface = null!;
    
    private static GameTime _gameTime = null!;

    /// <inheritdoc/>
    public override void Load()
    {
        base.Load();

        _userInterface = new UserInterface();
        _userInterface.SetState(new UIInventorySellSlot());
    }

    /// <inheritdoc/>
    public override void Unload()
    {
        base.Unload();
        
        _userInterface.SetState(null);
    }

    /// <inheritdoc/>
    public override void UpdateUI(GameTime gameTime)
    {
        base.UpdateUI(gameTime);
        
        _gameTime = gameTime;
        
        _userInterface.Update(gameTime);
    }
    
    /// <inheritdoc/>
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        base.ModifyInterfaceLayers(layers);

        var index = layers.FindIndex(static layer => layer.Name == INSERTION_LAYER_NAME);
        
        if (index == -1)
        {
            return;
        }
        
        layers.Insert(index + INSERTION_LAYER_OFFSET, new LegacyGameInterfaceLayer(INTERFACE_LAYER_NAME, Draw, InterfaceScaleType.UI));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool Draw()
    {
        _userInterface.Draw(Main.spriteBatch, _gameTime);
            
        return true;
    }
}