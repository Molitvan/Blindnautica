using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Blindnautica
{
    public class BlindnauticaMain : MelonMod
    {
        public override void OnInitializeMelon()
        {
            NVDA.Speak("Blindnautica initialized");
            Harmony.PatchAll();
        }

        public override void OnUpdate()
        {
            KeyboardNavigation.OnUpdate();
        }
    }
}
