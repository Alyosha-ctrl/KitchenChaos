using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlateKitchenObject : kitchenObject
{
    private List<KitchenObjectSO> kitchenObjectSOList;
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (kitchenObjectSOList.Contains(kitchenObjectSO)) return false;
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO)) return false;
        
        kitchenObjectSOList.Add(kitchenObjectSO);
        return true;
    }
}