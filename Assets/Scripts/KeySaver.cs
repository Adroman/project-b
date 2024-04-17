using System.Collections.Generic;
using UnityEngine;

public class KeySaver : MonoBehaviour
{
    private readonly List<KeyComponent> m_HotKeys = new();
    private readonly List<OneTimeEnemySpawner> m_HotEnemies = new();

    private void OnEnable()
    {
        m_HotKeys.Clear();
        m_HotEnemies.Clear();
    }

    public void CollectKey(KeyComponent key)
    {
        m_HotKeys.Add(key);
    }

    public void CollectKeyFromEnemy(OneTimeEnemySpawner enemy)
    {
        m_HotEnemies.Add(enemy);
    }

    public void ResetKeys()
    {
        foreach (var key in m_HotKeys)
        {
            key.gameObject.SetActive(true);
        }

        foreach (var enemy in m_HotEnemies)
        {
            enemy.KeyToAttach.Collected = false;
        }
    }

    public void SaveKeys()
    {
        m_HotKeys.Clear();
        m_HotEnemies.Clear();
    }
}