using System.Collections.Generic;
using MerguelsLegacy.Common.Items;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace MerguelsLegacy.Common.Inventory;

[Autoload(Side = ModSide.Client)]
public sealed class InventorySellingPlayer : ModPlayer
{
    private const string Tag = "InventorySellingPlayerItem";
    
    public Item Item = null!;

    public override void Initialize()
    {
        base.Initialize();

        Item = new Item();
        Item.SetDefaults();
    }

    public override void SaveData(TagCompound tag)
    {
        base.SaveData(tag);

        tag[Tag] = ItemIO.Save(Item);
    }

    public override void LoadData(TagCompound tag)
    {
        base.LoadData(tag);

        Item = ItemIO.Load(tag);
    }
}

public sealed class InventorySellingState : UIState
{
    private const float INVENTORY_SCALE = 0.85f;
    
    public override void Update(GameTime gameTime)
    {
        if (!Main.playerInventory)
        {
            return;
        }
        
        base.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!Main.playerInventory)
        {
            return;
        }
        
        base.Draw(spriteBatch);
        
        var scale = Main.inventoryScale;

        Main.inventoryScale = INVENTORY_SCALE;

        var player = Main.LocalPlayer;
        var sellingPlayer = player.GetModPlayer<InventorySellingPlayer>();

        var position = new Vector2(470f, 304f) * Main.inventoryScale;

        var backTexture = TextureAssets.InventoryBack.Value;

        var collisionEndX = position.X + backTexture.Width * Main.inventoryScale;
        var collisionEndY = position.Y + backTexture.Height * Main.inventoryScale;

        var hovers = Main.mouseX >= position.X && Main.mouseX <= collisionEndX && Main.mouseY >= position.Y && Main.mouseY <= collisionEndY;

        if (hovers && !PlayerInput.IgnoreMouseInterface)
        {
            if (!Main.mouseItem.IsAir)
            {
                var value = ItemCoins.GetSellingPrice(Main.mouseItem.value * Main.mouseItem.stack);
                
                ItemCoins.GetCoins(value, out var platinum, out var gold, out var silver, out var copper);
                ItemCoins.GetFormat(platinum, gold, silver, copper, out var text);
                
                Main.instance.MouseText(text);
            }

            player.mouseInterface = true;

            ItemSlot.LeftClick(ref sellingPlayer.Item, ItemSlot.Context.ShopItem);

            if (Main.mouseLeftRelease && Main.mouseLeft)
            {
                Recipe.FindRecipes();
            }

            ItemSlot.MouseHover(ref sellingPlayer.Item, ItemSlot.Context.ShopItem);
        }

        ItemSlot.Draw(Main.spriteBatch, ref sellingPlayer.Item, ItemSlot.Context.ShopItem, position);
        
        var texture = Assets.Textures.UI.SellIcon.Asset.Value;
        var color = Color.White * 0.5f;

        Main.spriteBatch.Draw(texture, position + texture.Size() / 4f, null, color, 0f, default, Main.inventoryScale, SpriteEffects.None, 0f);

        Main.inventoryScale = scale;
    }
}

[Autoload(Side = ModSide.Client)]
public sealed class InventorySellingSystem : ModSystem
{
    private const string INSERTION_LAYER_NAME = "Vanilla: Inventory";

    private const string INTERFACE_LAYER_NAME = "Merguels Legacy: Inventory Selling";
    
    public static UserInterface? UserInterface { get; private set; }

    public override void Load()
    {
        base.Load();

        UserInterface = new UserInterface();
        UserInterface.SetState(new InventorySellingState());
    }

    public override void Unload()
    {
        base.Unload();
        
        UserInterface?.SetState(null);
        UserInterface = null;
    }

    public override void UpdateUI(GameTime gameTime)
    {
        base.UpdateUI(gameTime);
        
        UserInterface?.Update(gameTime);
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        base.ModifyInterfaceLayers(layers);

        static bool Draw()
        {
            UserInterface?.Draw(Main.spriteBatch, new GameTime());
            
            return true;
        }

        var index = layers.FindIndex(static layer => layer.Name == INSERTION_LAYER_NAME);
        var layer = new LegacyGameInterfaceLayer(INTERFACE_LAYER_NAME, Draw, InterfaceScaleType.UI);
        
        if (index == -1)
        {
            layers.Add(layer);
        }
        else
        {
            layers.Insert(index, layer);
        }
    }
}