using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
   [SerializeField] public int playerHealth = 10;

   void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.tag == "Moving Platform")
      {
         TakeDamage(collision);
      }

   }

   void TakeDamage(Collider2D collision)
   {
      if (playerHealth >= 5)
      {
         playerHealth = -5;
      }
      else
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
