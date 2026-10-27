using System.Collections.Generic;

namespace MerguelsLegacy.Common.World.Generation;

public readonly struct LiquidCounter()
{
    private readonly Dictionary<int, int> _counts = [];

    public void Scan(int x, int y, int width, int height)
    {
        for (var i = x - width / 2; i < x + width / 2; i++)
        {
            for (var j = y - height / 2; j < y + height / 2; j++)
            {
                var tile = Framing.GetTileSafely(i, j);
                var type = tile.LiquidType;

                if (!_counts.TryGetValue(type, out var count))
                {
                    continue;
                }

                count++;
                
                _counts[type] = count;
            }
        }
    }

    public void Register(int type) => _counts[type] = 0;

    public int Count(int type) => _counts.TryGetValue(type, out var count) ? count : 0;
}