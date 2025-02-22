﻿using SolastaCommunityExpansion.Builders.Features;
using SolastaCommunityExpansion.CustomInterfaces;

namespace SolastaCommunityExpansion.Level20.Features;

internal sealed class FeatureDefinitionPrimalChampionBuilder : FeatureDefinitionBuilder<
    FeatureDefinitionPrimalChampion, FeatureDefinitionPrimalChampionBuilder>
{
    private const string PrimalChampionName = "ZSPrimalChampion";
    private const string PrimalChampionGuid = "118a5ea1-8a19-4bee-9db1-7a2464c8e7b5";

    internal static readonly FeatureDefinitionPrimalChampion FeatureDefinitionPrimalChampion =
        CreateAndAddToDB(PrimalChampionName, PrimalChampionGuid);

    private FeatureDefinitionPrimalChampionBuilder(string name, string guid) : base(name, guid)
    {
        Definition.GuiPresentation.Description = "Feature/&PrimalChampionDescription";
        Definition.GuiPresentation.Title = "Feature/&PrimalChampionTitle";
    }

    private static FeatureDefinitionPrimalChampion CreateAndAddToDB(string name, string guid)
    {
        return new FeatureDefinitionPrimalChampionBuilder(name, guid).AddToDB();
    }
}

internal sealed class FeatureDefinitionPrimalChampion : FeatureDefinition, IFeatureDefinitionCustomCode
{
    public void ApplyFeature(RulesetCharacterHero hero, string tag)
    {
        ModifyAttributeAndMax(hero, AttributeDefinitions.Strength, 4);
        ModifyAttributeAndMax(hero, AttributeDefinitions.Constitution, 4);

        hero.RefreshAll();
    }

    public void RemoveFeature(RulesetCharacterHero hero, string tag)
    {
        ModifyAttributeAndMax(hero, AttributeDefinitions.Strength, -4);
        ModifyAttributeAndMax(hero, AttributeDefinitions.Constitution, -4);

        hero.RefreshAll();
    }

    private static void ModifyAttributeAndMax(RulesetCharacterHero hero, string attributeName, int amount)
    {
        var attribute = hero.GetAttribute(attributeName);
        attribute.BaseValue += amount;
        attribute.MaxValue += amount;
        attribute.MaxEditableValue += amount;
        attribute.Refresh();

        hero.AbilityScoreIncreased?.Invoke(hero, attributeName, amount, amount);
    }
}
