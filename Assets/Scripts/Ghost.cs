using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float m_speed;
    public float m_timeBetweenAttacks;

    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_timeBetweenAttacks);
            m_animator.SetBool("IsAttacking", !m_animator.GetBool("IsAttacking"));
        }
    }
}
