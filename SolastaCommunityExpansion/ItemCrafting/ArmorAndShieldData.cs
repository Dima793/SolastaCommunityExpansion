﻿using System;
using System.Collections.Generic;
using SolastaCommunityExpansion.Api;
using static SolastaCommunityExpansion.ItemCrafting.ItemCollection;

namespace SolastaCommunityExpansion.ItemCrafting;

internal static class ArmorAndShieldData
{
    private static ItemCollection items;

    internal static ItemCollection Items
    {
        get => items ??= new ItemCollection
        {
            BaseGuid = new Guid("16757d1b-518f-4669-af43-1ddf5d23c223"),
            BaseWeapons =
                new List<ItemDefinition>
                {
                    DatabaseHelper.ItemDefinitions.Shield_Wooden,
                    DatabaseHelper.ItemDefinitions.Shield,
                    DatabaseHelper.ItemDefinitions.HideArmor,
                    DatabaseHelper.ItemDefinitions.LeatherDruid,
                    DatabaseHelper.ItemDefinitions.StuddedLeather
                },
            PossiblePrimedItemsToReplace = new List<ItemDefinition>
            {
                DatabaseHelper.ItemDefinitions.Primed_HalfPlate,
                DatabaseHelper.ItemDefinitions.Primed_Leather_Armor,
                DatabaseHelper.ItemDefinitions.Primed_LeatherDruid,
                DatabaseHelper.ItemDefinitions.Primed_ScaleMail,
                DatabaseHelper.ItemDefinitions.Primed_Breastplate
            },
            MagicToCopy = new List<MagicItemDataHolder>
            {
                new("Sturdiness", DatabaseHelper.ItemDefinitions.Enchanted_HalfPlateOfSturdiness,
                    DatabaseHelper.RecipeDefinitions.Recipe_Enchantment_HalfplateOfSturdiness),
                new("Robustness", DatabaseHelper.ItemDefinitions.Enchanted_HalfPlateOfRobustness,
                    DatabaseHelper.RecipeDefinitions.Recipe_Enchantment_HalfplateOfRobustness),
                new("Survival", DatabaseHelper.ItemDefinitions.Enchanted_LeatherArmorOfSurvival,
                    DatabaseHelper.RecipeDefinitions.Recipe_Enchantment_LeatherArmorOfSurvival),
                new("FlameDancing", DatabaseHelper.ItemDefinitions.Enchanted_LeatherArmorOfFlameDancing,
                    DatabaseHelper.RecipeDefinitions.Recipe_Enchantment_LeatherArmorOfFlameDancing),
                new("FrostWalking", DatabaseHelper.ItemDefinitions.Enchanted_ScaleMailOfIceDancing,
                    DatabaseHelper.RecipeDefinitions.Recipe_Enchantment_ScaleMailOfIceDancing),
                new("Deflection", DatabaseHelper.ItemDefinitions.Enchanted_BreastplateOfDeflection,
                    DatabaseHelper.RecipeDefinitions.Recipe_Enchantment_BreastplateOfDeflection)
            }
        };
        set => items = value;
    }
}
