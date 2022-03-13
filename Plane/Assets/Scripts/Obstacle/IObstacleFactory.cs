using UnityEngine;

public interface IObstacleFactory
{
    public GameObject Create(int difficulty);
}