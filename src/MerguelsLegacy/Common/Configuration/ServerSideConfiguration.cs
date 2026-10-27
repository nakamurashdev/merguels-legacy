using System.ComponentModel;
using MerguelsLegacy.Common.World.Sleeping;
using Terraria.ModLoader.Config;

namespace MerguelsLegacy.Common.Configuration;

public sealed class ServerSideConfiguration : ModConfig
{
    public static ServerSideConfiguration Instance => ModContent.GetInstance<ServerSideConfiguration>();

    /// <inheritdoc/>
    public override ConfigScope Mode => ConfigScope.ServerSide;
    
    /// <summary>
    ///     Gets or sets a value indicating whether transmutation recipes are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if transmutation recipes are enabled; otherwise, <see langword="false"/>.
    /// </value>
    [Header("Recipes")]
    [ReloadRequired]
    [DefaultValue(true)]
    public bool EnableTransmutationRecipes
    {
        get; 
        set;
    } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether recipes for vanilla items are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if recipes for vanilla items are enabled; otherwise, <see langword="false"/>.
    /// </value>
    [ReloadRequired]
    [DefaultValue(true)]
    public bool EnableVanillaRecipes
    {
        get; 
        set;
    } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether safe quick-buff is enabled.
    /// </summary>
    /// <value>
    ///    <see langword="true"/> if safe quick-buff is enabled; otherwise, <see langword="false"/>.
    /// </value>
    [Header("Inventory")]
    [DefaultValue(true)]
    public bool EnableSafePotions
    {
        get; 
        set;
    } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether safe chester is enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if safe chester is enabled; otherwise, <see langword="false"/>.
    /// </value>
    [DefaultValue(true)]
    public bool EnableSafeChester
    {
        get; 
        set;
    } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether pre-hardmode strange plants are enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if pre-hardmode strange plants are enabled; otherwise, <see langword="false"/>.
    /// </value>
    [Header("World")]
    [DefaultValue(true)]
    public bool EnableStrangePlants
    {
        get; 
        set;
    } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether town NPCs can spawn at night.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if town NPCs can spawn at night; otherwise, <see langword="false"/>.
    /// </value>
    [DefaultValue(true)]
    public bool EnableNightTownNPCs
    {
        get;
        set;
    } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether rolling cactus is enabled.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if rolling cactus is enabled; otherwise, <see langword="false"/>.
    /// </value>
    [DefaultValue(true)]
    public bool EnableRollingCactus
    {
        get; 
        set;
    } = true;

    /// <summary>
    ///     Gets or sets the maximum stack size for items.
    /// </summary>
    [Header("Items")]
    [Range(1, 9999)]
    [DefaultValue(9999)]
    public int ItemMaxStack
    {
        get; 
        set;
    } = 9999;

    /// <summary>
    ///     Gets or sets a value indicating whether items can be automatically reused.
    /// </summary>
    /// <value>
    ///     <see langword="true"/> if items can be automatically reused; otherwise, <see langword="false"/>.
    /// </value>
    [DefaultValue(true)]
    public bool ItemAutoReuse
    {
        get; 
        set;
    } = true;

    [Header("Sleeping")]
    [DefaultValue(typeof(SleepingMode), "All")]
    public SleepingMode SleepingMode
    {
        get;
        set;
    } = SleepingMode.All;

    [Range(1f, 256f)]
    [DefaultValue(10f)]
    public float SleepingMultiplier
    {
        get; 
        set;
    } = 10f;
}