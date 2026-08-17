using Terraria.Localization;

namespace MerguelsLegacy;

/// <summary>
///     The <see cref="Mod" /> implementation of Merguel's Legacy.
/// </summary>
public sealed class MerguelsLegacy : Mod
{
    /// <summary>
    ///     Gets the singleton instance of <see cref="MerguelsLegacy" />. Shorthand for
    ///     <c>ModContent.GetInstance&lt;MerguelsLegacy&gt;()</c>.
    /// </summary>
    public static MerguelsLegacy Instance => ModContent.GetInstance<MerguelsLegacy>();
}

/// <summary>
///     Provides <see cref="Mod" /> extension methods.
/// </summary>
public static class ModExtensions
{
    /// <summary>
    ///     Retrieves the text value for a localization key belonging to this piece of content with the
    ///     given <paramref name="suffix" />. The text returned will be for the currently selected
    ///     language.
    /// </summary>
    /// <param name="mod">The mod used as the base for the localization key.</param>
    /// <param name="suffix">The suffix appended to the mod's localization key.</param>
    /// <returns>The localized text corresponding to the constructed key.</returns>
    public static string GetLocalizationValue(this Mod mod, string suffix) => Language.GetTextValue(mod.GetLocalizationKey(suffix));

    /// <summary>
    ///     Retrieves the text value for a localization key belonging to this piece of content with the
    ///     given <paramref name="suffix" />. The text returned will be for the currently selected
    ///     language.
    /// </summary>
    /// <param name="mod">The mod used as the base for the localization key.</param>
    /// <param name="suffix">The suffix appended to the mod's localization key.</param>
    /// <param name="args">Objects used to format the localized text.</param>
    /// <returns>The formatted localized text corresponding to the constructed key.</returns>
    public static string GetLocalizationValue(this Mod mod, string suffix, params object[] args) => Language.GetTextValue(mod.GetLocalizationKey(suffix), args);
}