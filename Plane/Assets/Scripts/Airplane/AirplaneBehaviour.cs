using UnityEngine;

public class AirplaneBehaviour : MonoBehaviour
{
    [SerializeField] private AirplaneController _airplaneController;
    [SerializeField] private EventeController _eventeController;
    private const string checkpointTag = "Checkpoint";
    private const string obstalceTag = "Obstacle";


    private void OnEnable()
    {
        _eventeController.GameStart += Activate;
       // _eventeController.PlayerWin += AirplaneWin;
        _eventeController.Restart += Activate;
        _eventeController.AirplaneDeactivate += Deactivate;
        // _eventeController.ExitToMainMenu += Deactivate;
        // _eventeController.PlayerLoose += Deactivate;
    }

    private void OnDestroy()
    {
        if (_airplaneController != null)
        {
            _eventeController.GameStart -= Activate;
           // _eventeController.PlayerWin -= AirplaneWin;
            _eventeController.Restart -= Activate;
            _eventeController.AirplaneDeactivate -= Deactivate;
            // _eventeController.ExitToMainMenu -= Deactivate;
            // _eventeController.PlayerLoose -= Deactivate;
        }
    }


    private void Start()
    {
        //Activate();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(checkpointTag))
        {
            _eventeController.AddScorePointsInvoke(other.gameObject.GetComponent<Checkpoint>().pointsAmount);
            _eventeController.CheckpointCrossingInvoke();
            return;
        }

        if (other.gameObject.CompareTag(obstalceTag))
        {
            _eventeController.GameEndInvoke(false,"Plane crashed");
            //Deactivate();
        }
    }

    private void Deactivate()
    {
        _airplaneController.Deactivate();
        gameObject.SetActive(false);
    }

    private void Activate()
    {
        _airplaneController.Activate();
        gameObject.SetActive(true);
    }

    // private void AirplaneWin()
    // {
    //     _airplaneController.Deactivate();
    // }
}