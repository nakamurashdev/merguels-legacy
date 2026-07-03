using Terraria.ModLoader.Config;

namespace MerguelsLegacy.Common.Configuration;

/// <summary>
///     The client-side <see cref="ModConfig" /> implementation of Merguel's Legacy.
/// </summary>
public sealed class ClientSideConfiguration : ModConfig
{
    /// <summary>
    ///     Gets the singleton instance of <see cref="ClientSideConfiguration" />. Shorthand for
    ///     <c>ModContent.GetInstance&lt;ClientSideConfiguration&gt;()</c>.
    /// </summary>
    public override ConfigScope Mode { get; } = ConfigScope.ClientSide;
}