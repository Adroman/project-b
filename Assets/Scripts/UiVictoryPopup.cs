using TMPro;
using UnityEngine;

public class UiVictoryPopup : MonoBehaviour
{
    public UiManager UiManager;
    public GameObject HealthUi;
    public TMP_Text AttemptsText;

    public void ShowUi()
    {
        AttemptsText.text = $"It took you {UiManager.Attempts} attempt{(UiManager.Attempts != 1 ? "s" : "")} to achieve that";
        
        UiManager.gameObject.SetActive(false);
        HealthUi.SetActive(false);
        
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}