using UnityEngine;

public class MixingProduct : MonoBehaviour, IMixingInteractable
{
    [SerializeField] SO_Household_Product _productData;
    [SerializeField] MixedProduct _mixedProduct;

    public void Interact()
    {
        AddProduct();
    }

    public void AddProduct()
    {
        if (_mixedProduct != null)
        {
            _mixedProduct.AddProduct(_productData);
        }
    }
}
