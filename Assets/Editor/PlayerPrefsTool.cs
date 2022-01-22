using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class PlayerPrefsTool : EditorWindow
    {
        [UnityEditor.MenuItem("Tools/PlayerPrefs/Clear")]

        public static void ShowWindow()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}