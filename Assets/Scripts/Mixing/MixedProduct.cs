using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EToxicityOperator { Addition, Multiplication }

public class MixedProduct : MonoBehaviour, IMixingInteractable
{
    [SerializeField] private EToxicityOperator _toxicityOperator = EToxicityOperator.Addition;
    [SerializeField] private ProductsInventory _playerInventory;

    private List<SO_Household_Product> _mixedProducts;
    private float _productPoisonValue = 0f;
    public float ProductPoisoningValue => _productPoisonValue;

    [SerializeField] private UnityEvent OnProductAddedInInventoryEvent;
    public event Action OnProductAddedInInventory;
    [SerializeField] private UnityEvent OnProductAddedToMixEvent;
    public event Action OnProductAddedToMix;
    [SerializeField] private UnityEvent OnMixResetEvent;
    public event Action OnMixReset;

    private void Awake()
    {
        _mixedProducts = new List<SO_Household_Product>();
    }

    public void ResetMix()
    {
        _mixedProducts.Clear();
        _productPoisonValue = 0f;
        OnMixResetEvent.Invoke();
        OnMixReset?.Invoke();
    }

    public void AddProduct(SO_Household_Product product)
    {
        if (product == null)
            return;

        if (_mixedProducts.Count == 0)
        {
            _productPoisonValue = product.ToxicityInitialValue;
            Debug.Log($"Add product {product.name} initial value {_productPoisonValue}");
        } else
        {
            _productPoisonValue = product.ApplyToxicityValue(_toxicityOperator, _productPoisonValue);
            Debug.Log($"Add product {product.name} poison value : {_productPoisonValue}");
        }

        _mixedProducts.Add(product);
        OnProductAddedToMixEvent.Invoke();
        OnProductAddedToMix?.Invoke();
    }

    public void AddMixedProductToInventory()
    {
        if (_playerInventory != null)
        {
            Debug.Log($"Add product with {ProductPoisoningValue} toxicity to inventory. Mix is reset.");
            _playerInventory.AddProduct(ProductPoisoningValue);
            OnProductAddedInInventoryEvent.Invoke();
            OnProductAddedInInventory?.Invoke();
            ResetMix();
        } else
        {
            Debug.LogWarning("The mixed product doesn't have the player inventory reference.");
        }
    }

    public void Interact()
    {
        AddMixedProductToInventory();
    }
}
