using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.Victory
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        private void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}