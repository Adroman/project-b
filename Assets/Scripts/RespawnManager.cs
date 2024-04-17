using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private readonly List<KeyComponent> m_Keys = new();
    private readonly List<OneTimeEnemySpawner> m_Enemies = new();

    public CollectedKeys CollectedKeys;
    
    public void Start()
    {
        CollectedKeys.Keys.Clear();
    }

    public void RegisterEnemy(OneTimeEnemySpawner enemy)
    {
        m_Enemies.Add(enemy);
    }

    public void RegisterEnemySpawnerKey(KeyComponent key)
    {
        if (!m_Enemies.Select(e => e.EnemyToSpawn.KeyToActive).Contains(key))
        {
            m_Keys.Add(key);
        }
    }

    public bool AllKeysCollected()
    {
        return m_Keys.All(key => key.Collected) && m_Enemies.All(enemy => enemy.KeyToAttach.Collected);
    }

    public void RespawnKeysAndEnemies()
    {
        Debug.Log("Respawning keys");
        foreach (var keyComponent in m_Keys)
        {
            keyComponent.RespawnKey();
        }
        
        Debug.Log("Respawning enemies");
        foreach (var enemy in m_Enemies)
        {
            enemy.gameObject.SetActive(true);
        }
    }
}