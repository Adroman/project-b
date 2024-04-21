using System;
using System.Collections.Generic;
using Events;
using Gamekit2D;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ExitComponent : MonoBehaviour
{
    private bool m_CanEnter = false;

    public RespawnManager RespawnManager;
    public KeySaver KeySaver;
    public UiManager UiManager;
    public UiVictoryPopup UiVictoryPopup;
    public List<UiKeyFader> KeyFadersToUnfade;
    public KeyDisablerAudio RedKeyDisabler;
    public KeyDisablerAudio GreenKeyDisabler;
    
    public Damageable Ellen;
    private Vector3 m_StartingPosition;

    private void Start()
    {
        m_StartingPosition = Ellen.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CustomPlayer"))
        {
            m_CanEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CustomPlayer"))
        {
            m_CanEnter = false;
        }
    }

    private void Update()
    {
        if (m_CanEnter && Input.GetKey(KeyCode.W))
        {
            EnterDoor();
        }
    }

    private void EnterDoor()
    {
        m_CanEnter = false;
        KeySaver.SaveKeys();
        if (RespawnManager.AllKeysCollected())
        {
            Debug.Log("All keys collected");
            UiVictoryPopup.ShowUi();
        }
        else
        {
            ResetKeysEnemiesAndPlayer();
        }
    }

    public void ResetKeysEnemiesAndPlayer()
    {
        Debug.Log("Not all keys collected");
        UiManager.AddAttempt();
        KeySaver.ResetKeys();
        RespawnManager.RespawnKeysAndEnemies();
        Ellen.SetHealth(5);
        Ellen.transform.position = m_StartingPosition;
        foreach (var uiKeyFader in KeyFadersToUnfade)
        {
            uiKeyFader.UnfadeKeys();
        }
        RedKeyDisabler.Reset();
        GreenKeyDisabler.Reset();
        UiManager.UpdateUI();
    }
}