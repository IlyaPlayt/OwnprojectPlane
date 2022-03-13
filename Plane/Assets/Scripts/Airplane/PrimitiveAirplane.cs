using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveAirplane : MonoBehaviour, IPrototype
{
    public GameObject Clone()
    {
        return Instantiate(gameObject);
    }
    
}
