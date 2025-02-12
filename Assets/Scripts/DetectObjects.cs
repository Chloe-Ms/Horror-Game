using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    [SerializeField] float _distanceRaycast = 4f;
    [SerializeField] Camera _camera;

    [SerializeField] LayerMask _layerMask;
    IInteractable _currentTarget;
    IInteractable _lastInteractable;

    //Action<LastInteractable,CurrentInteractable>
    public event Action<IInteractable, IInteractable> OnChangeTarget;

    void Update()
    {
        RaycastHit hit;
                Debug.DrawRay(_camera.transform.position, _camera.transform.forward * _distanceRaycast, Color.yellow);
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distanceRaycast, _layerMask))
        {
            GameObject hitGameobject = hit.transform.gameObject;
            IInteractable currentInteractable = hitGameobject.GetComponent<IInteractable>();

            OnChangeTarget?.Invoke(_lastInteractable,currentInteractable);

            if (Input.GetKey(KeyCode.Space))
            {
                if (currentInteractable != null)
                {
                    if (_currentTarget != currentInteractable)
                    {
                        if (_currentTarget != null)
                        {
                            _currentTarget.StopInteracting();
                        }
                        
                        _currentTarget = currentInteractable;
                        _currentTarget.StartInteracting();
                    }
                    Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.yellow);
                } else
                {
                    StopTarget();
                    Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.red);
                }
            } else if (_currentTarget != null)
            {
                StopTarget();
            }
            _lastInteractable = currentInteractable;
        } else if (_lastInteractable != null)
        {
            OnChangeTarget?.Invoke(_lastInteractable, null);
            _lastInteractable = null; // A LAISSER???????
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopTarget();
        }
    }

    void StopTarget()
    {
        if (_currentTarget != null)
        {
            _currentTarget.StopInteracting();
            _currentTarget = null;
        }
    }

    //void Update()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distanceRaycast, _layerMask))
    //    {
    //        GameObject go = hit.transform.gameObject;
    //        CleanPuddle bloodPuddle = go.GetComponent<CleanPuddle>();
    //        if (bloodPuddle != null)
    //        {
    //            _uiTextClean.SetActive(true);
    //        }
    //        else
    //        {
    //            _uiTextClean.SetActive(false);
    //        }
    //        if (Input.GetKey(KeyCode.Space))
    //        {
    //            if (bloodPuddle != null)
    //            {
    //                if (_currentTarget != bloodPuddle)
    //                {
    //                    if (_currentTarget != null)
    //                    {
    //                        _currentTarget.StopCleaning();
    //                    }

    //                    _currentTarget = bloodPuddle;
    //                    _currentTarget.StartCleaning();
    //                }
    //                Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.yellow);
    //            }
    //            else
    //            {
    //                StopTarget();
    //                Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.red);
    //            }
    //        }
    //        else if (_currentTarget != null)
    //        {
    //            StopTarget();
    //        }
    //    }
    //    else if (_uiTextClean.activeSelf)
    //    {
    //        _uiTextClean.SetActive(false);
    //    }

    //    if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        StopTarget();
    //    }
    //}

    //void StopTarget()
    //{
    //    if (_currentTarget != null)
    //    {
    //        _currentTarget.StopCleaning();
    //        _currentTarget = null;
    //    }
    //}
}
