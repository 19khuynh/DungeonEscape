using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject titlePanel;
    public DungeonPlayerMovement playerMovement;
    public EnemyChase enemyChase;

    void Start()
    {
        titlePanel.SetActive(true);

        playerMovement.enabled = false;
        enemyChase.enabled = false;

        playerMovement.GetComponent<Rigidbody2D>().linearVelocity =
            Vector2.zero;

        enemyChase.GetComponent<Rigidbody2D>().linearVelocity =
            Vector2.zero;
    }

    public void StartGame()
    {
        playerMovement.enabled = true;
        enemyChase.enabled = true;

        titlePanel.SetActive(false);
    }
}