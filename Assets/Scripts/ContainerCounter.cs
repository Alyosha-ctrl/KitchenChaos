using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(Player player)
    {
        kitchenObject kitchenObject = GetKitchenObject();
        if(!player.HasKitchenObject()) {
            Transform tomatoTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObject = tomatoTransform.GetComponent<kitchenObject>();
            kitchenObject.SetIKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.Log("Player Already Has KitchenObject");
        } 
    }
}
