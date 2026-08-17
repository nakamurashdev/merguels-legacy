using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MerguelsLegacy.Common.Configuration;

/// <summary>
///     The server-side <see cref="ModConfig" /> implementation of Merguel's Legacy.
/// </summary>
public sealed class ServerSideConfiguration : ModConfig
{
    /// <summary>
    ///     Gets the singleton instance of <see cref="ServerSideConfiguration" />. Shorthand for
    ///     <c>ModContent.GetInstance&lt;ServerSideConfiguration&gt;()</c>.
    /// </summary>
    public static ServerSideConfiguration Instance => ModContent.GetInstance<ServerSideConfiguration>();

    public override ConfigScope Mode { get; } = ConfigScope.ServerSide;

    /// <summary>
    ///     Gets or sets a value indicating whether players can use potions from the Safe through the Quick
    ///     Buff keybind.
    /// </summary>
    [Header("Inventory")]
    [DefaultValue(true)]
    public bool EnableSafeQuickBuff { get; set; } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether Strange Plants can be found in the world before
    ///     Hardmode.
    /// </summary>
    [Header("World")]
    [DefaultValue(true)]
    public bool EnablePreHardmodeStrangePlants { get; set; } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether the Rolling Cactus is enabled.
    /// </summary>
    [DefaultValue(true)]
    public bool EnableRollingCactus { get; set; } = true;
}