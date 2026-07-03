namespace MerguelsLegacy.Utilities;

public static class CoinUtilities
{
    public const int COPPER_COINS_PER_SILVER_COIN = 100;
    
    public const int COPPER_COINS_PER_GOLD_COIN = COPPER_COINS_PER_SILVER_COIN * 100;
    
    public const int COPPER_COINS_PER_PLATINUM_COIN = COPPER_COINS_PER_GOLD_COIN * 100;
    
    public static int GetPlatinumCoins(int value)
    {
        return value / COPPER_COINS_PER_PLATINUM_COIN;
    }
    
    public static int GetGoldCoins(int value)
    {
        return (value % COPPER_COINS_PER_PLATINUM_COIN) / COPPER_COINS_PER_GOLD_COIN;
    }
    
    public static int GetSilverCoins(int value)
    {
        return (value % COPPER_COINS_PER_GOLD_COIN) / COPPER_COINS_PER_SILVER_COIN;
    }
    
    public static int GetCopperCoins(int value)
    {
        return value % COPPER_COINS_PER_SILVER_COIN;
    }
    
    public static int GetSellingPrice(int value)
    {
        return value / 5;
    }
}