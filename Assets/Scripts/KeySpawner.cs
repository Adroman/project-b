using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public KeyComponent KeyToActive;

    public void OnDisable()
    {
        if (!KeyToActive.Collected)
        {
            KeyToActive.transform.position = transform.position + Vector3.up;
            KeyToActive.gameObject.SetActive(true);
        }
    }
}