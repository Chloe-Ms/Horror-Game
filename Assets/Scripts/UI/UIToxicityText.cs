using TMPro;
using UnityEngine;

public class UIToxicityText : MonoBehaviour
{
    [SerializeField] MixedProduct _mixedProduct;
    [SerializeField] TextMeshPro _text;

    public void UpdateToxicity()
    {
        _text.text = _mixedProduct.ProductPoisoningValue.ToString();
    }
}
