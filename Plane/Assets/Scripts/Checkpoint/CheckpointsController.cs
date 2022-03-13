using System;
using System.Linq;
using Sample;
using UnityEngine;

public class CheckpointsController : MonoBehaviour
{
    [SerializeField] private EventeController _eventeController;
    [SerializeField] private PointsController _pointsController;
    [SerializeField] private Transform[] TrainingCheckpoints;
    [SerializeField] private Material interactableCheckpointMaterial;
    [SerializeField] private GameObject primitiveCheckpoint;

    private Transform[] checkpointPositions;
    private GameObject InteractableCheckpoint;
    private int currentPositionIndex;
    private int[] checkpointValues;

    private void OnEnable()
    {
        _eventeController.CheckpointCross += SetCheckpoint;
        _eventeController.Restart += ResetCheckpoints;
        _eventeController.GameStart += GameStart;
    }

    private void OnDisable()
    {
        _eventeController.CheckpointCross -= SetCheckpoint;
        _eventeController.Restart -= ResetCheckpoints;
        _eventeController.GameStart -= GameStart;
    }

    void Start()
    {
        ICheckpointBuilder checkpoint =
            new CheckpointBuilder().ChangeMaterial(interactableCheckpointMaterial).Interactable();
        InteractableCheckpoint = checkpoint.Build(primitiveCheckpoint.GetComponent<PrimitiveCheckpoint>());

        // ResetCheckpoints();
    }

    private void GameStart()
    {
        CreateWay();
        ResetCheckpoints();
    }

    private void SetCheckpoint()
    {
        InteractableCheckpoint.transform.position = primitiveCheckpoint.transform.position;

        if (currentPositionIndex < checkpointPositions.Length)
        {
            primitiveCheckpoint.transform.position = checkpointPositions[currentPositionIndex].position;
            InteractableCheckpoint.GetComponent<Checkpoint>().pointsAmount = checkpointValues[currentPositionIndex - 1];
        }
        else
        {
            if (currentPositionIndex > checkpointPositions.Length)
            {
                _eventeController.GameEndInvoke(true);
            }
        }

        currentPositionIndex++;
    }

    private void CreateWay()
    {
        var points = _pointsController.points;
        var trainingCount = TrainingCheckpoints.Length;

        checkpointPositions = new Transform[TrainingCheckpoints.Length + _pointsController.points.Length];

        for (int i = 0; i < trainingCount; i++)
        {
            checkpointPositions[i] = TrainingCheckpoints[i];
        }

        for (int i = trainingCount; i < checkpointPositions.Length; i++)
        {
            checkpointPositions[i] = points[i - trainingCount];
        }
    }

    public void GetPointValues(int[] values)
    {
        checkpointValues = new int[TrainingCheckpoints.Length + values.Length];
        var dif = checkpointValues.Length - values.Length;
        for (int i = 0; i < dif; i++)
        {
            checkpointValues[i] = 0;
        }

        for (int i = dif; i < checkpointValues.Length; i++)
        {
            checkpointValues[i] = values[i - dif] + 1;
        }
    }

    private void ResetCheckpoints()
    {
        currentPositionIndex = 1;
        primitiveCheckpoint.transform.position = checkpointPositions[0].position;
        SetCheckpoint();
    }
}