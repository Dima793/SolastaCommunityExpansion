﻿using System.Diagnostics.CodeAnalysis;
using HarmonyLib;

namespace SolastaCommunityExpansion.Patches.BugFix;

[HarmonyPatch(typeof(MetamagicSelectionPanel), "Unbind")]
[SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "Patch")]
internal static class MetamagicSelectionPanel_Unbind
{
    internal static void Prefix(MetamagicSelectionPanel __instance)
    {
        //
        // BUGFIX: leaked metamagic panel
        //

        Gui.ReleaseChildrenToPool(__instance.metamagicOptionsTable.transform);
    }
}
