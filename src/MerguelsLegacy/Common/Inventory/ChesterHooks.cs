using MerguelsLegacy.Common.Configuration;
using MonoMod.Cil;

namespace MerguelsLegacy.Common.Inventory;

public sealed class ChesterHooks : ILoadable
{
    /// <inheritdoc/> 
    void ILoadable.Load(Mod mod)
    {
        IL_Projectile.TryGetContainerIndex += TryGetContainerIndex_Edit;
        IL_Main.TryInteractingWithMoneyTrough += TryInteractingWithMoneyTrough_Edit;
    }

    /// <inheritdoc/> 
    void ILoadable.Unload()
    {
        IL_Projectile.TryGetContainerIndex -= TryGetContainerIndex_Edit;
        IL_Main.TryInteractingWithMoneyTrough -= TryInteractingWithMoneyTrough_Edit;
    }
    
    private static void TryGetContainerIndex_Edit(ILContext il)
    {
        var c = new ILCursor(il);

        const int piggyIndex = -2;
        const int safeIndex = -3;
        
        c.GotoNext(MoveType.After, static i => i.MatchLdarg1(), static i => i.MatchLdcI4(piggyIndex));
        
        c.EmitDelegate(static (int _) => ServerSideConfiguration.Instance.EnableSafeChester ? safeIndex : piggyIndex);
    }
    
    private static void TryInteractingWithMoneyTrough_Edit(ILContext il)
    {
        var c = new ILCursor(il);

        const int piggyIndex = -2;
        const int safeIndex = -3;

        c.GotoNext(MoveType.After, static i => i.MatchLdloc1(), static i => i.MatchLdcI4(piggyIndex));

        c.EmitDelegate(static (int _) => ServerSideConfiguration.Instance.EnableSafeChester ? safeIndex : piggyIndex);
    }
}