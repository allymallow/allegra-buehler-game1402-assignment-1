using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameplayUI : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI scoreText;
[SerializeField] private TextMeshProUGUI healthText;

private PlayerDamage _player;
private CollectionTracker _collectionTracker;
void Update()
{
    UpdateUI(); // Update the UI consistently as the game plays
}

void UpdateUI()
{
    if (healthText != null && _player != null)
        healthText.text = $"Current Health: {_player.playerHealth}";
    
    if (scoreText != null && _collectionTracker != null)
        scoreText.text = $"Score: {_collectionTracker.CollectedCount}";

}
}
