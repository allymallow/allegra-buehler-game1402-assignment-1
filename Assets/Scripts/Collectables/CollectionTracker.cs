using UnityEngine;

public class CollectionTracker : MonoBehaviour
{
    public int CollectedCount { get; private set; }

    //start the function to increment score when coin is collected 
    private void OnEnable()
    {
        Coin.OnCollected += HandleCollected;
    }

    //stop the function so score is not constantly incremented after one coin has been collected 
    private void OnDisable()
    {
        Coin.OnCollected -= HandleCollected;
    }
    
    // increment score when coins are collected 
   private void HandleCollected() 
    {
        CollectedCount++;
    }
}
