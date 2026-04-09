using UnityEditor.Build;
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

        if(kitchenObjectParent.HasKitchenObject()) {
            Debug.Log("KitchenObjectParent Already Has KitchenObject");
        }
        

        transform.parent = kitchenObjectParent.GetSpawnPosition();
        transform.localPosition = Vector3.zero;
        
    }

    public IKitchenObjectParent getKitchenObjectParent(){
        return this.kitchenObjectParent;
    }

    public void DestrySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if(this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        plateKitchenObject = null;
        return false;
    }

    public static kitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        kitchenObject end = kitchenObjectTransform.GetComponent<kitchenObject>();
        end.SetIKitchenObjectParent(kitchenObjectParent);

        return end;
    }
}