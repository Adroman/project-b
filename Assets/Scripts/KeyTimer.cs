using System;
using UnityEngine;

[RequireComponent(typeof(KeyComponent))]
public class KeyTimer : MonoBehaviour
{
    public UiManager UiManager;
    public float LifetimeInSeconds;
    
    private KeyComponent m_KeyComponent;
    
    private float m_ElapsedSeconds = 0;

    public void ResetTimer()
    {
        m_ElapsedSeconds = 0;
        UiManager.UpdateUI();
    }

    private void Awake()
    {
        m_KeyComponent = GetComponent<KeyComponent>();
    }

    private void Update()
    {
        m_ElapsedSeconds += Time.deltaTime;

        if (m_ElapsedSeconds > LifetimeInSeconds)
        {
            m_KeyComponent.DespawnKey();
            enabled = false;
        }
    }

    private void OnDisable()
    {
        UiManager.UpdateUI();
    }
}