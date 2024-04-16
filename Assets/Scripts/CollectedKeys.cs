using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectedKeys", menuName = "Custom/Collected keys", order = 0)]
public class CollectedKeys : ScriptableObject
{
    public List<KeyComponent> Keys = new();

    public void AddKey(KeyComponent key)
    {
        Keys.Add(key);
    }

    public bool ContainsKey(KeyComponent key)
    {
        return Keys.Contains(key);
    }
}