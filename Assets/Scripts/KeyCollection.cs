using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key Collection", menuName = "Custom/Key Collection", order = 0)]
public class KeyCollection : ScriptableObject
{
    public List<KeyComponent> LiveObjects = new();

    public void Add(KeyComponent go)
    {
        LiveObjects.Add(go);
    }

    public void Remove(KeyComponent go)
    {
        LiveObjects.Remove(go);
    }
}