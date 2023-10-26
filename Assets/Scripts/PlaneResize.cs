
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlaneResize : UdonSharpBehaviour
{
    public float Height = 2f;
    public bool start = false;
    public float speed = 0.01f;  // Adjust this value to control the speed of the movement
    private Vector3 startPosition;
    private float t = 0;
    

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        if (start)
        {
            t += speed * Time.deltaTime;  // Increment t
            transform.localPosition = Vector3.Lerp(startPosition, new Vector3(startPosition.x, Height, startPosition.z), t);  // Move the platform

            if (t >= 1)  // When t reaches 1, the platform has reached the target position
            {
                start = false;
            }
        }
    }
    public void StartMoving()
    {
        startPosition = transform.localPosition;
        start = true;
    }

}
