﻿using GameData.Domains.Combat;
using GameData.Serializer;
using GameData.Utilities;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EffectInfo
{ 
    public partial class EffectInfoFrontend
    {
        public static readonly ushort MY_MAGIC_NUMBER_GetCombatCompareText = 7679;

        public static void SetCover(GameObject gameObject,bool alpha=false)
        {
            if (!gameObject)
                return;
            var cover = gameObject.GetOrAddComponent<TextMeshProUGUI>();
            //if (alpha)
            //{
            //    cover.AutoSize = true;
            //    cover.SetAlpha(0f);
            //}
            cover.raycastTarget = true;
            cover.SetAllDirty();
            GetOrAddSimpleMouseTipDisplayer(gameObject);
        }
        public static MouseTipDisplayer GetOrAddSimpleMouseTipDisplayer(GameObject gameObject)
        {
            var mouseTipDisplayer = gameObject.GetComponent<MouseTipDisplayer>();
            if (mouseTipDisplayer == null)
            {
                mouseTipDisplayer = gameObject.AddComponent<MouseTipDisplayer>();
                mouseTipDisplayer.IsLanguageKey = false;
                mouseTipDisplayer.enabled = true;
                mouseTipDisplayer.NeedRefresh = true;
                mouseTipDisplayer.Type = TipType.Simple;
                mouseTipDisplayer.PresetParam = new string[2]
                {
                        "洞察",
                        "空"
                };
            }
            return mouseTipDisplayer;
        }
        [HarmonyPrefix, HarmonyPatch(typeof(UI_Combat), "UpdateDataCompare")]
        public static void UpdateDataComparePatch(UI_Combat __instance, Refers ____dataCompare, DamageCompareData ____damageCompareData)
        {
            Refers dataCompare = __instance.CGet<Refers>("DataCompare");
            if (dataCompare.GetComponent<GraphicRaycaster>() == null)
            {
                dataCompare.gameObject.AddComponent<GraphicRaycaster>();
            }

            RectTransform hit_rect;
            RectTransform avoid_rect;
            if (____damageCompareData.IsAlly)
            {
                hit_rect = ____dataCompare.CGet<RectTransform>("SelfHitTypeHolder");
                avoid_rect = ____dataCompare.CGet<RectTransform>("EnemyHitTypeHolder");
            }
            else
            {
                hit_rect = ____dataCompare.CGet<RectTransform>("EnemyHitTypeHolder");
                avoid_rect = ____dataCompare.CGet<RectTransform>("SelfHitTypeHolder");
            }

            //初始化，为了能让每条属性分别显示提示，将SelfHitTypeHolder设为rayCast=false,并在每个hitType上加上透明的CImage用于接受射线，并添加mouseTip
            //不知道为什么，更改raycastTarget不会保留
            foreach (var holder in new RectTransform[] { hit_rect, avoid_rect })
            {
                //holder.GetComponent<CImage>().raycastTarget = false;
                for (int i = 0; i < holder.childCount; ++i)
                    SetCover(holder.GetChild(i).Find("Value").gameObject, true);
            }

            var atkdefHolder = ____dataCompare.gameObject.transform.Find("OuterInnerHolder");
            //攻防同理
            {
                //____dataCompare.CGet<GameObject>("SelfAttackTag").GetComponent<CImage>().raycastTarget = false;
                //____dataCompare.CGet<GameObject>("SelfDefendTag").GetComponent<CImage>().raycastTarget = false;
                //____dataCompare.CGet<GameObject>("EnemyDefendTag").GetComponent<CImage>().raycastTarget = false;
                //____dataCompare.CGet<GameObject>("EnemyDefendTag").GetComponent<CImage>().raycastTarget = false;
                foreach (var transform in new Transform[] { atkdefHolder.Find("Outer").Find("SelfOuterValue"),
                                                            atkdefHolder.Find("Inner").Find("SelfInnerValue"),
                                                            atkdefHolder.Find("Outer").Find("EnemyOuterValue"),
                                                            atkdefHolder.Find("Inner").Find("EnemyInnerValue")})
                {
                    transform.gameObject.GetComponent<TextMeshProUGUI>().raycastTarget = true;
                    GetOrAddSimpleMouseTipDisplayer(transform.gameObject);
                }
            }
            //顺序:3命中3闪避2攻击(外内)2防御
            //总是10个,不足的null占位
            var mouseTips = new List<MouseTipDisplayer>();
            //命中
            for (sbyte hitType = 0; hitType < 4; hitType = (sbyte)(hitType + 1))
                if (____damageCompareData.HitType.Exist(hitType))
                    mouseTips.Add(hit_rect.GetChild(3 - hitType).Find("Value").GetComponent<MouseTipDisplayer>());
            while (mouseTips.Count < 3)
                mouseTips.Add(null);
            //回避
            for (sbyte hitType = 0; hitType < 4; hitType = (sbyte)(hitType + 1))
                if (____damageCompareData.HitType.Exist(hitType))
                    mouseTips.Add(avoid_rect.GetChild(3 - hitType).Find("Value").GetComponent<MouseTipDisplayer>());
            while (mouseTips.Count < 6)
                mouseTips.Add(null);
            //攻防
            if (____damageCompareData.IsAlly)
                foreach (var transform in new Transform[] { atkdefHolder.Find("Outer").Find("SelfOuterValue"),
                                                            atkdefHolder.Find("Inner").Find("SelfInnerValue"),
                                                            atkdefHolder.Find("Outer").Find("EnemyOuterValue"),
                                                            atkdefHolder.Find("Inner").Find("EnemyInnerValue")})
                    mouseTips.Add(transform.GetComponent<MouseTipDisplayer>());
            else
                foreach (var transform in new Transform[] { atkdefHolder.Find("Outer").Find("EnemyOuterValue"),
                                                            atkdefHolder.Find("Inner").Find("EnemyInnerValue"),
                                                            atkdefHolder.Find("Outer").Find("SelfOuterValue"),
                                                            atkdefHolder.Find("Inner").Find("SelfInnerValue")})
                    mouseTips.Add(transform.GetComponent<MouseTipDisplayer>());

            while (mouseTips.Count < 10)
                mouseTips.Add(null);
            __instance.AsyncMethodCall(MyDomainIds.TutorialChapter, MY_MAGIC_NUMBER_GetCombatCompareText, delegate (int offset, RawDataPool dataPool)
            {
                List<string> combatCompareText = new List<string>();
                //顺序:3命中3闪避2攻击(外内)2防御
                Serializer.Deserialize(dataPool, offset, ref combatCompareText);
                System.IO.File.WriteAllText("1.txt", string.Join(",", combatCompareText));
                for (int i = 0; i < mouseTips.Count && i < combatCompareText.Count; i++)
                    if (mouseTips[i] != null && mouseTips[i].PresetParam != null && mouseTips[i].PresetParam.Count() > 1)
                    {
                        mouseTips[i].PresetParam[1] = combatCompareText[i];
                        mouseTips[i].NeedRefresh = true;
                    }
                UnityEngine.Debug.Log("Effect Info:Refresh CombatCompareData.");
            });
        }
    }
}
