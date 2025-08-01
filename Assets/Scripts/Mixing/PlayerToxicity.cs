using System;
using UnityEngine;

public class PlayerToxicity : MonoBehaviour
{
    [SerializeField] private float _maxToxicityValue = 10f;
    private float _toxicityValue = 0f;
    public float ToxicityValue => _toxicityValue;
    public float MaxToxicityValue => _maxToxicityValue;
    public event Action<float> OnToxicityChange;

    private void Start()
    {
        ResetToxicity(0f);
    }

    public void ResetToxicity(float toxicityValue)
    {
        _toxicityValue = toxicityValue;
        OnToxicityChange?.Invoke(_toxicityValue);
    }

    public void AddToxicity(float toxicityValue)
    {
        _toxicityValue = Mathf.Min(_toxicityValue + toxicityValue, _maxToxicityValue);
        OnToxicityChange?.Invoke(_toxicityValue);

        if (_toxicityValue >= _maxToxicityValue)
        {
            Debug.Log("Player death");
        }
    }
}
