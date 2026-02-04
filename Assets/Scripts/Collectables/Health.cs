using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour, ICollectable
{
    
    [SerializeField] private AudioSource _healthAudioSource;
    [SerializeField] private AudioClip _healthCollectSound;
  
    
    
    private IEnumerator ScaleAndDestroyHealth()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = originalScale * 1.5f;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public void OnCollect()
    {
        _healthAudioSource.PlayOneShot(_healthCollectSound);

        StartCoroutine(ScaleAndDestroyHealth());
    }

}