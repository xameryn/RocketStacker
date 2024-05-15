using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float force = 100000f; // Newtons
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Renderer renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForceAtPosition(-Vector2.right * force, transform.position + transform.up * GetComponent<Renderer>().bounds.size.y/2);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForceAtPosition(Vector2.right * force, transform.position + transform.up * GetComponent<Renderer>().bounds.size.y/2);
        }
    }
}
