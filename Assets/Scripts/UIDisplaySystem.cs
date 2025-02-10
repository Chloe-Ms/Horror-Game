using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplaySystem : MonoBehaviour
{
    [SerializeField] GameObject _textUIBlood;
    [SerializeField] GameObject _textUIObject;

    DetectObjects _detectObjects;

    private void Awake()
    {
        _detectObjects = FindObjectOfType<DetectObjects>();
        if (_detectObjects != null)
        {
            _detectObjects.OnChangeTarget += OnChangeTarget;
        }
    }

    private void ActivateDeactivate(EnumInteractable enumInteract, bool activate)
    {
        switch (enumInteract)
        {
            case EnumInteractable.BLOOD:
                _textUIBlood?.SetActive(activate);
                break;

            case EnumInteractable.OBJECT:
            case EnumInteractable.OBJECT_OBJECTIVE:
                _textUIObject?.SetActive(activate);
                break;
        }
    }

    private void OnChangeTarget(IInteractable lastInteractable, IInteractable currentInteractable)
    {
        if (lastInteractable != null && currentInteractable != null &&
            lastInteractable.InteractableType != currentInteractable.InteractableType) 
        {
            ActivateDeactivate(lastInteractable.InteractableType, false);
            ActivateDeactivate(currentInteractable.InteractableType, true);
        } 
        else if (currentInteractable != null || lastInteractable != null)
        {
            if (lastInteractable != null)
                ActivateDeactivate(lastInteractable.InteractableType, false);
            if (currentInteractable != null)
                ActivateDeactivate(currentInteractable.InteractableType, true);
        }
    }
}
