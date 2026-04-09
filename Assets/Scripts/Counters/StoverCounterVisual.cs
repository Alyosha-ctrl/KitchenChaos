using UnityEngine;

public class StoverCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject stoveOn;
    [SerializeField] private GameObject particles;
    [SerializeField] private StoveCounter stoveCounter;

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        stoveOn.SetActive(showVisual);
        particles.SetActive(showVisual);
    }


}

