using System;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private ContainerCounter containerCounter;
    private const string OPEN_CLOSE = "OpenClose";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, EventArgs e)
    {
        Debug.Log("Something Grabbed");
        animator.SetTrigger(OPEN_CLOSE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
