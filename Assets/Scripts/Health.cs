using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int m_health;
    private int m_maxHealth;
    private SpriteRenderer[] m_healthIcons;
    [SerializeField] private Sprite m_healthOn;
    [SerializeField] private Sprite m_healthOff;

    // Start is called before the first frame update
    void Start()
    {
        m_healthIcons = GetComponentsInChildren<SpriteRenderer>();
        m_maxHealth = m_healthIcons.Length;
    }

    public void ChangeHealth(int l_health)
    {
        m_health = Mathf.Clamp(m_health + l_health, 0, m_maxHealth);
        for (int i = 0; i < m_maxHealth; ++i)
        {
            if (m_healthIcons[i].sprite != m_healthOff)
            {
                m_healthIcons[i].sprite = m_healthOff;
            }
        }
        for (int i = 0; i < m_health; ++i)
        {
            if (m_healthIcons[i].sprite != m_healthOn)
            {
                m_healthIcons[i].sprite = m_healthOn;
            }
        }

        if (m_health == 0)
        {
            // rip coroutine
        }
    }
}
