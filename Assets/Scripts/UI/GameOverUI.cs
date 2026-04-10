using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EndStatsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += OnStateChanged;
        Hide();
    }

     private void OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();
            Debug.Log(DeliveryManager.Instance.GetSuccesses().ToString());
            EndStatsText.text = DeliveryManager.Instance.GetSuccesses().ToString();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        this.gameObject.SetActive(true);
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
