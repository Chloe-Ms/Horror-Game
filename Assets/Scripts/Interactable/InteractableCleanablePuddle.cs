using System.Collections;
using UnityEngine;

public class CleanableSurface : MonoBehaviour, IInteractable
{
    const string _OpacityShaderName = "_Opacity";
    int _OpacityShaderID;

    [SerializeField,Min(0)] float _cleaningDuration = 5f;
    float _currentDurationDirtiness = 0f;

    MeshRenderer _renderer;
    Coroutine _coroutineClean;

    public EInteractable InteractableType => EInteractable.BLOOD;

    public bool IsCurrentlyInteractable => true;

    private void Awake()
    {
        _OpacityShaderID = Shader.PropertyToID(_OpacityShaderName);
        _renderer = GetComponent<MeshRenderer>();
    }

    public void StartCleaning()
    {
        StopCleaning();
        _coroutineClean = StartCoroutine(RoutineClean());
    }

    public void StopCleaning()
    {
        if (_coroutineClean != null)
        {
            StopCoroutine(_coroutineClean);
            _coroutineClean = null;
        }
    }

    IEnumerator RoutineClean()
    {
        while (_currentDurationDirtiness < _cleaningDuration) 
        {
            _currentDurationDirtiness += Time.deltaTime;
            float valueOpacity = 1 - (_currentDurationDirtiness / _cleaningDuration);
            ChangeOpacity(valueOpacity);
            yield return null;
        }
        _currentDurationDirtiness = 0f;
        Destroy(gameObject);
    }

    void ChangeOpacity(float value)
    {
        _renderer.material.SetFloat(_OpacityShaderID, value);
    }

    public void StartInteracting()
    {
        StartCleaning();
    }

    public void StopInteracting()
    {
        StopCleaning();
    }

    private void OnDestroy()
    {
        StopCleaning();
    }
}
