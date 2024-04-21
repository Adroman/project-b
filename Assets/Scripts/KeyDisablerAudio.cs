using UnityEngine;

public class KeyDisablerAudio : MonoBehaviour
{
    private bool m_AlreadyPlayed = false;
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (!m_AlreadyPlayed)
        {
            m_AlreadyPlayed = true;
            m_AudioSource.Play();
        }
    }

    public void Reset()
    {
        m_AlreadyPlayed = false;
    }
}