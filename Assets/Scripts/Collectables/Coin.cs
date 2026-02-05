using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public static event Action OnCollected;
    
    //setting variables for sound effects
    [SerializeField] private AudioSource _coinAudioSource;
    [SerializeField] private AudioClip _coinCollectSound;

        //Collection method: once player hits trigger, play sound, collect and add to score, destroy,
        public void OnCollect()
    {
        _coinAudioSource.PlayOneShot(_coinCollectSound);
        
        OnCollected?.Invoke();
        
        StartCoroutine(ScaleAndDestroyCoin());
    }
        
    private IEnumerator ScaleAndDestroyCoin()
    {
        Vector3 originalScale = transform.localScale; // create new variable to store transform info to allow size change
        transform.localScale = originalScale * 1.5f; // make the coins bigger to signal they've been hit 
        yield return new WaitForSeconds(0.8f); // hold for a second to allow change to be visible in game
        Destroy(gameObject); // then destroy the object 
    }
}
