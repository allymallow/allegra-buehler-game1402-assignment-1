using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
   
    [SerializeField] private ParticleSystem footstepEffect;
    [SerializeField] private string targetTag = "Ground";
    
    //on collision with ground, play footstep particle effect!
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(targetTag))
        {
            footstepEffect.Play();
        }
    }
    
    
    
}
