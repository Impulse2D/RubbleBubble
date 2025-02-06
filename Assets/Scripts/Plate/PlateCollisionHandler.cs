using System;
using UnityEngine;

public class PlateCollisionHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            CollisionDetected?.Invoke();
        }
    }
}
