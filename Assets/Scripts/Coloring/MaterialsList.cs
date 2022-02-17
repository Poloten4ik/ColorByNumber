using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Coloring
{
    public class MaterialsList : MonoBehaviour
    {
        public Material[] _material;
        public int[] _countOfMesh;
        public int _allMeshes;
        public Text _completed;

        [SerializeField] private OnElementClick _onElementClick;

        void Start()
        {
            for (int j = 0; j < _countOfMesh.Length; j++)
            {
                if (PlayerPrefs.HasKey(_onElementClick._scene + j.ToString() + " countOfMesh"))
                {
                    int count = PlayerPrefs.GetInt(_onElementClick._scene + j.ToString() + " countOfMesh");
                    _countOfMesh[j] = count;
                }
            }

            for (int i = 0; i < _countOfMesh.Length; i++)
            {
                _allMeshes += _countOfMesh[i];
            }
        }

        public void CompletedCheck()
        {
            _allMeshes--;

            if (_allMeshes <= 0)
            {
                _completed.enabled = true;
            }
        }
    }
}
