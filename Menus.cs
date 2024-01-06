using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Reflection;
using MelonLoader;
using static LanguageCache;

namespace Blindnautica
{
    [HarmonyPatch(typeof(Selectable))]
    internal class SelectablePatches
    {
        [HarmonyPatch(nameof(Selectable.OnPointerEnter))]
        [HarmonyPostfix]
        public static void OnPointerEnter(Selectable __instance)
        {
            SpeakElementName(__instance);
        }

        [HarmonyPatch(nameof(Selectable.OnSelect))]
        [HarmonyPostfix]
        public static void OnSelect(Selectable __instance)
        {
            SpeakElementName(__instance);
        }

        private static void SpeakElementName(Selectable __instance)
        {
            if (__instance.name == "LoadButton")
            {
                GameObject loadInfo = __instance.transform.parent.gameObject;

                string gameMode = Utility.getStringFromTMP(loadInfo.transform.Find("SaveGameMode").GetComponent<TextMeshProUGUI>());
                string lastPlayed = Utility.getStringFromTMP(loadInfo.transform.Find("SaveGameTime").GetComponent<TextMeshProUGUI>());
                string gameLength = Utility.getStringFromTMP(loadInfo.transform.Find("SaveGameLength").GetComponent<TextMeshProUGUI>());

                NVDA.Speak($"Load; Gamemode: {gameMode}; Last played: {lastPlayed}; Play time: {gameLength}");
            } else {
                try
                {
                    TextMeshProUGUI ButtonText = __instance.GetComponentInChildren<TextMeshProUGUI>();

                    string TextToSay = Utility.getStringFromTMP(ButtonText);
                    NVDA.Speak(TextToSay);
                } catch
                {
                    NVDA.Speak(__instance.name);
                }
            }
        }
    }
}
