using UnityEngine;



public class kitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if(this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        else
        {
            Debug.Log("Error Object Already there");
        }
        this.clearCounter = clearCounter; 

        if(!clearCounter.HasKitchenObject()) clearCounter.SetKitchenObject(this);
        

        transform.parent = clearCounter.GetSpawnPosition();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}