using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour, ICollectable
{
    // variables for sound effects
    [SerializeField] private AudioSource _healthAudioSource;
    [SerializeField] private AudioClip _healthCollectSound;
  
    
    // coroutine for destroying the object after collection
    private IEnumerator ScaleAndDestroyHealth()
    {
        Vector3 originalScale = transform.localScale; // creating new transform info to change size of object
        transform.localScale = originalScale * 1.5f; // change object to 1.5 it's normal size
        yield return new WaitForSeconds(1f); // wait to allow effect to play
        Destroy(gameObject); // destory object
    }

    // method when health object is collected - play sound, start coroutine to destroy 
    public void OnCollect()
    {
        _healthAudioSource.PlayOneShot(_healthCollectSound);

        StartCoroutine(ScaleAndDestroyHealth());
    }

}