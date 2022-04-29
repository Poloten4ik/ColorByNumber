using Assets.Scripts.Coloring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts.Menu
{
    public class LoadScene : MonoBehaviour
    {
        public bool _unlocked;
        public bool _completed;
        public ScreenFade _screenFade;
        public MenuWindow _menuWindow;
        public Button[] _buttons;
        public SpriteRenderer[] _frontSprites;
        public Image[] _lockImage;
        public Color _pressedColor;
        public Color _fadeColor;
        public Color _fadeColorOut;
        public GameObject _completedWindow;
        public Transform _completedPosIn;
        public Transform _completedPosOut;
        public Button _fade;
        public Image _fadeImage;


        private void Awake()
        {
            LevelCompleted();
            CheckUnlock();
        }

        public void LoadScenes(int scene)
        {
            _unlocked = _buttons[scene - 1].GetComponentInChildren<MenuData>()._unlocked;
            _completed = _buttons[scene - 1].GetComponentInChildren<MenuData>()._completed;

            if (_unlocked && !_completed)
            {
                _screenFade.FadeToLevel(scene);
            }

            else if (_unlocked && _completed)
            {
                _completedWindow.SetActive(true); ;
                _completedWindow.transform.DOMove(_completedPosIn.position, 0.5f).SetEase(Ease.InOutCubic);
                _fade.enabled = true;
                _fadeImage.enabled = true;
                _fadeImage.DOColor(_fadeColor, 0.5f);
                _menuWindow._sceneNumber = scene;
                _menuWindow._buttonNumber = scene - 1;
            }
        }

        public void LevelCompleted()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                string completedLvl = "completed" + _buttons[i].GetComponentInChildren<MenuData>()._scene;

                if (PlayerPrefs.HasKey(completedLvl) && i + 1 < _buttons.Length)
                {
                    _buttons[i + 1].GetComponentInChildren<MenuData>()._unlocked = true;
                    _buttons[i].GetComponentInChildren<MenuData>()._completed = true;
                   // _buttons[i].GetComponentInChildren<Animation>().Play();
                    _buttons[i + 1].GetComponent<Animator>().enabled = true;

                    PlayerPrefsExtensions.SetBool("unlock" + _buttons[i + 1].GetComponentInChildren<MenuData>()._scene, true);
                    
                }
                else if (PlayerPrefs.HasKey(completedLvl) && i + 1 == _buttons.Length)
                {
                    _buttons[i].GetComponentInChildren<MenuData>()._completed = true;
                }
            }
        }

        public void CheckUnlock()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                string unlocked = "unlock" + _buttons[i].GetComponentInChildren<MenuData>()._scene;

                if (PlayerPrefs.HasKey(unlocked))
                {
                    _buttons[i].GetComponentInChildren<MenuData>()._unlocked = true;
                    _frontSprites[i - 1].enabled = false;
                    _lockImage[i - 1].enabled = false;
                }
            }
        }

        public void WindowOut()
        {
            _completedWindow.transform.DOMove(_completedPosOut.position, 0.2f).SetEase(Ease.InOutCubic);
            _fade.enabled = false;
            _fadeImage.enabled = false;
            _fadeImage.DOColor(_fadeColorOut, 0.1f);
        }
    }
}

