using System.Collections.Generic;
using UnityEngine;

public struct Product
{
    public int ID;
    public float Toxicity;

}

public class ProductsInventory : MonoBehaviour
{
    List<Product> _products;
    int _idIterator = 0;
    Product _currentProduct;

    public List<Product> Products => _products;

    private void Awake()
    {
        _products = new List<Product>();
        Managers.ProductsInventory = this;
    }

    //Add

    public void AddProduct(float toxicity)
    {
        _products.Add(
            new Product
            {
                ID = _idIterator++,
                Toxicity = toxicity
            });
    }

    //Remove

    public void RemoveProduct(int id) 
    {
        Product productToRemove = _products.Find(product => product.ID == id);
        _products.Remove(productToRemove);
    }

    //Use product

    public void UseProduct (int id)
    {
        Product product = _products.Find(product => product.ID == id);
        _currentProduct = product;
        _products.Remove(product);
    }
}
