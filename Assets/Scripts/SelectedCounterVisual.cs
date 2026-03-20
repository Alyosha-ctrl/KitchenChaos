using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{


    [SerializeField] private ClearCounter clearCounter;

    [SerializeField] private GameObject visual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Instance_OnSelectedCounterChanged;
    }

    private void Instance_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visual.SetActive(true);
    }

    private void Hide()
    {
        visual.SetActive(false);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
