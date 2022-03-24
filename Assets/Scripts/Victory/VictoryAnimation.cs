using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Victory
{
    public class VictoryAnimation : MonoBehaviour
    {
        public Animation[] _animations;
        public GameObject[] _shader;

        public Shader _wind;

        void Start()
        {
            for (int i = 0; i < _animations.Length; i++)
            {
                _animations[i].enabled = true;
            }

            for (int j = 0; j < _shader.Length; j++)
            {
                _shader[j].GetComponent<MeshRenderer>().material.shader = _wind;
            }
        }
    }
}