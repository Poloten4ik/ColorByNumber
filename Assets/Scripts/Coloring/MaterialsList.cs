using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Coloring
{
    public class MaterialsList : MonoBehaviour
    {
        public Material[] _material;
        public int[] _countOfMesh;
        public int _allMeshes;

        void Start()
        {
            for (int i = 0; i < _countOfMesh.Length;  i++)
            {
                _allMeshes += _countOfMesh[i];
            }
        }
    }
}
