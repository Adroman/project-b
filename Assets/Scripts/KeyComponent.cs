using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class KeyComponent : MonoBehaviour
{
    private Collider2D m_Collider;
    private SpriteRenderer m_SpriteRenderer;
    
    private Color m_OriginalColor;
    private Color m_TransparentColor;

    public RespawnManager RespawnManager;
    public bool Collected = false;

    public KeyCollection KeyCollection;
    public CollectedKeys CollectedKeys;

    private void OnEnable()
    {
        KeyCollection.Add(this);
    }
    
    private void OnDisable()
    {
        KeyCollection.Remove(this);
    }

    private void Start()
    {
        m_Collider = GetComponent<Collider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_OriginalColor = m_SpriteRenderer.color;
        m_TransparentColor = new Color(m_OriginalColor.r, m_OriginalColor.g, m_OriginalColor.b, 0.6f);
        RespawnManager.RegisterKey(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CustomPlayer"))
        {
            CollectedKeys.AddKey(this);
            Collected = true;
            gameObject.SetActive(false);
        }
    }

    public void DespawnKey()
    {
        m_Collider.enabled = false;
        m_SpriteRenderer.color = m_TransparentColor;
    }

    public void RespawnKey()
    {
        if (!CollectedKeys.ContainsKey(this))
        {
            m_Collider.enabled = true;
            m_SpriteRenderer.color = m_OriginalColor;

            var timer = GetComponent<KeyTimer>();

            if (timer != null)
            {
                timer.enabled = true;
                timer.ResetTimer();
            }
        }
    }
}