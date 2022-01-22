using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Coloring
{
    public static class PlayerPrefsExtensions
    {
        public static bool GetBool(string key, bool defaultValue = false)
        {
            if (PlayerPrefs.HasKey(key))
                return PlayerPrefs.GetInt(key) == 1;

            return defaultValue;
        }

        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }
    }
}