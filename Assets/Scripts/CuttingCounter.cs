using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO slices;
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
            if (!player.HasKitchenObject())
            {
                GetKitchenObject().SetIKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            //Cut
            GetKitchenObject().DestrySelf();
            Transform kitchenObjectTransform = Instantiate(slices.prefab);
            kitchenObjectTransform.GetComponent<kitchenObject>().SetIKitchenObjectParent(this);
        }
        //Don't cut
    }
}
