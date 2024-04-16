using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private readonly List<KeyComponent> m_Keys = new();
    private readonly List<KeySpawner> m_Enemies = new();

    public CollectedKeys CollectedKeys;

    public void Start()
    {
        CollectedKeys.Keys.Clear();
    }

    public void RegisterEnemy(KeySpawner enemy)
    {
        m_Enemies.Add(enemy);
    }

    public void RegisterKey(KeyComponent key)
    {
        if (!m_Enemies.Select(e => e.KeyToActive).Contains(key))
        {
            m_Keys.Add(key);
        }
    }

    public bool AllKeysCollected()
    {
        return m_Keys.All(key => key.Collected) && m_Enemies.All(enemy => enemy.KeyToActive.Collected);
    }

    public void RespawnKeysAndEnemies()
    {
        foreach (var keyComponent in m_Keys)
        {
            keyComponent.RespawnKey();
        }

        foreach (var enemy in m_Enemies)
        {
            enemy.gameObject.SetActive(true);
        }
    }
}