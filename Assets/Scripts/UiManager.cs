using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UiManager : MonoBehaviour
{
    public KeyCollection Keys;
    public KeyCollection RedKeys;
    public KeyCollection GreenKeys;
    public KeyCollection YellowKeys;
    public EnemySpawnerCollection Enemies;

    public TMP_Text KeysText;
    public TMP_Text RedKeysText;
    public TMP_Text GreenKeysText;
    public TMP_Text YellowActiveKeysText;
    public TMP_Text YellowExpiredKeysText;

    public TMP_Text AttemptsText;

    public int Attempts { get; private set; }

    private void Start()
    {
        Attempts = 1;
        UpdateUI();
    }

    public void AddAttempt()
    {
        Attempts++;
        Debug.Log("Adding one attempt");
        UpdateUI();
    }

    public void UpdateUI()
    {
        AttemptsText.text = "Attempts: " + Attempts;
        KeysText.text = (Keys.Count + Enemies.Count).ToString();
        RedKeysText.text = RedKeys.Count.ToString();
        GreenKeysText.text = GreenKeys.Count.ToString();
        YellowActiveKeysText.text = YellowKeys.ActiveCount.ToString();
        YellowExpiredKeysText.text = YellowKeys.ExpiredCount.ToString();
    }
}