using UnityEngine;



public class ClearCounter : MonoBehaviour
{

    [SerializeField] private Transform tomatoPrefab;

    [SerializeField] private Transform spawnPosition;
 
    public GameObject visual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Clear Counter Touched");
        Transform tomatoTransform = Instantiate(tomatoPrefab, spawnPosition);
        tomatoTransform.localPosition = Vector3.zero;
        // transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        // visual.SetActive(true);
    }


}
