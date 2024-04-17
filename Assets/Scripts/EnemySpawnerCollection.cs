using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnerCollection : MonoBehaviour
{
    public List<OneTimeEnemySpawner> Spawners;

    public int Count => Spawners.Count(s => 
        !s.KeyToAttach.isActiveAndEnabled && !s.KeyToAttach.Collected);
}