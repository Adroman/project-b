using System;
using Events;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ExitComponent : MonoBehaviour
{
    private bool m_CanEnter = false;

    public RespawnManager RespawnManager;
    
    public GameObject Ellen;
    private Vector3 m_StartingPosition;

    private void Start()
    {
        m_StartingPosition = Ellen.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CustomPlayer"))
        {
            m_CanEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CustomPlayer"))
        {
            m_CanEnter = false;
        }
    }

    private void Update()
    {
        if (m_CanEnter && Input.GetKey(KeyCode.W))
        {
            EnterDoor();
        }
    }

    private void EnterDoor()
    {
        if (RespawnManager.AllKeysCollected())
        {
            Debug.Log("All keys collected");
        }
        else
        {
            Debug.Log("Not all keys collected");
            RespawnManager.RespawnKeysAndEnemies();
            Ellen.transform.position = m_StartingPosition;
        }
    }
}