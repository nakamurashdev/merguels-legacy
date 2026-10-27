using MerguelsLegacy.Common.Configuration;
using MonoMod.Cil;

namespace MerguelsLegacy.Content.World.Generation;

public sealed class StrangePlantHooks : ILoadable
{
    /// <inheritdoc/> 
    void ILoadable.Load(Mod mod)
    {
        IL_WorldGen.UpdateWorld_OvergroundTile += UpdateWorld_OvergroundTile_Edit;
        IL_WorldGen.UpdateWorld_UndergroundTile += UpdateWorld_UndergroundTile_Edit;
    }

    /// <inheritdoc/> 
    void ILoadable.Unload()
    {
        IL_WorldGen.UpdateWorld_OvergroundTile -= UpdateWorld_OvergroundTile_Edit;
        IL_WorldGen.UpdateWorld_UndergroundTile -= UpdateWorld_UndergroundTile_Edit;
    }

    private static void UpdateWorld_OvergroundTile_Edit(ILContext il)
    {
        var c = new ILCursor(il);

        if (!c.TryGotoNext(MoveType.After, static i => i.MatchLdsfld<Main>(nameof(Main.hardMode))))
        {
            throw new Exception();
        }

        c.EmitDelegate(static (bool value) => ServerSideConfiguration.Instance.EnableStrangePlants ? true : value);
    }

    private static void UpdateWorld_UndergroundTile_Edit(ILContext il)
    {
        var c = new ILCursor(il);

        if (!c.TryGotoNext(MoveType.After, static i => i.MatchLdsfld<Main>(nameof(Main.hardMode))))
        {
            throw new Exception();
        }

        c.EmitDelegate(static (bool value) => ServerSideConfiguration.Instance.EnableStrangePlants ? true : value);
    }
}