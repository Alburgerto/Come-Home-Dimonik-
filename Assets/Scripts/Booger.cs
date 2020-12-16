using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booger : MonoBehaviour
{
    public float m_speed;

    private float m_lifeSpan = 8;
    private float m_timeLived = 0;
    private Vector3 m_moveVector;

    private void Update()
    {
        m_timeLived += Time.deltaTime;
        if (m_timeLived > m_lifeSpan)
        {
            Destroy(gameObject);
        }

        if (m_moveVector != null)
        {
            transform.Translate(m_moveVector * m_speed * Time.deltaTime);
        }
    }

    public void Initialize(Vector3 l_moveVector)
    {
        m_moveVector = l_moveVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Baddie"))
        {
            //collision.gameObject.GetComponent<Baddie>().Hurt();
        }
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
