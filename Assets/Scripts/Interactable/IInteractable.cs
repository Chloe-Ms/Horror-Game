using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    EInteractable InteractableType { get; }

    bool IsCurrentlyInteractable { get; }

    void StartInteracting();

    void StopInteracting();
}