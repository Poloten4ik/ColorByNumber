using UnityEngine;
using System.Collections;
using Assets.Scripts.Coloring;

namespace Assets.Scripts.Menu
{
    public class MenuWindow : MonoBehaviour
    {
        public ScreenFade _screenFade;
        public LoadScene _loadScene;
        public int _sceneNumber;
        public int _buttonNumber;
        public int[] _meshes;

        public void LoadScene()
        {
            _screenFade.FadeToLevel(_sceneNumber);
        }


        public void RestartScene()
        {
            for (int i = 0; i < _meshes[_buttonNumber]; i++)
            {
                string meshCount = _sceneNumber + "scene" + i.ToString();
                PlayerPrefs.DeleteKey(meshCount);
                PlayerPrefs.DeleteKey("completed" + _sceneNumber + "scene");
                UpdateCountMeshes();
            }

            _screenFade.FadeToLevel(_sceneNumber);
        }

        public void UpdateCountMeshes()
        {
            int materialList = _loadScene._buttons[_buttonNumber].GetComponentInChildren<MenuData>()._materialsListMenu.Length;

            for (int i = 0; i < materialList; i++)
            {
                PlayerPrefs.DeleteKey(_sceneNumber + "scene" + i.ToString() + " countOfMesh");
                PlayerPrefs.DeleteKey(_sceneNumber + "scene" + i.ToString() + " button");
            }
        }

    }
}