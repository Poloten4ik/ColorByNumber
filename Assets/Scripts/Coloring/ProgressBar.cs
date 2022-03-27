using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.Coloring
{
    public class ProgressBar : MonoBehaviour
    {
        public Image _progressImage;
        public MaterialsList _materialsList;
        public SelectedMesh _selectedMesh;

        private float _progress;
        public void UpdateProgressBar(int count)
        {
            float diff = (float)_selectedMesh._countMesh[count] - _materialsList._countOfMesh[count];

            _progress = diff / (float)_selectedMesh._countMesh[count];
            _progressImage.fillAmount = _progress;
        }
        public void UpdateBar(int count)
        {
            float diff = (float)_selectedMesh._countMesh[count] - _materialsList._countOfMesh[count];

            _progress = diff / (float)_selectedMesh._countMesh[count];
            StartCoroutine(ProgressAnimation());
        }

        public IEnumerator ProgressAnimation()
        {
            while (_progressImage.fillAmount < _progress)
            {
                _progressImage.fillAmount += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}