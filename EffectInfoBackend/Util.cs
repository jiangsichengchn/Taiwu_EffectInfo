﻿using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect;
using GameData.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaiwuModdingLib.Core.Plugin;

namespace EffectInfo
{
	//来源CharacterHelper.FieldIds
	//由于CharacterHelper.FieldIds中的值是const ushort，编译后变为常量
	//使用如FieldIds.Id形式调用的话，版本更新可能导致FieldId的值变化从而导致程序失效，需要重新编译
	//所以复制粘贴一份MyFieldId，初始化时通过反射动态获取其整型值
	public static class MyFieldIds
	{
		//自定义MagicNumber
		public static int RecoveryOfMainAttribute = 0x10000;
		public static void Init() {
			foreach (var field in typeof(MyFieldIds).GetFields(BindingFlags.Static| BindingFlags.Public))
				if(field.FieldType == typeof(int))
				{
					int value = -1;
					if (CharacterHelper.FieldName2FieldId.ContainsKey(field.Name))
					{
						value= CharacterHelper.FieldName2FieldId[field.Name];
						field.SetValue(null, value);
					}
					else
						value = (int)field.GetValue(null);
					FieldName2FieldId.Add(field.Name, value);
					FieldId2FieldName.Add(value, field.Name);
				}
		}
		public static readonly Dictionary<string, int> FieldName2FieldId = new Dictionary<string, int>();
		public static readonly Dictionary<int,string> FieldId2FieldName = new Dictionary<int,string>();
		public static int Id = -1;

		public static int TemplateId = -1;

		public static int CreatingType = -1;

		public static int Gender = -1;

		public static int ActualAge = -1;

		public static int BirthMonth = -1;

		public static int Happiness = -1;

		public static int BaseMorality = -1;

		public static int OrganizationInfo = -1;

		public static int IdealSect = -1;

		public static int LifeSkillTypeInterest = -1;

		public static int CombatSkillTypeInterest = -1;

		public static int MainAttributeInterest = -1;

		public static int Transgender = -1;

		public static int Bisexual = -1;

		public static int XiangshuType = -1;

		public static int MonkType = -1;

		public static int FeatureIds = -1;

		public static int BaseMainAttributes = -1;

		public static int Health = -1;

		public static int BaseMaxHealth = -1;

		public static int DisorderOfQi = -1;

		public static int HaveLeftArm = -1;

		public static int HaveRightArm = -1;

		public static int HaveLeftLeg = -1;

		public static int HaveRightLeg = -1;

		public static int Injuries = -1;

		public static int ExtraNeili = -1;

		public static int ConsummateLevel = -1;

		public static int LearnedLifeSkills = -1;

		public static int BaseLifeSkillQualifications = -1;

		public static int LifeSkillQualificationGrowthType = -1;

		public static int BaseCombatSkillQualifications = -1;

		public static int CombatSkillQualificationGrowthType = -1;

		public static int Resources = -1;

		public static int LovingItemSubType = -1;

		public static int HatingItemSubType = -1;

		public static int FullName = -1;

		public static int MonasticTitle = -1;

		public static int Avatar = -1;

		public static int PotentialFeatureIds = -1;

		public static int FameActionRecords = -1;

		public static int Genome = -1;

		public static int CurrMainAttributes = -1;

		public static int Poisoned = -1;

		public static int InjuriesRecoveryProgress = -1;

		public static int CurrNeili = -1;

		public static int LoopingNeigong = -1;

		public static int BaseNeiliAllocation = -1;

		public static int ExtraNeiliAllocation = -1;

		public static int BaseNeiliProportionOfFiveElements = -1;

		public static int HobbyExpirationDate = -1;

		public static int LovingItemRevealed = -1;

		public static int HatingItemRevealed = -1;

		public static int LegitimateBoysCount = -1;

		public static int BirthLocation = -1;

		public static int Location = -1;

		public static int Equipment = -1;

		public static int Inventory = -1;

		public static int EatingItems = -1;

		public static int LearnedCombatSkills = -1;

		public static int EquippedCombatSkills = -1;

		public static int CombatSkillAttainmentPanels = -1;

		public static int SkillQualificationBonuses = -1;

		public static int PreexistenceCharIds = -1;

		public static int XiangshuInfection = -1;

		public static int CurrAge = -1;

		public static int Exp = -1;

		public static int ExternalRelationState = -1;

		public static int KidnapperId = -1;

		public static int LeaderId = -1;

		public static int FactionId = -1;

		public static int PersonalNeeds = -1;

		public static int ActionEnergies = -1;

		public static int NpcTravelTargets = -1;

		public static int PrioritizedActionCooldowns = -1;

		public static int PhysiologicalAge = -1;

		public static int Fame = -1;

		public static int Morality = -1;

		public static int Attraction = -1;

		public static int MaxMainAttributes = -1;

		public static int HitValues = -1;

		public static int Penetrations = -1;

		public static int AvoidValues = -1;

		public static int PenetrationResists = -1;

		public static int RecoveryOfStanceAndBreath = -1;

		public static int MoveSpeed = -1;

		public static int RecoveryOfFlaw = -1;

		public static int CastSpeed = -1;

		public static int RecoveryOfBlockedAcupoint = -1;

		public static int WeaponSwitchSpeed = -1;

		public static int AttackSpeed = -1;

		public static int InnerRatio = -1;

		public static int RecoveryOfQiDisorder = -1;

		public static int PoisonResists = -1;

		public static int MaxHealth = -1;

		public static int Fertility = -1;

		public static int LifeSkillQualifications = -1;

		public static int LifeSkillAttainments = -1;

		public static int CombatSkillQualifications = -1;

		public static int CombatSkillAttainments = -1;

		public static int Personalities = -1;

		public static int HobbyChangingPeriod = -1;

		public static int FavorabilityChangingFactor = -1;

		public static int MaxInventoryLoad = -1;

		public static int CurrInventoryLoad = -1;

		public static int MaxEquipmentLoad = -1;

		public static int CurrEquipmentLoad = -1;

		public static int InventoryTotalValue = -1;

		public static int MaxNeili = -1;

		public static int NeiliAllocation = -1;

		public static int NeiliProportionOfFiveElements = -1;

		public static int NeiliType = -1;

		public static int CombatPower = -1;

		public static int AttackTendencyOfInnerAndOuter = -1;

		public static int Surname = -1;

		public static int GivenName = -1;

		public static int AnonymousTitle = -1;

		public static int RandomFeaturesAtCreating = -1;

		public static int AllowEscape = -1;

		public static int RandomEnemyId = -1;

		public static int LeadingEnemyNestId = -1;

		public static int FixedAvatarName = -1;

		public static int PresetBodyType = -1;

		public static int HideAge = -1;

		public static int Race = -1;

		public static int PresetFame = -1;

		public static int BaseAttraction = -1;

		public static int CanBeKidnapped = -1;

		public static int BaseHitValues = -1;

		public static int BasePenetrations = -1;

		public static int BaseAvoidValues = -1;

		public static int BasePenetrationResists = -1;

		public static int BaseRecoveryOfStanceAndBreath = -1;

		public static int BaseMoveSpeed = -1;

		public static int BaseRecoveryOfFlaw = -1;

		public static int BaseCastSpeed = -1;

		public static int BaseRecoveryOfBlockedAcupoint = -1;

		public static int BaseWeaponSwitchSpeed = -1;

		public static int BaseAttackSpeed = -1;

		public static int BaseInnerRatio = -1;

		public static int BaseRecoveryOfQiDisorder = -1;

		public static int BasePoisonResists = -1;

		public static int InnerInjuryImmunity = -1;

		public static int OuterInjuryImmunity = -1;

		public static int PoisonImmunities = -1;

		public static int PresetEquipment = -1;

		public static int PresetInventory = -1;

		public static int PresetCombatSkills = -1;

		public static int PresetNeiliProportionOfFiveElements = -1;
	}
	//同上，AffectedDataHelper版本
	public static class MyAffectedDataFieldIds
	{
		public static void Init()
		{
			foreach (var field in typeof(MyAffectedDataFieldIds).GetFields(BindingFlags.Static | BindingFlags.Public))
				if (field.FieldType == typeof(ushort))
					if (AffectedDataHelper.FieldName2FieldId.ContainsKey(field.Name))
					{
						var value = AffectedDataHelper.FieldName2FieldId[field.Name];
						field.SetValue(null, value);
					}
		}
		public static ushort Id = 0;

		public static ushort MaxStrength = 0;

		public static ushort MaxDexterity = 0;

		public static ushort MaxConcentration = 0;

		public static ushort MaxVitality = 0;

		public static ushort MaxEnergy = 0;

		public static ushort MaxIntelligence = 0;

		public static ushort CostStrength = 0;

		public static ushort CostDexterity = 0;

		public static ushort CostConcentration = 0;

		public static ushort CostVitality = 0;

		public static ushort CostEnergy = 0;

		public static ushort CostIntelligence = 0;

		public static ushort RecoveryOfStance = 0;

		public static ushort RecoveryOfBreath = 0;

		public static ushort MoveSpeed = 0;

		public static ushort RecoveryOfFlaw = 0;

		public static ushort CastSpeed = 0;

		public static ushort RecoveryOfBlockedAcupoint = 0;

		public static ushort WeaponSwitchSpeed = 0;

		public static ushort AttackSpeed = 0;

		public static ushort InnerRatio = 0;

		public static ushort RecoveryOfQiDisorder = 0;

		public static ushort MinorAttributeFixMaxValue = 0;

		public static ushort MinorAttributeFixMinValue = 0;

		public static ushort ResistOfHotPoison = 0;

		public static ushort ResistOfGloomyPoison = 0;

		public static ushort ResistOfColdPoison = 0;

		public static ushort ResistOfRedPoison = 0;

		public static ushort ResistOfRottenPoison = 0;

		public static ushort ResistOfIllusoryPoison = 0;

		public static ushort DisplayAge = 0;

		public static ushort NeiliProportionOfFiveElements = 0;

		public static ushort WeaponMaxPower = 0;

		public static ushort WeaponUseRequirement = 0;

		public static ushort ArmorMaxPower = 0;

		public static ushort ArmorUseRequirement = 0;

		public static ushort HitStrength = 0;

		public static ushort HitTechnique = 0;

		public static ushort HitSpeed = 0;

		public static ushort HitMind = 0;

		public static ushort HitCanChange = 0;

		public static ushort HitChangeEffectPercent = 0;

		public static ushort AvoidStrength = 0;

		public static ushort AvoidTechnique = 0;

		public static ushort AvoidSpeed = 0;

		public static ushort AvoidMind = 0;

		public static ushort AvoidCanChange = 0;

		public static ushort AvoidChangeEffectPercent = 0;

		public static ushort PenetrateOuter = 0;

		public static ushort PenetrateInner = 0;

		public static ushort PenetrateResistOuter = 0;

		public static ushort PenetrateResistInner = 0;

		public static ushort NeiliAllocationAttack = 0;

		public static ushort NeiliAllocationAgile = 0;

		public static ushort NeiliAllocationDefense = 0;

		public static ushort NeiliAllocationAssist = 0;

		public static ushort Happiness = 0;

		public static ushort MaxHealth = 0;

		public static ushort HealthCost = 0;

		public static ushort MoveSpeedCanChange = 0;

		public static ushort AttackerHitStrength = 0;

		public static ushort AttackerHitTechnique = 0;

		public static ushort AttackerHitSpeed = 0;

		public static ushort AttackerHitMind = 0;

		public static ushort AttackerAvoidStrength = 0;

		public static ushort AttackerAvoidTechnique = 0;

		public static ushort AttackerAvoidSpeed = 0;

		public static ushort AttackerAvoidMind = 0;

		public static ushort AttackerPenetrateOuter = 0;

		public static ushort AttackerPenetrateInner = 0;

		public static ushort AttackerPenetrateResistOuter = 0;

		public static ushort AttackerPenetrateResistInner = 0;

		public static ushort AttackHitType = 0;

		public static ushort MakeDirectDamage = 0;

		public static ushort MakeBounceDamage = 0;

		public static ushort MakeFightBackDamage = 0;

		public static ushort MakePoisonLevel = 0;

		public static ushort MakePoisonValue = 0;

		public static ushort AttackerHitOdds = 0;

		public static ushort AttackerFightBackHitOdds = 0;

		public static ushort AttackerPursueOdds = 0;

		public static ushort MakedInjuryChangeToOld = 0;

		public static ushort MakedPoisonChangeToOld = 0;

		public static ushort MakeDirectDamageMinPercent = 0;

		public static ushort MakeInjuryMinPercent = 0;

		public static ushort IgnoreArmorOnCalcAvoid = 0;

		public static ushort IgnoreArmorOnCalcPenetrateResist = 0;

		public static ushort IgnoreArmorOnCalcInjury = 0;

		public static ushort MakeDamageType = 0;

		public static ushort CanMakeInjuryToNoInjuryPart = 0;

		public static ushort MakePoisonType = 0;

		public static ushort NormalAttackWeapon = 0;

		public static ushort NormalAttackTrick = 0;

		public static ushort ExtraFlawCount = 0;

		public static ushort AttackCanBounce = 0;

		public static ushort AttackCanFightBack = 0;

		public static ushort MakeFightBackInjuryMark = 0;

		public static ushort MakeMaxMindMark = 0;

		public static ushort DefenderHitStrength = 0;

		public static ushort DefenderHitTechnique = 0;

		public static ushort DefenderHitSpeed = 0;

		public static ushort DefenderHitMind = 0;

		public static ushort DefenderAvoidStrength = 0;

		public static ushort DefenderAvoidTechnique = 0;

		public static ushort DefenderAvoidSpeed = 0;

		public static ushort DefenderAvoidMind = 0;

		public static ushort DefenderPenetrateOuter = 0;

		public static ushort DefenderPenetrateInner = 0;

		public static ushort DefenderPenetrateResistOuter = 0;

		public static ushort DefenderPenetrateResistInner = 0;

		public static ushort AcceptDirectDamage = 0;

		public static ushort AcceptBounceDamage = 0;

		public static ushort AcceptFightBackDamage = 0;

		public static ushort AcceptPoisonLevel = 0;

		public static ushort AcceptPoisonValue = 0;

		public static ushort DefenderHitOdds = 0;

		public static ushort DefenderFightBackHitOdds = 0;

		public static ushort DefenderPursueOdds = 0;

		public static ushort AcceptInjuryMaxPercent = 0;

		public static ushort AcceptMaxInjuryCount = 0;

		public static ushort BouncePower = 0;

		public static ushort FightBackPower = 0;

		public static ushort DirectDamageInnerRatio = 0;

		public static ushort FinalDamageValue = 0;

		public static ushort DirectInjuryMark = 0;

		public static ushort GoneMadInjury = 0;

		public static ushort HealInjurySpeed = 0;

		public static ushort HealInjuryBuff = 0;

		public static ushort HealInjuryDebuff = 0;

		public static ushort HealPoisonSpeed = 0;

		public static ushort HealPoisonBuff = 0;

		public static ushort HealPoisonDebuff = 0;

		public static ushort FleeSpeed = 0;

		public static ushort MaxFlawCount = 0;

		public static ushort CanAddFlaw = 0;

		public static ushort FlawLevel = 0;

		public static ushort FlawLevelCanReduce = 0;

		public static ushort FlawCount = 0;

		public static ushort MaxAcupointCount = 0;

		public static ushort CanAddAcupoint = 0;

		public static ushort AcupointLevel = 0;

		public static ushort AcupointLevelCanReduce = 0;

		public static ushort AcupointCount = 0;

		public static ushort AddNeiliAllocation = 0;

		public static ushort CostNeiliAllocation = 0;

		public static ushort CanChangeNeiliAllocation = 0;

		public static ushort CanGetTrick = 0;

		public static ushort GetTrickType = 0;

		public static ushort AttackBodyPart = 0;

		public static ushort WeaponEquipAttack = 0;

		public static ushort WeaponEquipDefense = 0;

		public static ushort ArmorEquipAttack = 0;

		public static ushort ArmorEquipDefense = 0;

		public static ushort AttackRangeForward = 0;

		public static ushort AttackRangeBackward = 0;

		public static ushort MoveCanBeStopped = 0;

		public static ushort CanForcedMove = 0;

		public static ushort MobilityCanBeRemoved = 0;

		public static ushort MobilityCostByEffect = 0;

		public static ushort MoveDistance = 0;

		public static ushort JumpPrepareFrame = 0;

		public static ushort BounceInjuryMark = 0;

		public static ushort SkillHasCost = 0;

		public static ushort CombatStateEffect = 0;

		public static ushort ChangeNeedUseSkill = 0;

		public static ushort ChangeDistanceIsMove = 0;

		public static ushort ReplaceCharHit = 0;

		public static ushort CanAddPoison = 0;

		public static ushort CanReducePoison = 0;

		public static ushort ReducePoisonValue = 0;

		public static ushort PoisonCanAffect = 0;

		public static ushort PoisonAffectCount = 0;

		public static ushort PoisonDamage = 0;

		public static ushort PoisonWorsenCount = 0;

		public static ushort CostTricks = 0;

		public static ushort ReduceWeaponDurability = 0;

		public static ushort ReduceArmorDurability = 0;

		public static ushort JumpMoveDistance = 0;

		public static ushort CombatStateToAdd = 0;

		public static ushort CombatStatePower = 0;

		public static ushort BreakBodyPartInjuryCount = 0;

		public static ushort BodyPartIsBroken = 0;

		public static ushort MaxTrickCount = 0;

		public static ushort MaxBreathPercent = 0;

		public static ushort MaxStancePercent = 0;

		public static ushort MaxSkillMobilityPercent = 0;

		public static ushort ExtraBreathPercent = 0;

		public static ushort ExtraStancePercent = 0;

		public static ushort MobilityRecoverPrepareSpeed = 0;

		public static ushort MoveCostMobility = 0;

		public static ushort DefendSkillKeepTime = 0;

		public static ushort BounceRange = 0;

		public static ushort CanAddMindMark = 0;

		public static ushort MindMarkKeepTime = 0;

		public static ushort SkillMobilityCostPerFrame = 0;

		public static ushort CanAddWug = 0;

		public static ushort HasGodWeaponBuff = 0;

		public static ushort HasGodArmorBuff = 0;

		public static ushort TeammateCmdRequireGenerateValue = 0;

		public static ushort TeammateCmdEffect = 0;

		public static ushort FlawRecoverSpeed = 0;

		public static ushort AcupointRecoverSpeed = 0;

		public static ushort MindMarkRecoverSpeed = 0;

		public static ushort InjuryAutoHealSpeed = 0;

		public static ushort CanRecoverBreath = 0;

		public static ushort CanRecoverStance = 0;

		public static ushort CanRecoverAttackPrepare = 0;

		public static ushort Power = 0;

		public static ushort MaxPower = 0;

		public static ushort PowerMinPercent = 0;

		public static ushort UseRequirement = 0;

		public static ushort CurrInnerRatio = 0;

		public static ushort CostBreathAndStance = 0;

		public static ushort CostBreath = 0;

		public static ushort CostStance = 0;

		public static ushort CostMobility = 0;

		public static ushort SkillCostTricks = 0;

		public static ushort EffectDirection = 0;

		public static ushort EffectDirectionCanChange = 0;

		public static ushort CanInterrupt = 0;

		public static ushort InterruptOdds = 0;

		public static ushort CanSilence = 0;

		public static ushort SilenceOdds = 0;

		public static ushort CanCastWithBrokenBodyPart = 0;

		public static ushort AddPowerCanBeRemoved = 0;

		public static ushort SkillType = 0;

		public static ushort EffectCountCanChange = 0;

		public static ushort CanCastInDefend = 0;

		public static ushort HitDistribution = 0;

		public static ushort CanCastOnLackBreath = 0;

		public static ushort CanCastOnLackStance = 0;

		public static ushort CostBreathOnCast = 0;

		public static ushort CostStanceOnCast = 0;

		public static ushort CanUseMobilityAsBreath = 0;

		public static ushort CanUseMobilityAsStance = 0;

		public static ushort CanUseSkillMobilityAsBreath = 0;

		public static ushort CanUseSkillMobilityAsStance = 0;

		public static ushort CastCostNeiliAllocation = 0;
	}
	public partial class EffectInfoBackend : TaiwuRemakePlugin
    {
		public static string valueSumType2Text(sbyte valueSumType)
        {
			if (valueSumType == 1)
				return "加值";
			if (valueSumType == 2)
				return "减值";
			return "";
        }
		public static string GetCombatSkillName(short combat_skill_id)
		{
			var charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(combat_skill_id);
			if (charCombatSkills == null || !charCombatSkills.ContainsKey(combat_skill_id))
				return "";
			var combat_skill = charCombatSkills[combat_skill_id];
			var template_id = combat_skill.GetId().SkillTemplateId;
			var cb_template = Config.CombatSkill.Instance[template_id];
			return cb_template.Name;
		}
		public static FieldType GetValue<FieldType>(object instance, string field_name, BindingFlags flags)
		{
			Type type = instance.GetType();
			FieldInfo field_info = type.GetField(field_name, flags);
			return (FieldType)field_info.GetValue(instance);
		}
		public static FieldType GetPrivateValue<FieldType>(object instance, string field_name)
		{
			return GetValue<FieldType>(instance, field_name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
		}
		public static ReturnType CallPrivateStaticMethod<ReturnType>(object instance, string method_name, object[] paras)
		{
			Type type = instance.GetType();
			MethodInfo method_info = type.GetMethod(method_name, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
			var para_infos = method_info.GetParameters();
			if (paras.Length != paras.Length)
			{
				AdaptableLog.Info($"EffectInfo失效:{method_name}");
				return (ReturnType)new object();
			}
			for (int i = 0; i < para_infos.Length; i++)
				if (para_infos[i].ParameterType != paras[i].GetType())
				{
					AdaptableLog.Info($"EffectInfo失效:{method_name} {para_infos[i].Name}");
					return (ReturnType)new object();
				}
			return (ReturnType)method_info.Invoke(instance, paras);
		}
		public static ReturnType CallPrivateMethod<ReturnType>(object instance, string method_name, object[] paras)
		{
			Type type = instance.GetType();
			MethodInfo method_info = type.GetMethod(method_name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
			var para_infos = method_info.GetParameters();
			if (paras.Length != paras.Length)
			{
				AdaptableLog.Info($"EffectInfo失效:{method_name}");
				return (ReturnType)new object();
			}
			for (int i = 0; i < para_infos.Length; i++)
				if (para_infos[i].ParameterType != paras[i].GetType())
				{
					AdaptableLog.Info($"EffectInfo失效:{method_name} {para_infos[i].Name}");
					return (ReturnType)new object();
				}
			return (ReturnType)method_info.Invoke(instance, paras);
		}


		public static string GetEquipmentName(ItemKey itemKey)
		{
			ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
			return item.GetName();
		}
		public static string GetFeatureName(short feature_id)
		{
			return Config.CharacterFeature.Instance.GetItem(feature_id).Name;
		}
		public static void SetPrivateField<FieldType>(object instance, string field_name, FieldType value)
		{
			Type type = instance.GetType();
			FieldInfo field_info = type.GetField(field_name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
			field_info.SetValue(instance, value);
        }
        //level为负时不输出抬头的level
        unsafe static string ToInfo(string title, string item, int msgLevel)
        {
            var levelabs = Math.Abs(msgLevel);
            if (levelabs > EffectInfoBackend.InfoLevel)
                return "";
            string result = msgLevel >= 0 ? $"{msgLevel} " : "";
            if (levelabs == 1)
                result += $"<color=#pinkyellow>·{title}\t\t\t\t\t\t{item}</color>\n";//align会改变整行
            else if (levelabs == 2)
                result += $"<color=#grey>\t·{title}\t\t\t\t\t{item}</color>\n";
			else if (levelabs == 3)
            {
				if (title.Length > 6)
					result += $"<color=#grey>\t\t·{title}\t\t\t// {item}</color>\n";
				else if (title.Length > 10)
					result += $"<color=#grey>\t\t·{title}\t\t// {item}</color>\n";
				else if (title.Length > 14)
					result += $"<color=#grey>\t\t·{title}\t// {item}</color>\n";
				else if (title.Length > 18)
					result += $"<color=#grey>\t\t·{title}// {item}</color>\n";
				else
					result += $"<color=#grey>\t\t·{title}\t\t\t\t// {item}</color>\n";
			}
			else if (levelabs == 4)
				result += $"<color=#grey>\t\t\t·{title}\t\t\t\t//// {item}</color>\n";
			else
				result += $"<color=#grey>\t\t·{title}\t\t\t\t// {item}</color>\n";
			return result;
        }
		unsafe static string ToInfoMin(string title, int value, int infoLevel)
		{
			return ToInfo(title, $">={value}", infoLevel);
		}
		unsafe static string ToInfoMax(string title, int value, int infoLevel)
		{
			return ToInfo(title, $"<={value}", infoLevel);
		}
		unsafe static string ToInfoDivision(string title, int value, int infoLevel)
		{
			return ToInfo(title, $"÷{value}", infoLevel);
		}

		unsafe static string ToInfoAdd(string title, double value, int infoLevel)
		{
			if (value > 0)
				return ToInfo(title, $"+{value.ToString("f2")}", infoLevel);
			if (value < 0)
				return ToInfo(title, $"-{value.ToString("f2")}", infoLevel);
			return ToInfo(title, $"0", infoLevel);
		}
		unsafe static string ToInfoAdd(string title, int value, int infoLevel)
		{
			if (value > 0)
				return ToInfo(title, $"+{value}", infoLevel);
			if (value < 0)
				return ToInfo(title, $"{value}", infoLevel);
			return ToInfo(title, $"0", infoLevel);
		}
		unsafe static string ToInfoAdd(string title, short value, int infoLevel)
		{
			return ToInfoAdd(title, (int)value, infoLevel);
		}
		unsafe static string ToInfoMulti(string title, int value, int infoLevel)
		{
			return ToInfo(title, $"×{value}", infoLevel);
		}
		unsafe static string ToInfoMulti(string title, double value, int infoLevel)
		{
			return ToInfo(title, $"×{value.ToString("f2")}", infoLevel);
		}
		unsafe static string ToInfoPercent(string title, int value, int infoLevel)
		{
			return ToInfo(title, $"×{value}%", infoLevel);
		}


	}
}
