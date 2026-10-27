using MerguelsLegacy.Common.Configuration;

namespace MerguelsLegacy.Common.Items;

public sealed class ReuseGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override void SetDefaults(Item entity)
    {
        base.SetDefaults(entity);

        entity.autoReuse |= ServerSideConfiguration.Instance.ItemAutoReuse;
    }
}