using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Assets.Scripts.Victory
{
    public class VictoryScale : MonoBehaviour
    {
        public Vector3 _newScale;
        void Start()
        {
            transform.DOScale(_newScale, 1f);
        }
    }
}