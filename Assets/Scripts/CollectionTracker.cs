using UnityEngine;

public class CollectionTracker : MonoBehaviour
{
    public int CollectedCount { get; private set; }
    
        private void OnEnable() => Collectables.OnCollected += HandleCollected;
        private void OnDisable() => Collectables.OnCollected -= HandleCollected;

        private void HandleCollected() => CollectedCount++;
}
