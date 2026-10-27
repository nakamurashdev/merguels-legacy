using System.Runtime.CompilerServices;
using System.Text;

namespace MerguelsLegacy.Common.Inventory;

public static class UISellSlotUtilities
{
    /// <summary>
    ///     The number of copper coins per silver coin.
    /// </summary>
    public const int COPPER_COINS_PER_SILVER_COIN = 100;

    /// <summary>
    ///     The number of copper coins per gold coin.
    /// </summary>
    public const int COPPER_COINS_PER_GOLD_COIN = COPPER_COINS_PER_SILVER_COIN * 100;

    /// <summary>
    ///     The number of copper coins per platinum coin.
    /// </summary>
    public const int COPPER_COINS_PER_PLATINUM_COIN = COPPER_COINS_PER_GOLD_COIN * 100;
    
    /// <summary>
    ///     Formats the value of an item into a string representation of its constituent coin types.
    /// </summary>
    /// <param name="value">
    ///     The value of the item to format.
    /// </param>
    /// <returns>
    ///     A string representation of the item's value in terms of platinum, gold, silver, and copper coins.
    /// </returns>
    public static string Format(int value)
    {
        Decompose(value, out var platinum, out var gold, out var silver, out var copper);
        
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
        
        return builder.ToString();
    }
    
    /// <summary>
    ///     Formats the value of an item into a string representation of its constituent coin types.
    /// </summary>
    /// <param name="item">
    ///     The item to format.
    /// </param>
    /// <returns>
    ///     A string representation of the item's value in terms of platinum, gold, silver, and copper coins.
    /// </returns>
    public static string Format(Item item) => Format(item.value * item.stack);
    
    /// <summary>
    ///     Decomposes the value of an item into its constituent coin types.
    /// </summary>
    /// <param name="value">
    ///     The value of the item to decompose.
    /// </param>
    /// <param name="platinum">
    ///     The number of platinum coins.
    /// </param>
    /// <param name="gold">
    ///     The number of gold coins.
    /// </param>
    /// <param name="silver">
    ///     The number of silver coins.
    /// </param>
    /// <param name="copper">
    ///     The number of copper coins.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Decompose(int value, out int platinum, out int gold, out int silver, out int copper)
    {
        platinum = Platinum(value);
        gold = Gold(value);
        silver = Silver(value);
        copper = Copper(value);
    }
    
    /// <summary>
    ///     Decomposes the value of an item into its constituent coin types.
    /// </summary>
    /// <param name="item">
    ///     The item to decompose.
    /// </param>
    /// <param name="platinum">
    ///     The number of platinum coins.
    /// </param>
    /// <param name="gold">
    ///     The number of gold coins.
    /// </param>
    /// <param name="silver">
    ///     The number of silver coins.
    /// </param>
    /// <param name="copper">
    ///     The number of copper coins.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Decompose(Item item, out int platinum, out int gold, out int silver, out int copper) => Decompose(item.value * item.stack, out platinum, out gold, out silver, out copper);

    /// <summary>
    ///     Gets the number of platinum coins in the value of an item.
    /// </summary>
    /// <param name="value">
    ///     The value of the item to get the number of platinum coins from.
    /// </param>
    /// <returns>
    ///     The number of platinum coins in the value of the item.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Platinum(int value) => value / COPPER_COINS_PER_PLATINUM_COIN / 5;
    
    /// <summary>
    ///     Gets the number of platinum coins in the value of an item.
    /// </summary>
    /// <param name="item">
    ///     The item to get the number of platinum coins from.
    /// </param>
    /// <returns>
    ///     The number of platinum coins in the value of the item.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Platinum(Item item) => Platinum(item.value * item.stack);

    /// <summary>
    ///     Gets the number of gold coins in the value of an item.
    /// </summary>
    /// <param name="value">
    ///     The value of the item to get the number of gold coins from.
    /// </param>
    /// <returns>
    ///     The number of gold coins in the value of the item.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Gold(int value) => value % COPPER_COINS_PER_PLATINUM_COIN / COPPER_COINS_PER_GOLD_COIN / 5;
    
    /// <summary>
    ///     Gets the number of gold coins in the value of an item.
    /// </summary>
    /// <param name="item">
    ///     The item to get the number of gold coins from.
    /// </param>
    /// <returns>
    ///     The number of gold coins in the value of the item.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Gold(Item item) => Gold(item.value * item.stack);

    /// <summary>
    ///     Gets the number of silver coins in the value of an item.
    /// </summary>
    /// <param name="value">
    ///     The value of the item to get the number of silver coins from.
    /// </param>
    /// <returns>
    ///     The number of silver coins in the value of the item.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Silver(int value) => value % COPPER_COINS_PER_GOLD_COIN / COPPER_COINS_PER_SILVER_COIN / 5;
    
    /// <summary>
    ///     Gets the number of silver coins in the value of an item.
    /// </summary>
    /// <param name="item">
    ///     The item to get the number of silver coins from.
    /// </param>
    /// <returns>
    ///     The number of silver coins in the value of the item.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Silver(Item item) => Silver(item.value * item.stack);

    /// <summary>
    ///     Gets the number of copper coins in the value of an item.
    /// </summary>
    /// <param name="value">
    ///     The value of the item to get the number of copper coins from.
    /// </param>
    /// <returns>
    ///     The number of copper coins in the value of the item.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Copper(int value) => value % COPPER_COINS_PER_SILVER_COIN / 5;
    
    /// <summary>
    ///     Gets the number of copper coins in the value of an item.
    /// </summary>
    /// <param name="item">
    ///     The item to get the number of copper coins from.
    /// </param>
    /// <returns>
    ///     The number of copper coins in the value of the item.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Copper(Item item) => Copper(item.value * item.stack);
}