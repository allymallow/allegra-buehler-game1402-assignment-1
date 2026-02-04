using UnityEngine;

public class Health : MonoBehaviour, ICollectable
{
    [SerializeField] private AudioSource healthSound;
    public void OnCollect()
    {
        healthSound.Play();
        
        Destroy(gameObject);
    }
}
