using Gamekit2D;
using TMPro;
using UnityEngine;

public class UiVictoryPopup : MonoBehaviour
{
    public UiManager UiManager;
    public GameObject HealthUi;
    public TMP_Text AttemptsText;
    public PlayerInput Ellen;

    public void ShowUi()
    {
        AttemptsText.text = $"You have collected all the keys and reached the exit in {UiManager.Attempts} attempt{(UiManager.Attempts != 1 ? "s" : "")}.";
        
        UiManager.gameObject.SetActive(false);
        HealthUi.SetActive(false);
        
        gameObject.SetActive(true);
        Ellen.ReleaseControl();
        //Time.timeScale = 0;
    }
}