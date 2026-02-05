using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //defining variables for the platform and it's move points
    [SerializeField] private float cycleTime = 5f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private float _currentTime = 0f;
    private float _speed = 1f;
    
    void Update()
    {
        _currentTime += _speed * Time.deltaTime; //setting the correct time to ensure speed stays consistent and allow cycling 

        if(_currentTime > cycleTime) _speed = -1f; // setting direction based on cycle and current speed variable
        if(_currentTime < 0f) _speed = 1f;
        
        float t = _currentTime /  cycleTime; // defining the value for speed to be used in lerp 

        transform.position = Vector3.Lerp(pointA.position, pointB.position, t); // making the platform move between point A and B at a consistent speed
    }
}
