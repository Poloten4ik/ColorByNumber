using Assets.Scripts.Menu;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LoadPrefab : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objects;

        void Start()
        {
            int number = FindObjectOfType<LoadScene>()._number;
            Instantiate(_objects[number], _objects[number].transform.position, Quaternion.identity); 
        }

        void Update()
        {

        }
    }
}