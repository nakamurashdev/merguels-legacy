using MerguelsLegacy.Common.Configuration;
using MonoMod.Cil;

namespace MerguelsLegacy.Content.World.Town;

public sealed class SpawnHooks : ILoadable
{
    /// <inheritdoc/> 
    void ILoadable.Load(Mod mod) => IL_Main.UpdateTime += UpdateTime_Edit;

    /// <inheritdoc/> 
    void ILoadable.Unload() => IL_Main.UpdateTime -= UpdateTime_Edit;
    
    private static void UpdateTime_Edit(ILContext il)
    {
        var c = new ILCursor(il);

        c.GotoNext(MoveType.After, static i => i.MatchCallOrCallvirt<Main>(nameof(Main.HandleMeteorFall)));

        c.EmitDelegate(Update);
    }

    private static void Update()
    {
        if (!ServerSideConfiguration.Instance.EnableNightTownNPCs)
        {
            return;
        }

        Main.UpdateTime_SpawnTownNPCs();
    }
}