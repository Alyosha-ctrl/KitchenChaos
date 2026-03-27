using Unity.VisualScripting;
using UnityEngine;



public class ClearCounter : BaseCounter
{


    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    // public override void Interact(Player player)
    // {
    //     // Debug.Log("Clear Counter Touched");
    //     if(kitchenObject == null)
    //     {
    //        Transform tomatoTransform = Instantiate(kitchenObjectSO.prefab, spawnPosition);
    //         kitchenObject = tomatoTransform.GetComponent<kitchenObject>();
    //         kitchenObject.SetIKitchenObjectParent(this);
    //     }
    //     else
    //     {
    //         if(!player.HasKitchenObject()) {
    //             kitchenObject.SetIKitchenObjectParent(player);
    //         }
    //         else
    //         {
    //             Debug.Log("Player Already Has KitchenObject");
    //         }
    //     }
        
    //     // transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    //     // visual.SetActive(true);
    //     // Debug.Log(tomatoTransform.GetComponent<kitchenObject>().GetKitchenObjectSO().objectName);
    // }
}
