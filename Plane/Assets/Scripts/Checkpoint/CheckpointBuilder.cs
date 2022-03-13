using System.Collections;
using System.Collections.Generic;
using Sample;
using UnityEngine;

public class CheckpointBuilder : ICheckpointBuilder
{
    private Material material;
    private bool chngeMterial;
    private bool setInteractable;
    private bool setBonus;


    public ICheckpointBuilder ChangeMaterial(Material mat)
    {
        material = mat;
        chngeMterial = true;
        return this;
    }

    public ICheckpointBuilder Interactable()
    {
        setBonus = false;
        setInteractable = true;
        return this;
    }

    public ICheckpointBuilder Bonus()
    {
        setInteractable = false;
        setBonus = true;
        return this;

    }

    public GameObject Build(IPrototype prototype)
    {
        if (prototype != null)
        {
            var checkpoint = prototype.Clone();
            if (setInteractable)
            {
                checkpoint.gameObject.AddComponent<Checkpoint>();
            }

            if (chngeMterial)
            {
                checkpoint.gameObject.GetComponent<MeshRenderer>().material = material;
               
            }

            return checkpoint.gameObject;
        }

        return null;
    }
}