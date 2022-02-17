using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Coloring
{
    public class Data : MonoBehaviour
    {
        [SerializeField] private SelectedMesh _selectedMesh;
        [SerializeField] private GameObject[] _meshes;
        [SerializeField] private MaterialsList _materialsList;
        [SerializeField] private OnElementClick _onElementClick;


        private void Start()
        {
            Save();
        }
        public void Save()
        {
            for (int i = 0; i < _meshes.Length; i++)
            {
                string meshCount = _onElementClick._scene + _meshes[i].GetComponent<ObjectNumber>()._objectCount.ToString();
                
                if (PlayerPrefs.HasKey(meshCount))
                {
                    int materialNumber = _meshes[i].GetComponent<ObjectNumber>()._objectNumber;
                    _meshes[i].GetComponent<MeshRenderer>().material = _materialsList._material[materialNumber];
                    _meshes[i].GetComponent<ObjectNumber>()._colored = true;
                    _meshes[i].GetComponent<Collider>().enabled = false;
                }
            }
        }
    }
}