using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class ScreenFade : MonoBehaviour
    {

        [SerializeField] private Animator _animator;

        private int _levelToLoad;

        public void FadeToLevel(int index)
        {
            _levelToLoad = index;
            _animator.SetTrigger("FadeOut");
        }

        public void OnFadeComplete()
        {
            SceneManager.LoadScene(_levelToLoad); 
        }
    }
}