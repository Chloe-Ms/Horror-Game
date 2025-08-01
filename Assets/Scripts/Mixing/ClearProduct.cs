using UnityEngine;

public class ClearProduct : MonoBehaviour, IMixingInteractable
{
    [SerializeField] MixedProduct _mixedProduct;
    public void Interact()
    {
        Debug.Log("The product mixed is cleared.");
        ResetProduct();
    }

    public void ResetProduct()
    {
        if (_mixedProduct != null)
        {
            _mixedProduct.ResetMix();
        }
    }
}
