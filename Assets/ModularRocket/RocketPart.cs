using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RocketPart : MonoBehaviour
{
    public string partName;
    public float mass;
    public float drag;
    public PartType partType;
    public abstract void Activate();
}
