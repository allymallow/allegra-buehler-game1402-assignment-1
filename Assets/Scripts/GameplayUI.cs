using UnityEngine;
using TMPro;

public class GameplayUI : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI scoreText;
[SerializeField] private TextMeshProUGUI healthText;

[SerializeField] private PlayerDamage player;
[SerializeField] private CollectionTracker collectionTracker;


void Update()
    {
    UpdateUI(); // Update the UI consistently as the game plays
    }

void UpdateUI()
    {
    if (healthText != null && player != null)
        healthText.text = $"Current Health: {player.playerHealth}"; // updating UI based on the player's health
    
    if (scoreText != null && collectionTracker != null)
        scoreText.text = $"Score: {collectionTracker.CollectedCount}"; // updating Score based on the collection tracker

    }
}
