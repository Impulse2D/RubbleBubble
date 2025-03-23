using UnityEngine;

namespace LayerSpheres
{
    public class ParentSphereRotator : MonoBehaviour
    {
        private float _speedRotation = 10f;

        private void FixedUpdate()
        {
            Rotate();
        }

        private void Rotate()
        {
            transform.localRotation *= Quaternion.Euler(0f, _speedRotation * Time.fixedDeltaTime, 0f);
        }
    }
}
