using System;
using UnityEngine;
using DG.Tweening;

public class Collectables : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private int collectedCount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    public static event Action OnCollected;
    
    private void Collect()
    {
     OnCollected?.Invoke();
    }
}
