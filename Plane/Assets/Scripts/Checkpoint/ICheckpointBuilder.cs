using UnityEngine;

public interface ICheckpointBuilder
{
    ICheckpointBuilder ChangeMaterial(Material mat);
    ICheckpointBuilder Interactable();
    ICheckpointBuilder Bonus();

    GameObject Build(IPrototype prototype);
}