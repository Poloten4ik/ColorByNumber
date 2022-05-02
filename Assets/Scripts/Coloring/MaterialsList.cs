using Assets.Scripts.CameraController;
using Assets.Scripts.Victory;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Coloring
{
    public class MaterialsList : MonoBehaviour
    {
        public Material[] _material;
        public Material _defaultMaterial;
        public Color[] _color;
        public int[] _countOfMesh;
        public int _allMeshes;
        public Text _completed;

        public float _progressColoringTime;

        [SerializeField] private OnElementClick _onElementClick;
        [SerializeField] private Inertia _inertia;
        [SerializeField] private PinchAndZoom _pinchAndZoom;
        [SerializeField] private Rotator _rotator;
        [SerializeField] private GameViewScaler _gameViewScaler;
        [SerializeField] private Data _data;
        [SerializeField] private GameObject _scrollColors;
        [SerializeField] private GameObject _downPos;
        [SerializeField] private GameObject _victory;
        [SerializeField] private GameObject _homeButton;
        [SerializeField] private GameObject _buttonNext;
        [SerializeField] private Animator _nextButton;

        [SerializeField] private Camera _cameraMain;
        [SerializeField] private Camera _cameraFinish;

        public float _zoomSizeFinish;

        void Start()
        {
            for (int j = 0; j < _countOfMesh.Length; j++)
            {
                if (PlayerPrefs.HasKey(_onElementClick._scene + j.ToString() + " countOfMesh"))
                {
                    int count = PlayerPrefs.GetInt(_onElementClick._scene + j.ToString() + " countOfMesh");
                    _countOfMesh[j] = count;
                }
            }

            for (int i = 0; i < _countOfMesh.Length; i++)
            {
                _allMeshes += _countOfMesh[i];
            }

            HideScroll();
        }

        public void CompletedCheck(string scene)
        {
            _allMeshes--;

            if (_allMeshes <= 0)
            {
                Completed();
                PlayerPrefsExtensions.SetBool("completed" + scene, true);
            }
        }


        public void Completed()
        {
            _scrollColors.transform.DOMove(_downPos.transform.position, 0.5f);
            _homeButton.SetActive(false);
            _cameraMain.transform.DOMove(_cameraFinish.transform.position, 2f);
            _cameraMain.transform.DORotate(_cameraFinish.transform.rotation.eulerAngles, 2f);
            _pinchAndZoom.enabled = false;
            _inertia.enabled = false;

            StartCoroutine(ZoomUpdate());
        }

        public IEnumerator ZoomUpdate()
        {
            while (_cameraMain.orthographicSize < _gameViewScaler._maxSize)
            {
                _cameraMain.orthographicSize += 0.5f;
                yield return new WaitForSeconds(0.01f);
            }

            StartCoroutine(UnColor());
        }

        public IEnumerator UnColor()
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < _data._meshes.Length; i++)
            {
                int materialNumber = _data._meshes[i].GetComponent<ObjectNumber>()._objectNumber;
                var animation = _data._meshes[i].GetComponent<AnimationOnClick>();

                if (!animation._water)
                {
                    _data._meshes[i].GetComponent<MeshRenderer>().material.DOColor(_defaultMaterial.color, 0.5f);
                }
                else
                {
                    _data._meshes[i].GetComponent<MeshRenderer>().material = _material[materialNumber];
                }

            }
            StartCoroutine(ColorProcess());
        }

        public IEnumerator ColorProcess()
        {
            for (int i = 0; i < _data._meshes.Length; i++)
            {
                yield return new WaitForSeconds(_progressColoringTime);
                int materialNumber = _data._meshes[i].GetComponent<ObjectNumber>()._objectNumber;

                var animation = _data._meshes[i].GetComponent<AnimationOnClick>();

                if (!animation._water)
                {
                    _data._meshes[i].GetComponent<MeshRenderer>().material.DOColor(_color[materialNumber], 0.5f);
                }
                else
                {
                    _data._meshes[i].GetComponent<MeshRenderer>().material = _material[materialNumber];
                }

                if (i + 1 >= _data._meshes.Length)
                {
                    Victory();
                    _buttonNext.SetActive(true);
                    _nextButton.enabled = true;
                }
            }
        }

        public void NextScreen()
        {
            _nextButton.SetTrigger("Pressed");
        }

        public void Victory()
        {
            if (_victory != null)
            {
                _victory.SetActive(true);
                _rotator.enabled = true;
            }
       
        }

        public void HideScroll()
        {
            string hide = "completed" + _onElementClick._scene;

            if (PlayerPrefs.HasKey(hide))
            {
                _scrollColors.SetActive(false);
                Completed();
            }
        }
    }
}
