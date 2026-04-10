using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlateKitchenObject : kitchenObject
{
    private List<KitchenObjectSO> kitchenObjectSOList;
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    public event EventHandler<OnIngredientAdded_EventArgs> OnIngredientAdded;
    public class OnIngredientAdded_EventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }
    void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (kitchenObjectSOList.Contains(kitchenObjectSO)) return false;
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO)) return false;
        
        kitchenObjectSOList.Add(kitchenObjectSO);
        OnIngredientAdded?.Invoke(this, new OnIngredientAdded_EventArgs
        {
            kitchenObjectSO = kitchenObjectSO
        });
        return true;
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}