using UnityEngine;
using System.Collections;
using Assets.Scripts.Menu;

namespace Assets.Scripts.Coloring
{
    public class MenuData : MonoBehaviour
    {
        [SerializeField] private GameObject[] _meshes;
        public Material[] _materialsListMenu;
        public string _scene;
        public bool _unlocked;
        public bool _completed;

        void Start()
        {
            if (_unlocked)
            {
                MenuSave();
            }
        }

        public void MenuSave()
        {
            for (int i = 0; i < _meshes.Length; i++)
            {
                string meshCount = _scene + _meshes[i].GetComponent<ObjectNumber>()._objectCount.ToString();
           
                if (PlayerPrefs.HasKey(meshCount))
                {
                    int materialNumber = _meshes[i].GetComponent<ObjectNumber>()._objectNumber;
                    _meshes[i].GetComponent<MeshRenderer>().material = _materialsListMenu[materialNumber];
                    _meshes[i].GetComponent<ObjectNumber>()._colored = true;
                    _meshes[i].GetComponent<Collider>().enabled = false;
                }
            }

        }
    }
}