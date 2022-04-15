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
        public ScreenFade _screenFade;
        public Button[] _buttons;
        public SpriteRenderer[] _frontSprites;

        private void Start()
        {
            LevelCompleted();
        }

        public void LoadScenes(int scene)
        {
            _unlocked = _buttons[scene - 1].GetComponentInChildren<MenuData>()._unlocked;

            if (_unlocked)
            {
                _screenFade.FadeToLevel(scene);
            }
        }

        public void LevelCompleted() 
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                string completedLvl = "completed" + _buttons[i].GetComponentInChildren<MenuData>()._scene;

                if (PlayerPrefs.HasKey(completedLvl) && i + 1 < _buttons.Length )
                {
                    _buttons[i + 1].GetComponentInChildren<MenuData>()._unlocked = true;
                    _buttons[i].GetComponentInChildren<Animation>().Play();
                    _frontSprites[i].enabled = false;
                }
            }
        }
    }
}

