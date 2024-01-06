using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace Blindnautica
{
    [HarmonyPatch(typeof(HandReticle))]
    public class HandReticlePatches
    {
        private static string oldText = "N/A";

        [HarmonyPatch("UpdateText")]
        [HarmonyPostfix]
            public static void UpdateText(TextMeshProUGUI comp, string text)
        {
            if (string.IsNullOrEmpty(comp.text)) return;

            if (comp.text != oldText)
            {
                NVDA.Speak(Utility.getUntil(comp.text, '<'), false);
                oldText = comp.text;
            }
        }
    }
}
