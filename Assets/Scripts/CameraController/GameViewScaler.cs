using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Assets.Scripts.CameraController
{
    public class GameViewScaler : MonoBehaviour
    {

        public void Start()
        {
            var resolution = (double)Screen.width / Screen.height;
            ScaleWithoutAds(resolution);
        }

        private void ScaleWithoutAds(double resolution)

        {
            if (resolution < 0.49)
            {
                print("2280x1080");
            }

            else if (0.49 <= resolution && resolution < 0.53)
            {
                print("2160x1080");
            }

            else if (0.53 <= resolution && resolution < 0.58)
            {
                print("1920x1080");
            }
            else
            {
                print("2560x1600");
            }

        }
    }
}