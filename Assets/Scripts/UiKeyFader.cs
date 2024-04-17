using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiKeyFader : MonoBehaviour
{
    private Image m_Sprite;

    private Color m_OriginalColor, m_FadedColor;

    private void Awake()
    {
        m_Sprite = GetComponent<Image>();
        m_OriginalColor = m_Sprite.color;
        m_FadedColor = new Color(m_OriginalColor.r, m_OriginalColor.g, m_OriginalColor.b, 0.6f);
    }

    public void FadeKeys()
    {
        m_Sprite.color = m_FadedColor;
    }

    public void UnfadeKeys()
    {
        m_Sprite.color = m_OriginalColor;
    }
}