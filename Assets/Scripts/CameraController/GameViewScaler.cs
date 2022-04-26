using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Assets.Scripts.CameraController
{
    public class GameViewScaler : MonoBehaviour
    {
        public float _2280ResolutionSize;
        public float _2160ResolutionSize;
        public float _1920ResolutionSize;
        public float _2560ResolutionSize;

        public float _maxSize;
        public Camera _cameraMain;

        private void Awake()
        {
            var resolution = (double)Screen.width / Screen.height;
            ScaleWithoutAds(resolution);

            _maxSize = _cameraMain.orthographicSize;

        }

        private void ScaleWithoutAds(double resolution)

        {
            if (resolution < 0.49)
            {
                _cameraMain.orthographicSize = _2280ResolutionSize;
                print("2280x1080");
            }

            else if (0.49 <= resolution && resolution < 0.53)
            {
                _cameraMain.orthographicSize = _2160ResolutionSize;
                print("2160x1080");
            }

            else if (0.53 <= resolution && resolution < 0.58)
            {
                _cameraMain.orthographicSize = _1920ResolutionSize;
                print("1920x1080");
            }
            else
            {
                _cameraMain.orthographicSize = _2560ResolutionSize;
                print("2560x1600");
            }

        }
    }
}