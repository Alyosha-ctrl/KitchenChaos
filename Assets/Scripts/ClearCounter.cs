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

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetIKitchenObjectParent(this);
            }
        }
        else
        {
            
        }
    }
    
}
