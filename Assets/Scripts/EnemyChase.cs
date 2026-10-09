using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public DungeonPlayerMovement player;
    public float moveSpeed = 1.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 lastDirection = Vector2.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = Vector2.zero;

        if (player != null && player.enabled)
        {
            Vector2 direction =
                (Vector2)player.transform.position - rb.position;

            if (direction.magnitude > 0.1f)
            {
                moveDirection = direction.normalized;
            }
        }

        rb.linearVelocity = moveDirection * moveSpeed;

        bool isMoving = moveDirection != Vector2.zero;

        if (isMoving)
        {
            lastDirection = moveDirection;
        }

        if (animator != null)
        {
            animator.SetFloat("X", lastDirection.x);
            animator.SetFloat("Y", lastDirection.y);
            animator.SetBool("Walk", isMoving);
            animator.SetBool("Idle", !isMoving);
        }
    }
}