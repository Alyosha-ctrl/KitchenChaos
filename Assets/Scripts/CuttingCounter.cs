using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetIKitchenObjectParent(this);
                }
                
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                GetKitchenObject().SetIKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            //Cut
            KitchenObjectSO output = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().DestrySelf();
            kitchenObject.SpawnKitchenObject(output, this);
        }
        //Don't cut
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if(cuttingRecipeSO.input == input)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if(cuttingRecipeSO.input == input)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
}
