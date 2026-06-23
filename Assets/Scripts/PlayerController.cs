using UnityEngine;

// This script controls the player ball — it handles jumping and dying
public class PlayerController : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 12f;         // How high the ball jumps
    public Transform groundCheck;         // A point at the bottom of the ball
    public float groundCheckRadius = 0.2f;// How wide the ground detection is
    public LayerMask groundLayer;         // What counts as "ground"

    private Rigidbody2D rb;               // The physics body of the ball
    private bool isGrounded;              // Is the ball touching the ground?
    private bool isDead = false;          // Is the player dead?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return; // Stop doing anything if dead

        // Check if the ball is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when Space, LeftCtrl, or screen tap
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply upward force
        }
    }

    // Called when ball touches something
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    
    public void TriggerDeath()
    {
        if (!isDead) Die();
    }

    void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;               // Stop the ball
        rb.AddForce(new Vector2(-3f, 8f), ForceMode2D.Impulse); // Knock it back
        GameManager.instance.GameOver();           // Tell GameManager to show Game Over
    }

    // Draw the ground check circle in the Editor (so you can see it)
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
