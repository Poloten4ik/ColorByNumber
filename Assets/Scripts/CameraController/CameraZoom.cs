using UnityEngine;
using System.Collections;

namespace Assets.Scripts.CameraController
{
    public class CameraZoom : MonoBehaviour
    {

        public Transform _targetToFollow;

        public float _zoomOutMix = 30;
        public float _zoomOutMax = 90;
        public float _speed;

        public void Update()
        {
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                Zoom(difference * _speed);
            }

            Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }

        public void Zoom(float increment)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, _zoomOutMix, _zoomOutMax);
        }
    }
}