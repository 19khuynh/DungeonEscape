using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        DamagePlayer(collision);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        DamagePlayer(collision);
    }

    void DamagePlayer(Collision2D collision)
    {
        PlayerHealth playerHealth =
            collision.gameObject.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage();
        }
    }
}