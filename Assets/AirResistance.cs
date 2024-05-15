using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirResistance : MonoBehaviour
{
    public float dragCoefficient = 0.5f; // Drag coefficient of a sphere
    private Rigidbody2D rb;
    private Ascend ascend;
    private float width;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ascend = GetComponent<Ascend>();

        // Get the width and height of the bounding box
        width = GetComponent<Renderer>().bounds.size.x;
        height = GetComponent<Renderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = rb.velocity.magnitude; // velocity of the object
        float altitude = transform.position.y; // altitude of the object

        if (velocity < 0.01) velocity = 0;

        // angle of object relative to direction of travel
        // float objectAngle = Math.Abs(Math.Abs(Vector2.SignedAngle(transform.up, rb.velocity.normalized)) - 45); // 0 - 45 degrees

        float objectAngle = Math.Abs(Vector2.SignedAngle(transform.up, rb.velocity.normalized)); // 180 - 180 degrees

        objectAngle /= 180; // Normalize the angle to 0 - 1

        if (objectAngle > 0.5) objectAngle = 1 - objectAngle; // 0 - 0.5

        objectAngle *= 2; // 0 - 1

        // Calculate the cross-sectional area based on the actual orientation of the object
        float crossSectionalArea = (width * (1 - objectAngle)) + (height * objectAngle);

        float airDensity = Mathf.Lerp(1.225f, 0, altitude / 100000f); // air density at the given altitude
        
        float dragForceMagnitude = 0.5f * dragCoefficient * crossSectionalArea * Mathf.Pow(velocity, 2) * airDensity; // magnitude of the drag force

        float terminalVelocity = Mathf.Sqrt(2 * rb.mass * Mathf.Abs(Physics2D.gravity.y) / (airDensity * crossSectionalArea * dragCoefficient)); // terminal velocity of the object

        // Debug.Log("CSA:              " + crossSectionalArea);
        // Debug.Log("Drag Force Mag:   " + dragForceMagnitude);
        // Debug.Log("Velocity:         " + velocity);
        // Debug.Log("Terminal Velocity:" + terminalVelocity);
        
        Vector2 dragForce = -rb.velocity.normalized * dragForceMagnitude; // drag force vector
        Vector2 momentum = rb.mass * rb.velocity; // momentum vector

        // Draw the drag force vector in the Scene view
        Debug.DrawRay(transform.position, dragForce * 0.001f, Color.red);
        Debug.DrawRay(transform.position, momentum * 0.001f, Color.blue);

        rb.AddForce(dragForce); // Apply the drag force

        // Limit the velocity to the terminal velocity if not under thrust
        if (!ascend.isThrusting && velocity > terminalVelocity)
        {
            // rb.velocity = rb.velocity.normalized * terminalVelocity;
            rb.velocity *= 0.99f;
        }
    }
}
