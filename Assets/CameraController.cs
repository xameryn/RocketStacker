using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // The game object the camera will follow
    public float zoomFactor = 75f; // Adjust this value to control the zoom level

    // Update is called once per frame
    void Update()
    {
        /*
        // Set the camera's position to the target object's position
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);

        // Calculate the distance from 0,0 to the target object
        float distance = Vector3.Distance(target.transform.position, new Vector3(0, -95, 0));

        // Smoothly transition the camera's orthographic size to the calculated distance
        // Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, distance * zoomFactor, Time.deltaTime);

        // zoom out so the camera's bottom is fixed at 0,0 and centered on the target object
        Camera.main.orthographicSize = zoomFactor * distance;
        Debug.Log("Distance: " + distance);
        */

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);

        Camera.main.orthographicSize = zoomFactor;
    }
}