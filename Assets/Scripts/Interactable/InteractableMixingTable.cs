using UnityEngine;

public class InteractableMixingTable : MonoBehaviour, IInteractable
{
    [SerializeField] Camera _mainCamera;
    public EInteractable InteractableType => EInteractable.MIXING_TABLE;

    public bool IsCurrentlyInteractable => true;

    public void StartInteracting()
    {
        // Change caméra 
        _mainCamera.gameObject.SetActive(false);
        Cursor.visible = true;
        Managers.ShouldDisplayInteractable = false;
    }

    public void StopInteracting()
    {
    }
}
