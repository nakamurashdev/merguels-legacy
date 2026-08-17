using System.Collections.Generic;

namespace MerguelsLegacy.Utilities.Extensions;

public static class ChestExtensions
{
    public static IEnumerable<(Item Item, int Index)> Enumerate(this Chest chest)
    {
        for (var i = 0; i < Chest.maxItems; i++)
        {
            var item = chest.item[i];

            if (item.IsAir)
            {
                continue;
            }

            yield return (item, i);
        }
    }
}