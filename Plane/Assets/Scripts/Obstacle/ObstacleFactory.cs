using UnityEngine;


public class ObstacleFactory : MonoBehaviour,IObstacleFactory
{
    [SerializeField] private GameObject[] obstaclePrefabs;

    public GameObject Create(int difficulty)=>Instantiate(obstaclePrefabs[difficulty]);

}