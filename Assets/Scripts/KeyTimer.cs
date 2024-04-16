using System;
using UnityEngine;

[RequireComponent(typeof(KeyComponent))]
public class KeyTimer : MonoBehaviour
{
    public float LifetimeInSeconds;

    private KeyComponent m_KeyComponent;
    
    private float m_ElapsedSeconds = 0;

    public void ResetTimer()
    {
        m_ElapsedSeconds = 0;
    }

    private void Start()
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
}