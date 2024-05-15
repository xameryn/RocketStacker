using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProperties : MonoBehaviour
{
    static public string rocketName = "Falcon 9";
    static public float emptyMass = 25600f; // kg
    static public float fueledMass = 395700f; // kg
    static public float thrust = 7607000f; // Newtons
    static public float specificImpulse = 283f; // seconds
    private float airspeed = 0f; // m/s
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        airspeed = rb.velocity.magnitude;
    }
}
