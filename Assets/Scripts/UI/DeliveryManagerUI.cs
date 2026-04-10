using Unity.VisualScripting;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSpawned += OnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeCompleted += OnRecipeCompleted;

        UpdateVisual();
    }

    private void OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateVisual()
    {
        //Clean up
        foreach (Transform child in container)
        {
            if(child != recipeTemplate)
            {
                Destroy(child.gameObject);
            }
        }

        foreach(RecipeSO recipeSO in DeliveryManager.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);

            recipeTransform.GetComponent<DeliveryManagerSingleUI>().setRecipeSO(recipeSO);
        }
    }
}
