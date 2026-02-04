using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
   [SerializeField] public int playerHealth = 10;
   [SerializeField] private int healthValue = 4;
   [SerializeField] private int damageValue = 5;
   
   void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.tag == "Moving Platform")
      {
         TakeDamage(collision);
      }
      else if (collision.gameObject.tag == "Health")
      {
         playerHealth += healthValue;
      }

   }

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
         Destroy(gameObject);
         SceneManager.LoadScene("Loss Screen");
      }
   }
}
