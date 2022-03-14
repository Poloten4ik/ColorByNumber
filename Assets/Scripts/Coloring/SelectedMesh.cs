using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Coloring
{
    public class SelectedMesh : MonoBehaviour
    {
        public Transform[] _content;
        public Material _highlight;
        public Material _default;
        public int _currentSelected;
        public int _currentCount;
        public bool _isHighlight;
        public int[] _countMesh ;
        public MaterialsList _materialsList;

        private void Awake()
        {
            _countMesh = _materialsList._countOfMesh.ToArray();
        }

        public void HighlightMesh(int number, int count)
        {
            for (int i = 0; i < count; i++)
            {
                bool isColored = _content[number].GetChild(i).GetComponent<ObjectNumber>()._colored;

                if (isColored == false)
                {
                    _content[number].GetChild(i).GetComponent<MeshRenderer>().material = _highlight;
                    _content[number].GetChild(i).GetComponent<Collider>().enabled = true;
                } 
            }

            _isHighlight = true;
            _currentSelected = number;
            _currentCount = count;
        }

        public void DefaultMesh(int number, int count)
        {
            for (int i = 0; i < _currentCount; i++)
            {
                bool isColored = _content[_currentSelected].GetChild(i).GetComponent<ObjectNumber>()._colored;

                if (isColored == false)
                {
                    _content[_currentSelected].GetChild(i).GetComponent<MeshRenderer>().material = _default;
                    _content[_currentSelected].GetChild(i).GetComponent<Collider>().enabled = false;
                }
            }
        }
    }
}