using UnityEngine;

public class ExitMixingTable : MonoBehaviour, IMixingInteractable
{
    [SerializeField] Camera _mainCamera;

    public void Interact()
    {
        _mainCamera.gameObject.SetActive(true);
        Cursor.visible = false;
        Managers.ShouldDisplayInteractable = true;
    }
}
