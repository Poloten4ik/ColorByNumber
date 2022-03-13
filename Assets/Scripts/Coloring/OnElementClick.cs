﻿using System.Collections;
using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Coloring
{
    public class OnElementClick : MonoBehaviour
    {
        [SerializeField] private MaterialsList _materialsList;
        [SerializeField] private SelectedColor _selectedColor;
        private Camera _camera;

        public string _scene;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = _camera.ScreenPointToRay(Input.touches[0].position);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        int materialNumber = hit.collider.GetComponent<ObjectNumber>()._objectNumber;

                        if (materialNumber == _selectedColor._selectedColorNumber)
                        {
                            hit.collider.GetComponent<MeshRenderer>().material = _materialsList._material[materialNumber];

                            var animationOnClick = hit.collider.GetComponent<AnimationOnClick>();

                            if (animationOnClick != null)
                            {
                                animationOnClick.StartAnimation();
                            }

                            hit.collider.GetComponent<ObjectNumber>()._colored = true;
                            string materialCount = hit.collider.GetComponent<ObjectNumber>()._objectCount.ToString();
                            PlayerPrefs.SetInt(_scene + materialCount, hit.collider.GetComponent<ObjectNumber>()._objectCount);

                            hit.collider.enabled = false;
                            if (_materialsList._countOfMesh[materialNumber] > 0)
                            {
                                _materialsList._countOfMesh[materialNumber]--;

                                _materialsList.CompletedCheck();
                                PlayerPrefs.SetInt(_scene + materialNumber.ToString() + " countOfMesh", _materialsList._countOfMesh[materialNumber]);

                                if (_materialsList._countOfMesh[materialNumber] == 0)
                                {
                                    _selectedColor.ColorCompleted(materialNumber);
                                    PlayerPrefsExtensions.SetBool(_scene + materialNumber + " button", true);
                                }
                            }
                        }
                    }
                }
            }

#if UNITY_EDITOR

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        int materialNumber = hit.collider.GetComponent<ObjectNumber>()._objectNumber;

                        if (materialNumber == _selectedColor._selectedColorNumber)
                        {
                            hit.collider.GetComponent<MeshRenderer>().material = _materialsList._material[materialNumber];
                            var animationOnClick = hit.collider.GetComponent<AnimationOnClick>();

                            if (animationOnClick != null)
                            {
                                animationOnClick.StartAnimation();
                            }

                            hit.collider.GetComponent<ObjectNumber>()._colored = true;
                            string materialCount = hit.collider.GetComponent<ObjectNumber>()._objectCount.ToString();

                            PlayerPrefs.SetInt(_scene + materialCount, hit.collider.GetComponent<ObjectNumber>()._objectCount);

                            hit.collider.enabled = false;
                            if (_materialsList._countOfMesh[materialNumber] > 0)
                            {
                                _materialsList._countOfMesh[materialNumber]--;

                                _materialsList.CompletedCheck();
                                PlayerPrefs.SetInt(_scene + materialNumber.ToString() + " countOfMesh", _materialsList._countOfMesh[materialNumber]);

                                if (_materialsList._countOfMesh[materialNumber] == 0)
                                {
                                    _selectedColor.ColorCompleted(materialNumber);
                                    PlayerPrefsExtensions.SetBool(_scene + materialNumber + " button", true);
                                }
                            }
                        }
                    }
                }
            }
#endif
        }
    }
}