using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class StartMenu : MonoBehaviour
    {
        public void LoadMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}