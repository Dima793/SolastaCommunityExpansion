﻿using UnityEngine.AddressableAssets;
using static EquipmentDefinitions;

namespace SolastaCommunityExpansion.Builders;

public class UsableDeviceDescriptionBuilder
{
    private readonly UsableDeviceDescription description;

    public UsableDeviceDescriptionBuilder()
    {
        description = new UsableDeviceDescription();

        description.usage = ItemUsage.ByFunction;

        description.chargesCapital = ItemChargesCapital.Fixed;
        description.chargesCapitalNumber = 1;
        description.chargesCapitalDie = RuleDefinitions.DieType.D1;
        description.chargesCapitalBonus = 0;

        description.rechargeRate = RuleDefinitions.RechargeRate.Dawn;
        description.rechargeNumber = 1;
        description.rechargeDie = RuleDefinitions.DieType.D1;
        description.rechargeBonus = 0;

        description.outOfChargesConsequence = ItemOutOfCharges.Persist;
        description.magicAttackBonus = 0;
        description.saveDC = 10;
        description.onUseParticle = new AssetReference();
    }

    public UsableDeviceDescriptionBuilder SetUsage(ItemUsage usage)
    {
        description.usage = usage;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetOutOfChargesConsequence(ItemOutOfCharges consequence)
    {
        description.outOfChargesConsequence = consequence;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetMagicAttackBonus(int bonus)
    {
        description.magicAttackBonus = bonus;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetSaveDC(int DC)
    {
        description.saveDC = DC;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetOnUseParticle(AssetReference asset)
    {
        description.onUseParticle = asset;
        return this;
    }

    public UsableDeviceDescriptionBuilder AddFunctions(params DeviceFunctionDescription[] functions)
    {
        description.DeviceFunctions.AddRange(functions);
        return this;
    }

    public UsableDeviceDescription Build()
    {
        return description;
    }

    #region Charge

    public UsableDeviceDescriptionBuilder SetCharges(
        ItemChargesCapital capital = ItemChargesCapital.Fixed,
        int number = 1,
        RuleDefinitions.DieType dieType = RuleDefinitions.DieType.D1,
        int bonus = 0)
    {
        description.chargesCapital = capital;
        description.chargesCapitalNumber = number;
        description.chargesCapitalDie = dieType;
        description.chargesCapitalBonus = bonus;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetChargesCapital(ItemChargesCapital capital)
    {
        description.chargesCapital = capital;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetChargesCapitalNumber(int number)
    {
        description.chargesCapitalNumber = number;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetChargesCapitalDie(RuleDefinitions.DieType dieType)
    {
        description.chargesCapitalDie = dieType;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetChargesCapitalBonus(int bonus)
    {
        description.chargesCapitalBonus = bonus;
        return this;
    }

    #endregion

    #region Recharge

    public UsableDeviceDescriptionBuilder SetRecharge(
        RuleDefinitions.RechargeRate rate = RuleDefinitions.RechargeRate.Dawn,
        int number = 1,
        RuleDefinitions.DieType dieType = RuleDefinitions.DieType.D1,
        int bonus = 0)
    {
        description.rechargeRate = rate;
        description.rechargeNumber = number;
        description.rechargeDie = dieType;
        description.rechargeBonus = bonus;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetRechargeRate(RuleDefinitions.RechargeRate rate)
    {
        description.rechargeRate = rate;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetRechargeNumber(int number)
    {
        description.rechargeNumber = number;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetRechargeDie(RuleDefinitions.DieType dieType)
    {
        description.rechargeDie = dieType;
        return this;
    }

    public UsableDeviceDescriptionBuilder SetRechargeBonus(int bonus)
    {
        description.rechargeBonus = bonus;
        return this;
    }

    #endregion
}
