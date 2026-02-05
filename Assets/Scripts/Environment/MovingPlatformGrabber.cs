using UnityEngine;

public class MovingPlatformGrabber : MonoBehaviour
{
  //using tags determine if the player is within the trigger - if so temporarily set as child of the platform to make them move together
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      other.transform.SetParent(transform);
    }
  }
//once player leaves the trigger box, remove it as a child of the platform
  void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      other.transform.SetParent(null);
    }
  }
}
