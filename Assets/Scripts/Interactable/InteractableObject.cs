using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _playerObjectPosition;
    [SerializeField] private string _idName;

    public EInteractable InteractableType => EInteractable.OBJECT;
    public bool IsCurrentlyInteractable { get; set; } = true;
    public string IDName => _idName;

    public void StartInteracting()
    {
        transform.SetParent(_playerObjectPosition.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.layer = 0;
        Managers.TidyingObjectsManager.ActivateObjective(_idName);
    }


    public void StopInteracting()
    {
        //gameObject.layer = _layer;
    }
}
