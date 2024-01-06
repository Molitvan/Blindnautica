using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace Blindnautica
{
    internal class Utility
    {
        public static string getStringFromTMP(TextMeshProUGUI tmp)
        {
            Type TMProType = typeof(TextMeshProUGUI);
            FieldInfo TextField = TMProType.GetField("m_text", BindingFlags.NonPublic | BindingFlags.Instance);

            return (string)TextField.GetValue(tmp);
        }

        public static string getUntil(string text, char character)
        {
            int index = text.IndexOf(character);

            if (index == -1) return text;

            return text.Substring(0, index);
        }
    }
}
