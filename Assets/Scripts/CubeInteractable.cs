using UnityEngine;

public class CubeInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _playerObjectPosition;
    [SerializeField] private string _idName;

    public EnumInteractable InteractableType => EnumInteractable.OBJECT;
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
