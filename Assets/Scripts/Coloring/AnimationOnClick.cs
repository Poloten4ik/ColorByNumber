using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Assets.Scripts.Coloring
{
    public class AnimationOnClick : MonoBehaviour
    {
        private Vector3 _oldScale;
        public Vector3 _newScale;
        public bool _water;

        public void StartAnimation()
        {
            _oldScale = transform.localScale;
            transform.DOScale(new Vector3(transform.localScale.x - _newScale.x , transform.localScale.y - _newScale.y,transform.localScale.z - _newScale.z), 0.3f);
            StartCoroutine(StopAnimation());
        }

        public IEnumerator StopAnimation()
        {
            yield return new WaitForSeconds(0.3f);
            transform.DOScale(_oldScale, 0.3f);
        }
    }
}
