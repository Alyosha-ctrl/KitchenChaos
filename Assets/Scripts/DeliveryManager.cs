using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance {get; private set;}
    private List<RecipeSO> waitingRecipeSOList;

    [SerializeField] private RecipeListSO recipeListSO;
    private float spawnTimer = 0f;
    private float spawnTimerMax =4f;

    private int waitRecipeMax = 4;

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    void Awake()
    {
        Instance = this;
        waitingRecipeSOList = new List<RecipeSO>();
            // spawnTimer = spawnTimerMax;

    }
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        // Debug.Log(spawnTimer);
        if(spawnTimer <= 0f)
        {
            spawnTimer = spawnTimerMax;
            if(waitingRecipeSOList.Count < waitRecipeMax)
            {
              RecipeSO waitRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
              waitingRecipeSOList.Add(waitRecipeSO);  
              OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            //   Debug.Log(waitRecipeSO.name);
            }
            
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for(int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSo = waitingRecipeSOList[i];

            if (waitingRecipeSo.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                bool contentsMatch = true;
                foreach (KitchenObjectSO recipeKitchenSO in waitingRecipeSo.kitchenObjectSOList)
                {
                    bool found = false;
                    foreach (KitchenObjectSO plateKitchenSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        if(plateKitchenSO == recipeKitchenSO)
                        {   
                           found = true;
                           break; 
                        }
                    }
                    if (!found)
                    {
                        contentsMatch = false;
                    }
                }
                if (contentsMatch)
                {
                    waitingRecipeSOList.RemoveAt(i);
                    // Debug.Log("Player Delivered Right Recipe");
                    // OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    spawnTimer = spawnTimerMax;
                    
                    return;
                }
            }
        }
        //No mathces found
        Debug.Log("Player delivered Wrong Recipe");
    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;
    }
}
