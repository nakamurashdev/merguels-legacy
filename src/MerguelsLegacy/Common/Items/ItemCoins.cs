using System.Text;

namespace MerguelsLegacy.Common.Items;

public static class ItemCoins
{
    /// <summary>
    ///     The amount of copper coins per silver coin.
    /// </summary>
    public const int COPPER_COINS_PER_SILVER_COIN = 100;

    /// <summary>
    ///     The amount of copper coins per gold coin.
    /// </summary>
    public const int COPPER_COINS_PER_GOLD_COIN = COPPER_COINS_PER_SILVER_COIN * 100;

    /// <summary>
    ///     The amount of copper coins per platinum coin.
    /// </summary>
    public const int COPPER_COINS_PER_PLATINUM_COIN = COPPER_COINS_PER_GOLD_COIN * 100;

    public static void GetFormat(int platinum, int gold, int silver, int copper, out string text)
    {
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
        
        text = builder.ToString();
    }

    public static void GetCoins(int value, out int platinum, out int gold, out int silver, out int copper)
    {
        platinum = GetPlatinumCoins(value);
        gold = GetGoldCoins(value);
        silver = GetSilverCoins(value);
        copper = GetCopperCoins(value);
    }
    
    /// <summary>
    ///     Gets the amount of platinum coins from a given value in copper coins.
    /// </summary>
    /// <param name="value">
    ///     The value in copper coins.
    /// </param>
    /// <returns>
    ///     The amount of platinum coins from the given value in copper coins.
    /// </returns>
    public static int GetPlatinumCoins(int value) => value / COPPER_COINS_PER_PLATINUM_COIN;

    /// <summary>
    ///     Gets the amount of gold coins from a given value in copper coins.
    /// </summary>
    /// <param name="value">
    ///     The value in copper coins.
    /// </param>
    /// <returns>
    ///     The amount of gold coins from the given value in copper coins.
    /// </returns>
    public static int GetGoldCoins(int value) => value % COPPER_COINS_PER_PLATINUM_COIN / COPPER_COINS_PER_GOLD_COIN;

    /// <summary>
    ///     Gets the amount of silver coins from a given value in copper coins.
    /// </summary>
    /// <param name="value">
    ///     The value in copper coins.
    /// </param>
    /// <returns>
    ///     The amount of silver coins from the given value in copper coins.
    /// </returns>
    public static int GetSilverCoins(int value) => value % COPPER_COINS_PER_GOLD_COIN / COPPER_COINS_PER_SILVER_COIN;

    /// <summary>
    ///     Gets the amount of copper coins from a given value in copper coins.
    /// </summary>
    /// <param name="value">
    ///     The value in copper coins.
    /// </param>
    /// <returns>
    ///     The amount of copper coins from the given value in copper coins.
    /// </returns>
    public static int GetCopperCoins(int value) => value % COPPER_COINS_PER_SILVER_COIN;
    
    /// <summary>
    ///     Gets the selling price in copper coins from a given value in copper coins.
    /// </summary>
    /// <param name="value">
    ///     The value in copper coins.
    /// </param>
    /// <returns>
    ///     The selling price in copper coins from the given value in copper coins.
    /// </returns>
    public static int GetSellingPrice(int value) => value / 5;
}