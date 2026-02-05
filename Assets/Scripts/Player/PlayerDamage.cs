using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
   [SerializeField] public int playerHealth = 10;
   [SerializeField] private int healthValue;
   [SerializeField] private int damageValue;

   
   //Player will take damage if hitting objects tagged as moving platforms (if squished) OR if hits spikes
   // will take health if player hits a health object, or immediate death if player falls beneath the level
   void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Moving Platform") || collision.gameObject.CompareTag("Spikes"))
      {
         TakeDamage(collision);
      }
      else if (collision.gameObject.tag == "Health")
      {
         playerHealth += healthValue;
      }
      else if (collision.gameObject.tag == "Fall Death")
         SceneManager.LoadScene("Loss Screen");
   }

   //Defining the damage the player can take as well as the death state
   void TakeDamage(Collider2D collision) 
   {
      if (playerHealth >= 2)
      {
         playerHealth -= damageValue;
      }
      else if (playerHealth == 0 || playerHealth <= 1)
      {
         Die();
      }

      void Die()
      {
         SceneManager.LoadScene("Loss Screen");
      }
   }
}
