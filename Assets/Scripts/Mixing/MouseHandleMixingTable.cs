using UnityEditor;
using UnityEngine;

public class MouseHandleMixingTable : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask _layer;
    Vector3 position3D;
    Vector3 direction;

    void Update()
    {
        if (_camera != null && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane);
            position3D = _camera.ScreenToWorldPoint(mousePosition);
            direction = (position3D - _camera.transform.position).normalized;
            RaycastHit hit;
            if (Physics.Raycast(_camera.transform.position, direction, out hit, 40f,_layer))
            {
                IMixingInteractable mixingInteractable = hit.transform.gameObject.GetComponent<IMixingInteractable>();
                if (mixingInteractable != null)
                {
                    mixingInteractable.Interact();
                }
            }
        }
    }
}
