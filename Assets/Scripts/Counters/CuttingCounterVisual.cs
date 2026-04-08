using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    [SerializeField] private CuttingCounter cuttingCounter;
    private const string CUT = "Cut";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        Debug.Log("Cut");
        animator.SetTrigger(CUT);
    }
}
