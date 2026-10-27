using MerguelsLegacy.Common.Configuration;

namespace MerguelsLegacy.Common.Items;

public sealed class StackGlobalItem : GlobalItem
{
    /// <inheritdoc/>
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => lateInstantiation && entity.maxStack > 1;

    /// <inheritdoc/>
    public override void SetDefaults(Item entity)
    {
        base.SetDefaults(entity);

        entity.maxStack = Math.Min(entity.maxStack, ServerSideConfiguration.Instance.ItemMaxStack);
    }
}