using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Coloring
{
    public class Data : MonoBehaviour
    {
        public  GameObject[] _meshes;
        [SerializeField] private MaterialsList _materialsList;
        [SerializeField] private OnElementClick _onElementClick;


        private void Start()
        {
            StartCoroutine(Save());
        }
        public IEnumerator Save()
        {
            string completedLvl = "completed" + _onElementClick._scene;

            yield return new WaitForSeconds(0.2f);

            if (!PlayerPrefs.HasKey(completedLvl))
            {
                for (int i = 0; i < _meshes.Length; i++)
                {
                    string meshCount = _onElementClick._scene + _meshes[i].GetComponent<ObjectNumber>()._objectCount.ToString();
                    var animation = _meshes[i].GetComponent<AnimationOnClick>();

                    if (PlayerPrefs.HasKey(meshCount))
                    {
                        yield return new WaitForSeconds(_materialsList._progressColoringTime);
                        int materialNumber = _meshes[i].GetComponent<ObjectNumber>()._objectNumber;
                        if (!animation._water)
                        {
                            _meshes[i].GetComponent<MeshRenderer>().material.DOColor(_materialsList._color[materialNumber], 0.5f);
                        }
                        else
                        {
                            _meshes[i].GetComponent<MeshRenderer>().material = _materialsList._material[materialNumber];
                        }
                        _meshes[i].GetComponent<ObjectNumber>()._colored = true;
                        _meshes[i].GetComponent<Collider>().enabled = false;
                    }
                }
            }
        }
    }
}