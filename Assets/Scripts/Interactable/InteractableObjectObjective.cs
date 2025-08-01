using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectObjectiveInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string _idName;
    
    public EInteractable InteractableType => EInteractable.OBJECT_OBJECTIVE;

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
