using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform spawnPosition;
    private kitchenObject kitchenObject;
    public Transform GetSpawnPosition()
    {
        return spawnPosition;
    }

    public void SetKitchenObject(kitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public kitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    public virtual void Interact(Player player){}
}
