using UnityEngine;
using TMPro;

public class KeyDisplay : MonoBehaviour
{
    public PlayerInventory inventory;
    public TMP_Text keyText;

    void Update()
    {
        if (inventory == null || keyText == null)
        {
            return;
        }

        if (inventory.hasKey)
        {
            keyText.text = "Key collected! Reach the door.";
            keyText.color = Color.green;
        }
        else
        {
            keyText.text = "Find the yellow key!";
            keyText.color = Color.white;
        }
    }
}