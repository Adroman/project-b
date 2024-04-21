using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class KeyComponent : MonoBehaviour
{
    private Animator m_Animator;
    private KeyTimer m_Timer;
    private bool m_HasTimer;

    public RespawnManager RespawnManager;
    public bool Collected = false;

    public KeyCollection KeyCollection;
    public CollectedKeys CollectedKeys;
    public UiManager UiManager;

    public bool IsNotExpired => m_Animator.GetBool(Enabled);

    public UnityEvent<KeyComponent> OnCollected;
    private static readonly int Enabled = Animator.StringToHash("Enabled");

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Timer = GetComponent<KeyTimer>();
        m_HasTimer = m_Timer != null;
    }

    private void OnEnable()
    {
        KeyCollection.Add(this);
        m_Animator.SetBool(Enabled, true);
    }
    
    private void OnDisable()
    {
        KeyCollection.Remove(this);
        UiManager.UpdateUI();
    }

    private void Start()
    {
        RespawnManager.RegisterEnemySpawnerKey(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CustomPlayer"))
        {
            CollectedKeys.AddKey(this);
            Collected = true;
            OnCollected.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    public void DespawnKey()
    {
        if (m_Animator.GetBool(Enabled))
        {
            m_Animator.SetBool(Enabled, false);
        }
    }

    public void RespawnKey()
    {
        if (!CollectedKeys.ContainsKey(this))
        {
            if (!m_Animator.GetBool(Enabled))
            {
                m_Animator.SetBool(Enabled, true);
            }
            
            if (m_HasTimer)
            {
                m_Timer.enabled = true;
                m_Timer.ResetTimer();
            }
        }
    }
}