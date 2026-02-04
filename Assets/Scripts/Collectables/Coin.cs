using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public static event Action OnCollected;
    
    [SerializeField] private AudioSource _coinAudioSource;
    [SerializeField] private AudioClip _coinCollectSound;

        public void OnCollect()
    {
        _coinAudioSource.PlayOneShot(_coinCollectSound);
        
        OnCollected?.Invoke();
        
        StartCoroutine(ScaleAndDestroyCoin());
    }
        
    private IEnumerator ScaleAndDestroyCoin()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = originalScale * 1.5f;
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
