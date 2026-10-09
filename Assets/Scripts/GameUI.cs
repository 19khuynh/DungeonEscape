using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public DungeonPlayerMovement playerMovement;
    public TMP_Text resultText;
    public GameObject restartButton;
    public GameObject titlePanel;

    void Start()
    {
        resultText.text = "";
        restartButton.SetActive(false);
    }

    void Update()
    {
        if (titlePanel != null && titlePanel.activeSelf)
        {
            resultText.text = "";
            restartButton.SetActive(false);
            return;
        }

        if (playerHealth.health <= 0)
        {
            resultText.text = "Game Over!";
            restartButton.SetActive(true);
        }
        else if (!playerMovement.enabled)
        {
            resultText.text = "You Escaped!";
            restartButton.SetActive(true);
        }
        else
        {
            resultText.text = "";
            restartButton.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }
}