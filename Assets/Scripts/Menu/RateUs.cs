using UnityEngine;
using UnityEditor;
using Assets.Scripts.Coloring;

namespace Assets.Scripts.Menu
{
    public class RateUs : MonoBehaviour
    {
        public GameObject _rateUsWindow;
        public Animation _animation;
        public AnimationClip _hide;

        private void Start()
        {
            RateUsShow();
        }

        public void RateUsShow()
        {
            if (!PlayerPrefs.HasKey("rate_game"))
            {
                _animation.Play();
                PlayerPrefsExtensions.SetBool("rate_game", true);
            }
            else
            {
                _rateUsWindow.SetActive(false);
            }
        }

        public void RateUsButton()
        {
            Application.OpenURL("http://unity3d.com/");
            Hide();
        }

        public void Hide()
        {
            _animation.clip = _hide;
            _animation.Play();
        }
    }
}