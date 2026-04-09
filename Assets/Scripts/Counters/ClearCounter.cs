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
            if (player.HasKitchenObject())
            {
                //Plate checker logic
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestrySelf();
                    }
                }else if(GetKitchenObject().TryGetPlate(out plateKitchenObject)){
                    if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                    {
                        player.GetKitchenObject().DestrySelf();
                    }
                }
            }
            else
            {
                //Pick Up
                GetKitchenObject().SetIKitchenObjectParent(player);
            }
        }
    }
    
}
