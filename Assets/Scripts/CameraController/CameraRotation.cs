using UnityEngine;
using System.Collections;

namespace Assets.Scripts.CameraController
{
    public class CameraRotation : MonoBehaviour
    {
        public float _speed;
        private Vector2 _swipeDelta;
        private float _deltaMin;

        public void Update()
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _swipeDelta = Vector2.zero;

                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Rotate(0, touchDeltaPosition.x * _speed, 0);
            }
        }
    }
}