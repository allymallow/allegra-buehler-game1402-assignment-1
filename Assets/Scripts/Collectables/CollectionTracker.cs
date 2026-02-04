using System;
using UnityEngine;
using System.Collections;

public class CollectionTracker : MonoBehaviour
{
    public int CollectedCount { get; private set; }

    private void OnEnable()
    {
        Coin.OnCollected += HandleCollected;
    }

    private void OnDisable()
    {
        Coin.OnCollected -= HandleCollected;
    }

   private void HandleCollected()
    {
        CollectedCount++;
    }
}
