﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using SolastaCommunityExpansion.Classes.Monk;
using SolastaCommunityExpansion.Models;

namespace SolastaCommunityExpansion.Patches.Diagnostic;

[HarmonyPatch(typeof(GuiItemDefinition), "EnumerateTags")]
[SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "Patch")]
internal static class GuiItemDefinition_EnumerateTags
{
    public static void Postfix(GuiItemDefinition __instance)
    {
        var tags = __instance.itemTags;
        var item = __instance.ItemDefinition;

        if (WeaponValidators.IsPolearm(item))
        {
            tags.TryAdd(CustomWeaponsContext.PolearmWeaponTag, TagsDefinitions.Criticity.Normal);
        }

        if (Monk.IsMonkWeapon(null, item))
        {
            tags.TryAdd(Monk.WeaponTag, TagsDefinitions.Criticity.Normal);
        }

        if (DiagnosticsContext.IsCeDefinition(__instance.BaseDefinition))
        {
            tags.TryAdd(CeContentPackContext.CETag, TagsDefinitions.Criticity.Normal);
        }
    }
}
