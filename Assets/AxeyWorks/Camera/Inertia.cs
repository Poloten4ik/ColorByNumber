using UnityEngine;
using System.Collections;

public class Inertia : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] [Range(0, 360)] private int maxRotationInOneSwipe = 180;

    public Vector3 speed;
    public Vector3 avgSpeed;
    public bool dragging = false;
    private Vector3 targetSpeedX;
    public float rotationSpeedTouch;
    public float rotationSpeedMouse;
    public float movingYKoef;
    public float lerpSpeed;

    public float minYPos;
    public float maxYPos;

    Touch theTouch;

    public Vector3 previousPosition;
    public Transform refObject;

    void Start()
    {
        dragging = false;
    }

    void Update()
    {
        float rotationSpeed = 0;

        if (Input.touchSupported)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragging = true;
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.touchCount == 1 && dragging)
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
                dragging = true;
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0) && dragging)
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

        cam.transform.position = new Vector3(target.position.x, cam.transform.position.y, target.position.z);

        cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

        //if (dragging)
        //    cam.transform.Translate(new Vector3(0, direction.y * 3, 0));
            cam.transform.Translate(new Vector3(0, rotationAroundXAxis * -1.0f * movingYKoef, 0));
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