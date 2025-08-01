using UnityEngine;
using UnityEngine.UI;

public class UIToxicityBar : MonoBehaviour
{
    [SerializeField] PlayerToxicity _playerToxicity;
    [SerializeField] Slider _toxicityBar;

    private void Awake()
    {
        _playerToxicity.OnToxicityChange += OnPlayerToxicityChange;
        if (_toxicityBar != null && _toxicityBar != null)
        {
            _toxicityBar.maxValue = _playerToxicity.MaxToxicityValue;
        }
    }

    private void OnDestroy()
    {
        _playerToxicity.OnToxicityChange -= OnPlayerToxicityChange;
    }

    void OnPlayerToxicityChange(float toxicityValue)
    {
        if (_toxicityBar != null)
        {
            _toxicityBar.value = toxicityValue;
        }
    }
}
