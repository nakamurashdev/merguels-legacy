using Terraria.Localization;

namespace MerguelsLegacy.Core.Announcements;

public abstract class ModTownNPCAnnouncement : ModType, ILocalizedModType
{
    public string LocalizationCategory { get; } = "Announcements";

    /// <summary>
    ///     The translations for the text of the announcement.
    /// </summary>
    public virtual LocalizedText Text => this.GetLocalization(nameof(Text), static () => string.Empty);

    /// <summary>
    ///     Gets whether the announcement meets the conditions to be displayed.
    /// </summary>
    /// <param name="npc">The town <see cref="NPC" /> being evaluated.</param>
    /// <returns>
    ///     <see langword="true" /> if the announcement meets the conditions to be displayed;
    ///     otherwise, <see langword="false" />.
    /// </returns>
    public abstract bool MeetsConditions(NPC npc);

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        _ = Text;
    }

    protected sealed override void Register() => ModTypeLookup<ModTownNPCAnnouncement>.Register(this);
}