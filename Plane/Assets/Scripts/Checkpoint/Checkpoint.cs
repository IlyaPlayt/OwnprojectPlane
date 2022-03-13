using System;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    private const string checkpointTag = "Checkpoint";
    public int pointsAmount;

    private void Awake()
    {
        gameObject.tag = checkpointTag;
    }
    
}