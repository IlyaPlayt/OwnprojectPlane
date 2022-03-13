using System;
using System.Collections;
using System.Collections.Generic;
using Sample;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private EventeController _eventeController;
    [SerializeField] private PointsController _pointsController;
    [SerializeField] private ObstacleFactory _obstacleFactory;
    [SerializeField] private CheckpointsController _checkpointsController;


    private Transform[] obstaclePoints;
    private GameObject[] obstacles;
    private int[] pointValues;

    private void OnEnable()
    {
        _eventeController.Restart += SetObstacle;
        _eventeController.GameStart += GameStart;
    }

    private void OnDisable()
    {
        _eventeController.Restart -= SetObstacle;
        _eventeController.GameStart -= GameStart;
    }


    private void GameStart()
    {
        if (obstacles != null) RemoveObstacles();
        obstaclePoints = _pointsController.points;
        obstacles = new GameObject[obstaclePoints.Length];
        pointValues = new int[obstaclePoints.Length];

        SetObstacle();
    }

    private void SetObstacle()
    {
        if (obstacles[0] != null) RemoveObstacles();

        for (int i = 0; i < obstaclePoints.Length; i++)
        {
            obstacles[i] = GetObstacle(ref pointValues[i]);
            obstacles[i].transform.position = obstaclePoints[i].position;
            obstacles[i].transform.rotation = obstaclePoints[i].rotation;
        }

        _checkpointsController.GetPointValues(pointValues);
    }

    private void RemoveObstacles()
    {
        foreach (var obst in obstacles)
        {
            Destroy(obst.gameObject);
        }
    }

    private GameObject GetObstacle(ref int pointsAmount)
    {
        pointsAmount = Random.Range(0, 4);
        return _obstacleFactory.Create(pointsAmount);
    }
}