using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{


    [SerializeField] private BaseCounter baseCounter;

    [SerializeField] private GameObject[] visual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Instance_OnSelectedCounterChanged;
    }

    private void Instance_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == baseCounter)
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
        foreach(GameObject visual2 in visual)
        {
            visual2.SetActive(true);
        }
        
    }

    private void Hide()
    {
        foreach(GameObject visual2 in visual)
        {
            visual2.SetActive(false);
        }
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
