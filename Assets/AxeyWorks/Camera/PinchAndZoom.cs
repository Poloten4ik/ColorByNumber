using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchAndZoom : MonoBehaviour
{
    public float MouseZoomSpeed = 0.1f;
    public float TouchZoomSpeed = 0.1f;
    public float ZoomMinBound = 1;
    public float ZoomMaxBound = 2;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {

                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, TouchZoomSpeed);
            }
        }
        else
        {

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log("scroll =" + scroll);
            Zoom(scroll, MouseZoomSpeed);
        }



        if (cam.orthographicSize < ZoomMinBound)
        {
            cam.orthographicSize = 1;
        }
        else
        if (cam.orthographicSize > ZoomMaxBound)
        {
            cam.orthographicSize = 2;
        }
    }

    void Zoom(float deltaMagnitudeDiff, float speed)
    {

        //cam.fieldOfView += deltaMagnitudeDiff * speed;
        cam.orthographicSize += deltaMagnitudeDiff * speed;
        Debug.Log("cam.orthographicSize =" + cam.orthographicSize);
        // set min and max value of Clamp function upon your requirement
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, ZoomMinBound, ZoomMaxBound);

        
    }
}