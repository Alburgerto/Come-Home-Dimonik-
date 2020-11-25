using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimonik : MonoBehaviour
{
    public float m_speed;

    [SerializeField] private Health m_health;
    private SpriteRenderer m_renderer;
    private Rigidbody2D m_rigidBody;
    private Animator m_animator;
    private Vector2 m_moveVector = new Vector2();

    private void Start()
    {
        m_renderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        m_moveVector.x = Input.GetAxisRaw("Horizontal");
        m_moveVector.y = Input.GetAxisRaw("Vertical");

        if (m_moveVector.x == 0 && m_moveVector.y == 0)
        {
            m_animator.SetBool("Moving", false);
        }
        else
        {
            m_animator.SetBool("Moving", true);
        }

        if (m_moveVector.y == 1)
        {
            m_animator.SetBool("FacingForward", false);
        }
        else if (m_moveVector.y == -1)
        {
            m_animator.SetBool("FacingForward", true);
        }

        if (m_moveVector.x == 1)
        {
            m_renderer.flipX = false;
        }
        else if (m_moveVector.x == -1)
        {
            m_renderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        m_rigidBody.MovePosition(m_rigidBody.position + m_moveVector * m_speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ChangeHealth(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            ChangeHealth(1);
        }
    }

    public void ChangeHealth(int l_health)
    {
        m_health.ChangeHealth(l_health);

    }

}
