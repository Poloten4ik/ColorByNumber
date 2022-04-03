using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Assets.Scripts.Menu
{
    public class RotateObjectMenu : MonoBehaviour
    {
        public float _duration;

        public Vector3 _rotateAngle;

        private void Start()
        {
            transform.DORotate(_rotateAngle, _duration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        }
    }
}