using UnityEngine;

namespace LayerSpheres
{
    public class ParentSphereRotator : MonoBehaviour
    {
        [SerializeField] private float _speedRotation = 10f;
        [SerializeField] private float _valueAxisXLocalRotation = 0f;
        [SerializeField] private float _valueAxisYLocalRotation = 0f;

        private void FixedUpdate()
        {
            Rotate();
        }

        private void Rotate()
        {
            transform.localRotation *= Quaternion.Euler(_valueAxisXLocalRotation, _speedRotation * Time.fixedDeltaTime, _valueAxisYLocalRotation);
        }
    }
}
