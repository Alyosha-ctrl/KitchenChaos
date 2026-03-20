using Unity.VisualScripting;
using UnityEngine;



public class ClearCounter : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    [SerializeField] private Transform spawnPosition;
 
    public GameObject visual;

    private kitchenObject kitchenObject;

    public bool testing;
    public ClearCounter second;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testing)
        {
            kitchenObject.SetClearCounter(second);
            testing = false;
        }
    }

    public void Interact()
    {
        // Debug.Log("Clear Counter Touched");
        if(kitchenObject == null)
        {
           Transform tomatoTransform = Instantiate(kitchenObjectSO.prefab, spawnPosition);
            kitchenObject = tomatoTransform.GetComponent<kitchenObject>();
            kitchenObject.SetClearCounter(this);
        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
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
