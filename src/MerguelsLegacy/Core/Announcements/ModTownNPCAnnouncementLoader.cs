using System.Collections.Generic;
using MonoMod.Cil;

namespace MerguelsLegacy.Core.Announcements;

public sealed class ModTownNPCAnnouncementLoader : ModSystem
{
    public static IEnumerable<ModTownNPCAnnouncement> Announcements { get; } = ModContent.GetContent<ModTownNPCAnnouncement>();

    public override void Load()
    {
        base.Load();

        IL_WorldGen.SpawnTownNPC += WorldGen_SpawnTownNPC_Edit;
    }

    private static void WorldGen_SpawnTownNPC_Edit(ILContext context)
    {
        try
        {
            var cursor = new ILCursor(context);

            if (!cursor.TryGotoNext(static i => i.MatchLdstr("Announcement.HasArrived")))
            {
                throw new InvalidOperationException($"Failed to match the first occurrence of the announcement text in {nameof(WorldGen)}::{nameof(WorldGen.SpawnTownNPC)}");
            }

            cursor.Index++;

            cursor.EmitLdloc(11);

            cursor.EmitDelegate(GetLocalizationKey);

            if (!cursor.TryGotoNext(static i => i.MatchLdstr("Announcement.HasArrived")))
            {
                throw new InvalidOperationException($"Failed to match the second occurrence of the announcement text in {nameof(WorldGen)}::{nameof(WorldGen.SpawnTownNPC)}");
            }

            cursor.Index++;

            cursor.EmitLdloc(11);

            cursor.EmitDelegate(GetLocalizationKey);
        }
        catch (Exception)
        {
            MonoModHooks.DumpIL(MerguelsLegacy.Instance, context);
        }
    }

    private static string GetLocalizationKey(string value, int index)
    {
        var npc = Main.npc[index];

        foreach (var announcement in Announcements)
        {
            if (!announcement.MeetsConditions(npc))
            {
                continue;
            }

            return announcement.Text.Key;
        }

        return value;
    }
}