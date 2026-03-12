using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action OnCollideWithHazard;
    public event Action OnCollideWithObstacle;

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            OnCollideWithHazard?.Invoke();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            OnCollideWithObstacle?.Invoke();
        }
    }
}
