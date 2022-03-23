using Assets.Scripts.Coloring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class LoadScene : MonoBehaviour
    {
        public bool _unlocked;
        public Button[] _buttons;

        private void Start()
        {
            LevelCompleted();
        }

        public void LoadScenes(int scene)
        {
            _unlocked = _buttons[scene - 1].GetComponentInChildren<MenuData>()._unlocked;

            if (_unlocked)
            {
                SceneManager.LoadScene(scene);

            }
        }

        public void LevelCompleted()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                string completedLvl = "completed" + _buttons[i].GetComponentInChildren<MenuData>()._scene;

                if (PlayerPrefs.HasKey(completedLvl))
                {
                    _buttons[i + 1].GetComponentInChildren<MenuData>()._unlocked = true;
                }
            }
        }
    }
}

