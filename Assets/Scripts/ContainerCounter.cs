using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    [SerializeField] private Transform spawnPosition;
    private kitchenObject kitchenObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(Player player)
    {
        // Debug.Log("Clear Counter Touched");
        if(kitchenObject == null)
        {
           Transform tomatoTransform = Instantiate(kitchenObjectSO.prefab, spawnPosition);
            kitchenObject = tomatoTransform.GetComponent<kitchenObject>();
            kitchenObject.SetIKitchenObjectParent(this);
        }
        else
        {
            if(!player.HasKitchenObject()) {
                kitchenObject.SetIKitchenObjectParent(player);
            }
            else
            {
                Debug.Log("Player Already Has KitchenObject");
            }
        }
        
        // transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        // visual.SetActive(true);
        // Debug.Log(tomatoTransform.GetComponent<kitchenObject>().GetKitchenObjectSO().objectName);
    }

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
}
