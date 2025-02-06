using System;
using UnityEngine;

public class GamePointsHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ColoredBall coloredBall))
        {
            ReportCollisionDetected();
        }

        if(other.TryGetComponent(out Bullet bullet))
        {
            if(bullet.IsOneColorCollision == true)
            {
                ReportCollisionDetected();
            }
        }
    }

    private void ReportCollisionDetected()
    {
        CollisionDetected?.Invoke();
    }
}
