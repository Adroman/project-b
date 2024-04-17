using System;
using UnityEngine;

public class OneTimeEnemySpawner : MonoBehaviour
{
    public KeySpawner EnemyToSpawn;
    public KeyComponent KeyToAttach;
    public RespawnManager RespawnManager;

    private KeySpawner m_SpawnedEnemy;

    private void Awake()
    {
        RespawnManager.RegisterEnemy(this);
    }

    private void OnEnable()
    {
        Debug.Log("Spawning enemy");
        if (m_SpawnedEnemy != null)
        {
            Destroy(m_SpawnedEnemy.gameObject);
        }
        
        var transform1 = transform;
        m_SpawnedEnemy = Instantiate(EnemyToSpawn, transform1.position, transform1.rotation, transform1);
        m_SpawnedEnemy.transform.SetParent(transform1.parent);
        m_SpawnedEnemy.KeyToActive = KeyToAttach;
        KeyToAttach.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}