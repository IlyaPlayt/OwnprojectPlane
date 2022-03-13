
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using Sample;
using UnityEngine;

public class ScoreController : MonoBehaviour, IScoreInformation
{
    [SerializeField] private EventeController _eventeController;
    private float timeLimit = 100;
    public float currentTime { get; private set; }
    public IScoreInformation _ScoreInformation;

    private bool gameIsActive;
    private int[] besteScore;


    private void OnEnable()
    {
        _eventeController.StopTime += StopTime;
        _eventeController.AddScorePoints += AddTime;
        _eventeController.StartTime += RestartTime;
        
        // _eventeController.PlayerWin += checkRecord;
    }

    private void OnDisable()
    {
        _eventeController.StopTime -= StopTime;
        _eventeController.AddScorePoints -= AddTime;
        _eventeController.StartTime -= RestartTime;
        
        // _eventeController.PlayerWin -= checkRecord;
    }

    private void Start()
    {
        gameIsActive = false;

        _ScoreInformation = this;
        _ScoreInformation = new PraiseScore(_ScoreInformation);
        ///////
        //  besteScore = new int[] {0, 0, 0};
        // SaveData();
        // LoadGame();
        // if (besteScore == null)
        // {
        //     besteScore = new int[] {0, 0, 0};
        //     SaveData();
        // }

        // foreach (var val in besteScore)
        // {
        //     Debug.Log(val);
        // }
    }

    private void Update()
    {
        if (!gameIsActive) return;
        if (currentTime <= 0)
        {
            _eventeController.GameEndInvoke(false, "Out of time");
        }

        currentTime -= Time.deltaTime;
    }

    private void ResetTime()
    {
        currentTime = timeLimit;
    }

    public void AddTime(int time)
    {
        currentTime += time;
    }

    private void StopTime()
    {
        gameIsActive = false;
    }

    private void RestartTime()
    {
        _ScoreInformation.ShowScore();
        ResetTime();
        gameIsActive = true;
    }

    private void CheckRecord()
    {
        bool newRecord = true;

        for (int i = 0; i < besteScore.Length; i++)
        {
            if (currentTime > besteScore[i])
            {
                var temp = besteScore[i];
                besteScore[i] = (int) currentTime;
                for (int j = i + 1; j < besteScore.Length; j++)
                {
                    (besteScore[j], temp) = (temp, besteScore[j]);
                }

               
                //SaveData();
                return;
            }
        }
    }

    private void SaveData()
    {
        Debug.Log("Save");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BestScore.dat");
        Records data = new Records();
        data.BestScores = besteScore;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    void LoadData()
    {
        if (File.Exists(Application.persistentDataPath
                        + "/BestScore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                File.Open(Application.persistentDataPath
                          + "/BestScore.dat", FileMode.Open);
            Records data = (Records) bf.Deserialize(file);
            file.Close();
            besteScore = data.BestScores;
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data! Creating new data(0,0,0");
            besteScore = new int[] {0, 0, 0};
            //SaveData();
        }
    }


    public class Records
    {
        public int[] BestScores;
    }

    public void ShowScore()
    {
        Debug.Log(currentTime);
    }
}