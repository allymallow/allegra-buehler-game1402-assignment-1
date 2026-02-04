using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public static event Action OnCollected;
    [SerializeField] private AudioSource coinSound;
    public void OnCollect()
    {
        coinSound.Play();
        OnCollected?.Invoke();
        
        Destroy(gameObject);
    }
}
