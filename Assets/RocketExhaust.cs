using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExhaust : MonoBehaviour
{
    private new ParticleSystem particleSystem;
    private Ascend ascend;

    void Start()
    {
        ascend = GetComponent<Ascend>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        ParticleSystem.EmissionModule emission = particleSystem.emission;

        if (ascend.isThrusting)
        {
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }
}