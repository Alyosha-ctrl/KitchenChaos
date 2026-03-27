using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetSpawnPosition();

    public void SetKitchenObject(kitchenObject kitchenObject);

    public kitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();

}