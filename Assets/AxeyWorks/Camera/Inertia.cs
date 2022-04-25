using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inertia : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] [Range(0, 360)] private int maxRotationInOneSwipe = 180;

    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;

    public Vector3 speed;
    public Vector3 avgSpeed;
    public bool dragging = false;
    private Vector3 targetSpeedX;
    public float rotationSpeedTouch;
    public float rotationSpeedMouse;
    public float movingYKoef;
    public float lerpSpeed;

    private float minYPos;
    private float maxYPos;
    public float moveYDelta;
    public float swipeMinMove = 2;

    Touch theTouch;

    public Vector3 previousPosition;
    public Vector3 startPosition;
    public Transform refObject;
    public Vector3 startTouchPosition;
    void Start()
    {
        dragging = false;

        minYPos = transform.position.y - moveYDelta;
        maxYPos = transform.position.y + moveYDelta;

    }

    void Update()
    {
        float rotationSpeed = 0;

        if (Input.touchSupported)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the game object
                m_PointerEventData.position = Input.GetTouch(0).position;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                if (results.Count < 0)
                {
                    Debug.Log("Hit " + results[0].gameObject.name);
                    return;
                }

                startTouchPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                //dragging = true;
                //previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.touchCount == 1 && !dragging)
            {
                Vector3 currentPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                float distance = Vector3.Distance(startPosition, currentPosition);

                if (distance > swipeMinMove)
                    dragging = true;
            }
            else if (Input.touchCount == 1 && dragging)
            {
                theTouch = Input.GetTouch(0);
                speed = new Vector3(theTouch.deltaPosition.x, theTouch.deltaPosition.y, 0);
                avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 5);
            }
            else
            {
                if (Input.touchCount == 0 && dragging)
                {
                    speed = avgSpeed;
                    dragging = false;
                }
                var i = Time.deltaTime * lerpSpeed;
                speed = Vector3.Lerp(speed, Vector3.zero, i);
            }

            rotationSpeed = rotationSpeedTouch;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the game object
                m_PointerEventData.position = Input.mousePosition;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                if (results.Count > 0)
                {
                    Debug.Log("Hit " + results[0].gameObject.name);
                    return;
                }

                startTouchPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                //dragging = true;
                //previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0) && !dragging)
            {
                Vector3 currentPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                float distance = Vector3.Distance(startPosition, currentPosition);

                if (distance > swipeMinMove)
                    dragging = true;
            }
            else if(Input.GetMouseButton(0) && dragging)
            {
                speed = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
                avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 5);
            }
            else
            {
                if (dragging)
                {
                    speed = avgSpeed;
                    dragging = false;
                }
                var i = Time.deltaTime * lerpSpeed;
                speed = Vector3.Lerp(speed, Vector3.zero, i);
            }

            rotationSpeed = rotationSpeedMouse;
        }


        Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = previousPosition - newPosition;

        float rotationAroundYAxis = speed.x * rotationSpeed; // camera moves horizontally
        float rotationAroundXAxis = speed.y * rotationSpeed; // camera moves vertically

        cam.transform.RotateAround(target.position, new Vector3(0, 1, 0), rotationAroundYAxis); // <— This is what makes it work!
        

        //if (dragging)
        //    cam.transform.Translate(new Vector3(0, direction.y * 3, 0));
        cam.transform.Translate(new Vector3(0, rotationAroundXAxis * -1.0f * movingYKoef, 0), Space.World);
        if (cam.transform.position.y < minYPos)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, minYPos, cam.transform.position.z);
        }
        else if (cam.transform.position.y > maxYPos)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, maxYPos, cam.transform.position.z);
        }

        previousPosition = newPosition;

        //refObject.Rotate(Vector3.up * speed.x * rotationSpeed, Space.World);
    }
}