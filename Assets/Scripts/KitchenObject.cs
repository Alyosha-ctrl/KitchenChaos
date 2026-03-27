using UnityEngine;



public class kitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetIKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)   {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        kitchenObjectParent.SetKitchenObject(this);
        this.kitchenObjectParent = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObject()) Debug.LogError("KitchenObjectParent Already Has KitchenObject");
        

        transform.parent = kitchenObjectParent.GetSpawnPosition();
        transform.localPosition = Vector3.zero;
        
    }

    public IKitchenObjectParent getKitchenObjectParent(){
        return this.kitchenObjectParent;
    }
}