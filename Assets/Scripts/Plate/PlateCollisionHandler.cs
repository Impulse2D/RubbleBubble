using System;
using UnityEngine;

namespace Plate
{
    public class PlateCollisionHandler : MonoBehaviour
    {
        public event Action CollisionDetected;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision != null)
            {
                CollisionDetected?.Invoke();
            }
        }
    }
}
