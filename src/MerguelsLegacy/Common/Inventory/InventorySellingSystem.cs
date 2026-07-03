using System.Text;
using MerguelsLegacy.Utilities;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.UI;

namespace MerguelsLegacy.Common.Inventory;

/// <summary>
///     Handles the temporary item used for selling items in the inventory.
/// </summary>
public sealed class InventorySellingPlayer : ModPlayer
{
    /// <summary>
    ///     Gets the item currently placed in the selling slot.
    /// </summary>
    /// <remarks>
    ///     This slot does not persist an actual inventory item, so it is not saved or loaded.
    /// </remarks>
    public Item Item = null!;

    public override void Initialize()
    {
        base.Initialize();
        
        Item = new Item();
        Item.SetDefaults();
    }
}

/// <summary>
///     Handles implementing a custom inventory slot that allows players to sell items.
/// </summary>
/// <remarks>
///     This system hooks into the inventory rendering routine through
///     <see cref="On_Main.DrawInventory" /> to render a custom item slot, and handle interactions
///     through <see cref="ItemSlot" />.
/// </remarks>
[Autoload(Side = ModSide.Client)]
public sealed class InventorySellingSystem : ModSystem
{
    /// <summary>
    ///     The scale used when rendering the custom slot, matching vanilla inventory slot scaling.
    /// </summary>
    private const float INVENTORY_SCALE = 0.85f;

    /// <summary>
    ///     Gets the texture for the sell icon displayed on the inventory selling item slot.
    /// </summary>
    public static Asset<Texture2D> Icon { get; private set; } = null!;

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Icon = Mod.Assets.Request<Texture2D>("Assets/Textures/UI/SellIcon");
    }

    public override void Load()
    {
        base.Load();

        On_Main.DrawInventory += Main_DrawInventory_Hook;
    }

    private static void Main_DrawInventory_Hook(On_Main.orig_DrawInventory orig, Main self)
    {
        orig(self);

        var scale = Main.inventoryScale;

        Main.inventoryScale = INVENTORY_SCALE;

        var player = Main.LocalPlayer;
        var modPlayer = player.GetModPlayer<InventorySellingPlayer>();

        var position = new Vector2(470f, 304f) * Main.inventoryScale;

        var backTexture = TextureAssets.InventoryBack.Value;

        var collisionEndX = position.X + backTexture.Width * Main.inventoryScale;
        var collisionEndY = position.Y + backTexture.Height * Main.inventoryScale;

        var hovers = Main.mouseX >= position.X && Main.mouseX <= collisionEndX && Main.mouseY >= position.Y && Main.mouseY <= collisionEndY;

        if (hovers && !PlayerInput.IgnoreMouseInterface)
        {
            if (!Main.mouseItem.IsAir)
            {
                var value = CoinUtilities.GetSellingPrice(Main.mouseItem.value * Main.mouseItem.stack);

                var copper = CoinUtilities.GetCopperCoins(value);
                var silver = CoinUtilities.GetSilverCoins(value);
                var gold = CoinUtilities.GetGoldCoins(value);
                var platinum = CoinUtilities.GetPlatinumCoins(value);

                var builder = new StringBuilder();

                if (platinum > 0)
                {
                    builder.Append($"[i:{ItemID.PlatinumCoin}] {platinum}");
                    builder.Append(' ');
                }

                if (gold > 0)
                {
                    builder.Append($"[i:{ItemID.GoldCoin}] {gold}");
                    builder.Append(' ');
                }

                if (silver > 0)
                {
                    builder.Append($"[i:{ItemID.SilverCoin}] {silver}");
                    builder.Append(' ');
                    
                }

                if (copper > 0)
                {
                    builder.Append($"[i:{ItemID.CopperCoin}] {copper}");
                    builder.Append(' ');
                }

                var text = builder.ToString();

                Main.instance.MouseText(text);
            }
            
            player.mouseInterface = true;

            ItemSlot.LeftClick(ref modPlayer.Item, ItemSlot.Context.ShopItem);

            if (Main.mouseLeftRelease && Main.mouseLeft)
            {
                Recipe.FindRecipes();
            }

            ItemSlot.MouseHover(ref modPlayer.Item, ItemSlot.Context.ShopItem);
        }

        ItemSlot.Draw(Main.spriteBatch, ref modPlayer.Item, ItemSlot.Context.ShopItem, position);

        var texture = Icon.Value;
        var color = Color.White * 0.5f;

        Main.spriteBatch.Draw(texture, position + texture.Size() / 4f, null, color, 0f, default, Main.inventoryScale, SpriteEffects.None, 0f);

        Main.inventoryScale = scale;
    }
}