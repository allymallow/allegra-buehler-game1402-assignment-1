using UnityEngine;

public class Collector : MonoBehaviour
{
    //determining if the object hit is a collectable or not
    void OnTriggerEnter2D(Collider2D other)
    {
        ICollectable otherCollectable = other.GetComponent<ICollectable>();

        if (otherCollectable != null)
        {
            otherCollectable.OnCollect(); // if object is a collectable, begin OnCollect
        }
    }
}
