using System;
using Gamekit2D;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public KeyComponent KeyToActive;
    public CollectedKeys CollectedKeys;
    public RespawnManager RespawnManager;

    public void OnDisable()
    {
        if (!KeyToActive.Collected)
        {
            KeyToActive.transform.position = transform.position + Vector3.up;
            KeyToActive.gameObject.SetActive(true);
        }
    }

    public void Awake()
    {
        RespawnManager.RegisterEnemy(this);
    }

    public void OnEnable()
    {
        if (!KeyToActive.Collected)
        {
            KeyToActive.gameObject.SetActive(false);
        }
    }
}