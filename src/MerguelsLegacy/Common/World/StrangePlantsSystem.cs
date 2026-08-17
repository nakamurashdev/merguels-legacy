using MerguelsLegacy.Common.Configuration;
using MonoMod.Cil;

namespace MerguelsLegacy.Common.World;

public sealed class StrangePlantsSystem : ModSystem
{
    public override void Load()
    {
        base.Load();

        IL_WorldGen.UpdateWorld_OvergroundTile += EditSurfacePlantSpawns;
        IL_WorldGen.UpdateWorld_UndergroundTile += EditUndergroundPlantSpawns;
    }

    private static void EditSurfacePlantSpawns(ILContext context)
    {
        try
        {
            var cursor = new ILCursor(context);

            if (!cursor.TryGotoNext(static i => i.MatchLdsfld<Main>(nameof(Main.hardMode))))
            {
#if DEBUG
                throw new Exception();
#else
                return;
#endif
            }

            cursor.Index++;

            cursor.EmitDelegate(static (bool original) => ServerSideConfiguration.Instance.EnablePreHardmodeStrangePlants ? true : original);
        }
        catch (Exception)
        {
            MonoModHooks.DumpIL(MerguelsLegacy.Instance, context);
        }
    }

    private void EditUndergroundPlantSpawns(ILContext context)
    {
        try
        {
            var cursor = new ILCursor(context);

            if (!cursor.TryGotoNext(static i => i.MatchLdsfld<Main>(nameof(Main.hardMode))))
            {
#if DEBUG
                throw new Exception();
#else
                return;
#endif
            }

            cursor.Index++;

            cursor.EmitDelegate(static (bool original) => ServerSideConfiguration.Instance.EnablePreHardmodeStrangePlants ? true : original);
        }
        catch (Exception)
        {
            MonoModHooks.DumpIL(MerguelsLegacy.Instance, context);
        }
    }
}