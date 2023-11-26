using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float jump;
    private bool isGrounded = true;
    private bool isSliding = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isSliding = false;
            animator.SetBool("Jumping", false);
        }

        else if (collision.gameObject.CompareTag("Rail"))
        {
            isSliding = true;
            isGrounded = true;
            animator.SetBool("Sliding", true);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("Jumping", true);
        }
        else if(collision.gameObject.CompareTag("Rail"))
        {
            isSliding = false;
            animator.SetBool("Sliding", false);
        }
       
    }
}
