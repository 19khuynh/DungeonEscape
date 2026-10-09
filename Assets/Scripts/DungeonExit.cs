using UnityEngine;

public class DungeonExit : MonoBehaviour
{
    private bool hasWon = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasWon)
        {
            return;
        }

        PlayerInventory inventory =
            other.GetComponentInParent<PlayerInventory>();

        if (inventory == null)
        {
            return;
        }

        if (inventory.hasKey)
        {
            hasWon = true;

            Debug.Log("You escaped! You win!");

            DungeonPlayerMovement movement =
                inventory.GetComponent<DungeonPlayerMovement>();

            if (movement != null)
            {
                movement.enabled = false;
            }

            Rigidbody2D rb = inventory.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }

            Animator animator =
                inventory.GetComponentInChildren<Animator>();

            if (animator != null)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", true);
            }
        }
        else
        {
            Debug.Log("The exit is locked. Find the key!");
        }
    }
}