using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascend : MonoBehaviour
{
    public float fuel;
    public float fuelConsumptionRate;
    private Rigidbody2D rb;
    public RocketProperties RocketProperties;
    public bool isThrusting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RocketProperties = GetComponent<RocketProperties>(); // Add this line

        fuel = RocketProperties.fueledMass - RocketProperties.emptyMass; // Modify this line

        // Calculate the fuel consumption rate
        float g = 9.81f; // Acceleration due to gravity in m/s²
        fuelConsumptionRate = RocketProperties.thrust / (g * RocketProperties.specificImpulse); // Modify this line
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            Vector2 thrustDirection = transform.up;
            rb.AddForce(thrustDirection * RocketProperties.thrust); // Modify this line
            fuel -= fuelConsumptionRate * Time.deltaTime;
            isThrusting = true;
        }
        else
        {
            isThrusting = false;
        }

        rb.mass = RocketProperties.emptyMass + fuel; // Modify this line
    }
}