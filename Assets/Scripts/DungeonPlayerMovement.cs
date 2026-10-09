using UnityEngine;
using UnityEngine.InputSystem;

public class DungeonPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private Vector2 lastDirection = Vector2.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        moveInput = Vector2.zero;

        Keyboard keyboard = Keyboard.current;

        if (keyboard != null)
        {
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
            {
                moveInput.y += 1f;
            }

            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
            {
                moveInput.y -= 1f;
            }

            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            {
                moveInput.x -= 1f;
            }

            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            {
                moveInput.x += 1f;
            }
        }

        moveInput = moveInput.normalized;

        bool isMoving = moveInput != Vector2.zero;

        if (isMoving)
        {
            lastDirection = moveInput;
        }

        if (animator != null)
        {
            animator.SetFloat("X", lastDirection.x);
            animator.SetFloat("Y", lastDirection.y);
            animator.SetBool("Walk", isMoving);
            animator.SetBool("Idle", !isMoving);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}