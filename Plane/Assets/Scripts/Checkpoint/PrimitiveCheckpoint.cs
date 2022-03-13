using UnityEngine;


public class PrimitiveCheckpoint : MonoBehaviour, IPrototype
{
    public GameObject Clone()
    {
        return Instantiate(gameObject);
    }
}