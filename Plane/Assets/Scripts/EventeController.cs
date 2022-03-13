using System;
using Sample;
using UnityEngine;


public class EventeController : MonoBehaviour
{

    public event Action CheckpointCross ;
    public event Action<string> PlayerLoose;
    public event Action PlayerWin;
    public event Action GameStart;
    public event Action Restart;
    public event Action ExitToMainMenu;
    public event Action AirplaneDeactivate;
    
    // For ScoreController
    public event Action StopTime;
    public event Action StartTime;
    public event Action<int> AddScorePoints;


    public void CheckpointCrossingInvoke()
    {
        CheckpointCross?.Invoke();
    }

    public void AddScorePointsInvoke(int value)
    {
        AddScorePoints?.Invoke(value);
    }

    public void GameEndInvoke(bool win,string reasonOfLosing=null)
    {
        StopTime?.Invoke();
        AirplaneDeactivate?.Invoke();
        if (win)
        {
            PlayerWin?.Invoke();
            return;
        }
        PlayerLoose?.Invoke(reasonOfLosing);
    }

    public void GameEndInvoke()
    {
        
    }

    public void GameStartInvoke()
    {
        StartTime?.Invoke();
        GameStart?.Invoke();
    }

    public void RestartInvoke()
    {
        StartTime?.Invoke();
        Restart?.Invoke();
    }

    public void ExitToMainMenuInvoke()
    {
        AirplaneDeactivate?.Invoke();
        StopTime?.Invoke();
        ExitToMainMenu?.Invoke();
    }
}

