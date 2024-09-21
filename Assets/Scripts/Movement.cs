using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 10f;
    [SerializeField] float _rotationSensitivity = 10f;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 cameraDirection = new Vector3(- Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0);
        Debug.Log(PauseManager.IsInPause);
        transform.localEulerAngles += cameraDirection * _rotationSensitivity;
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
        transform.position += direction * _movementSpeed * Time.deltaTime;
    }
}
