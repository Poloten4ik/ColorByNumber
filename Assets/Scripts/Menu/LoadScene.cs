using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class LoadScene : MonoBehaviour
    {
        public int _number = 0;

        public void LoadScenes(int scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}

