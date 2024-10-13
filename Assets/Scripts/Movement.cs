using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 10f;
    [SerializeField] float _rotationSensitivity = 10f;
    [SerializeField] Camera _fpsCamera;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (!PauseManager.IsInPause)
        {
            Vector3 cameraVerticalRotation = new Vector3(- Input.GetAxisRaw("Mouse Y"), 0, 0);
            Vector3 cameraHorizontalRotation = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0);
            Debug.Log(Input.GetAxisRaw("Mouse Y"));
            transform.localEulerAngles += cameraHorizontalRotation * _rotationSensitivity * Time.deltaTime;
            _fpsCamera.transform.localEulerAngles += cameraVerticalRotation * _rotationSensitivity * Time.deltaTime;

            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            Vector3 direction = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");
            transform.position += direction * _movementSpeed * Time.deltaTime;
        }
    }
}
