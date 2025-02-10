using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObjectiveInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string _idName;
    
    public EnumInteractable InteractableType => EnumInteractable.OBJECT_OBJECTIVE;

    public string IDName => _idName;

    public bool IsCurrentlyInteractable => true;

    public void StartInteracting()
    {
        Managers.TidyingObjectsManager.PlaceObjectOnObjective(_idName);
    }

    public void StopInteracting()
    {
    }
}
