using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public float damageCooldown = 1f;

    private float nextDamageTime;
    private DungeonPlayerMovement movement;
    private SpriteRenderer playerSprite;
    private Color originalColor;

    void Awake()
    {
        movement = GetComponent<DungeonPlayerMovement>();

        playerSprite = transform.Find("Model")
            .GetComponent<SpriteRenderer>();

        originalColor = playerSprite.color;
    }

    public void TakeDamage()
    {
        if (health <= 0 || !movement.enabled)
        {
            return;
        }

        if (Time.time < nextDamageTime)
        {
            return;
        }

        nextDamageTime = Time.time + damageCooldown;
        health--;

        StartCoroutine(FlashRed());

        Debug.Log("Health remaining: " + health);

        if (health == 0)
        {
            movement.enabled = false;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

            Animator animator = GetComponentInChildren<Animator>();

            if (animator != null)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", true);
            }

            Debug.Log("Game Over!");
        }
    }

    IEnumerator FlashRed()
    {
        playerSprite.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        playerSprite.color = originalColor;
    }
}