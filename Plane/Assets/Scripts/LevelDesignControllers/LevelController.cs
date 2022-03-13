using System.Collections;
using System.Collections.Generic;
using Sample;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private EventeController _eventeController;
    [SerializeField] private Transform[] LevelsPoints;
    [SerializeField] private PointsController _pointsController;
    
    public int currentLevel;

    public void ChoseLevel(int levelNumber)
    {
        if (LevelsPoints[levelNumber] != null)
        {
            currentLevel = levelNumber;
            _pointsController.CreateWay(LevelsPoints[levelNumber]);
            _eventeController.GameStartInvoke();
        }
    }
}