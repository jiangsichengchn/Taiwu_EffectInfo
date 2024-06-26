﻿using GameData.Serializer;
using GameData.Utilities;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EffectInfo
{
    public partial class EffectInfoFrontend
    {
        public static readonly ushort MY_MAGIC_NUMBER_GetReadingEfficiency = 6724;

        public static void UpdateReadingMouseTips(UI_Reading __instance)
        {
            if (!On)
                return;
            var MainWindow = __instance.transform.Find("MainWindow");
            if (!MainWindow)
                return;
            var Backgroud = MainWindow.Find("Background");
            if (!Backgroud)
                return;
            var BookIntro = Backgroud.Find("BookIntro");
            if (!BookIntro)
                return;
            var gameobject = BookIntro.gameObject;
            if (!gameobject)
                return;
            var mouseTipDisplayer = gameobject.GetComponent<MouseTipDisplayer>();
            if (mouseTipDisplayer is null)
            {
                mouseTipDisplayer = gameobject.AddComponent<MouseTipDisplayer>();
                mouseTipDisplayer.IsLanguageKey = false;
                mouseTipDisplayer.enabled = true;
                mouseTipDisplayer.Type = TipType.Simple;
                mouseTipDisplayer.NeedRefresh = true;
                mouseTipDisplayer.PresetParam = new string[2]
                {
                    "读书效率",
                     $"<color=#grey>\t\t·智力无法接受\t\t\t\t 0%</color>\n"
                };
            }
            __instance.AsyncMethodCall(MyDomainIds.Taiwu, MY_MAGIC_NUMBER_GetReadingEfficiency, delegate (int offset, RawDataPool dataPool)
            {
                var text = "";
                Serializer.Deserialize(dataPool, offset, ref text);
                mouseTipDisplayer.PresetParam[1] = text;
                mouseTipDisplayer.NeedRefresh = true;
                UnityEngine.Debug.Log("Effect Info:Refresh ReadingEfficiency output.");
            });
        }
        [HarmonyPostfix, HarmonyPatch(typeof(UI_Reading), "UpdateUsedReferenceBooks")]
        public static void UpdateReferenceBooksPatch(UI_Reading __instance)
        {
            UpdateReadingMouseTips(__instance);
        }
        [HarmonyPostfix, HarmonyPatch(typeof(UI_Reading), "UpdateBookList")]
        public static void UpdateBookListPatch(UI_Reading __instance)
        {
            UpdateReadingMouseTips(__instance);
        }
        [HarmonyPostfix, HarmonyPatch(typeof(UI_Reading), "UpdateReferenceBookList")]
        public static void UpdateLifeSkillBookListPatch(UI_Reading __instance)
        {
            UpdateReadingMouseTips(__instance);
        }
    }
}