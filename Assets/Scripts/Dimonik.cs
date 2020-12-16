using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimonik : MonoBehaviour
{
    public float m_speed;
    public GameObject m_booger;
    public GameManager m_gameManager;

    [SerializeField] private Health m_health;
    private SpriteRenderer m_renderer;
    private Rigidbody2D m_rigidBody;
    private Animator m_animator;
    private Vector2 m_moveVector = new Vector2();
    private bool m_canMove = true;

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

        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        //{
        //    Attack();
        //}
    }

    private void FixedUpdate()
    {
        if (m_canMove)
        {
            m_rigidBody.MovePosition(m_rigidBody.position + m_moveVector * m_speed * Time.fixedDeltaTime);
        }
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
        else if (collision.CompareTag("Door"))
        {
            string doorParent = collision.GetComponentInParent<Transform>().parent.name;
            if (doorParent == "Left")
            {
                m_gameManager.ChangeRoom(Location.Right);
            }
            else if (doorParent == "Right")
            {
                m_gameManager.ChangeRoom(Location.Left);
            }
            else if (doorParent == "Up")
            {
                m_gameManager.ChangeRoom(Location.Down);
            }
            else if (doorParent == "Down")
            {
                m_gameManager.ChangeRoom(Location.Up);
            }
        }
    }
    
    public void CanMove(bool l_canMove)
    {
        m_canMove = l_canMove;
    }

    // Called from different enemies'/details' colliders
    public void ChangeHealth(int l_health)
    {
        m_health.ChangeHealth(l_health);
    }

    private void Attack()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6));
        mousePosition = new Vector3(mousePosition.x * - 1, mousePosition.y * - 1, mousePosition.z);
        Vector2 moveVector = (mousePosition - transform.position).normalized;
        GameObject booger = Instantiate(m_booger, transform.position, Quaternion.identity);
        booger.GetComponent<Booger>().Initialize(moveVector);
    }

}
