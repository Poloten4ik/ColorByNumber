using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Coloring
{
    public class SelectedColor : MonoBehaviour
    {
        public int _selectedColorNumber;
        public List<GameObject> _buttonsList;
     
        public ScrollRect _scrollRect;

        public Sprite _selected;
        public Sprite _default;
        public Sprite _completed;

        public void ChangeColor(int number)
        {
            _selectedColorNumber = number;

            foreach(Transform item in _scrollRect.content.transform)
            {
                if (item.GetComponent<Button>().enabled)
                {
                    item.GetComponent<Image>().sprite = _default;
                }
            }

            _buttonsList[number].GetComponent<Image>().sprite = _selected;
        }

        public void ColorCompleted(int number)
        {
            //var x = _buttonsList.First();
            //_buttonsList.RemoveAt(number);
            //_buttonsList.Add(x);
            _buttonsList[number].transform.SetAsLastSibling();
            _buttonsList[number].GetComponent<Button>().enabled = false;
            _buttonsList[number].GetComponent<Image>().sprite = _completed;
            _buttonsList[number].GetComponentInChildren<Text>().enabled = false;
        }
    }
}