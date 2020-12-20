using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float m_speed;
    public float m_timeBetweenAttacks;

    private GameObject m_player;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        float step = 0.5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, m_player.transform.position, step);
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
