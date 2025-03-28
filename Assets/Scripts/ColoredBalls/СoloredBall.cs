using System;
using System.Collections;
using LayerSpheres;
using UnityEngine;

namespace ColoredBalls
{
    public class ColoredBall : Ball
    {
        private const string ResidentSphere = "ResidentSphere";
        private const string Ball = "Ball";

        [SerializeField] private Vector3 _force;

        private LayerSphere _currentLayerSphere;
        private bool _isCollision;
        private Coroutine _coroutine;
        private Vector3 _defaultScale;

        public event Action<ColoredBall> CollisionDetected;
        public event Action<ColoredBall> Released;
        public event Action<ColoredBall> Deactivated;

        public LayerSphere LayerSphere => _currentLayerSphere;
        public bool IsCollision => _isCollision;

        private void OnDisable()
        {
            _defaultScale = new Vector3(0.2699991f, 0.2699991f, 0.2699991f);

            EnableLayerMaskResidentSphere();

            _isCollision = false;

            Deactivated?.Invoke(this);
        }

        public void TryFallDown(float delay)
        {
            if (_currentLayerSphere == null)
                return;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(CountDownFallDown(delay));
        }

        public void SetLayerSphere(LayerSphere layerSphere)
        {
            _currentLayerSphere = layerSphere;
        }

        public void EnableIsCollision()
        {
            _isCollision = true;

            CollisionDetected?.Invoke(this);
        }

        public void DisableLayerMaskResidentSphere()
        {
            SetNameLayerMask(Ball);
        }

        public void FallDown()
        {
            DisableKinematic();

            transform.SetParent(null);
            transform.localScale = _defaultScale;

            Rigidbody.AddForce(_force, ForceMode.VelocityChange);

            _currentLayerSphere.RemoveColoredBall(this);

            Released?.Invoke(this);
        }

        private IEnumerator CountDownFallDown(float delay)
        {
            WaitForSeconds timeWait = new WaitForSeconds(delay);

            yield return timeWait;

            FallDown();
        }

        private void EnableLayerMaskResidentSphere()
        {
            SetNameLayerMask(ResidentSphere);
        }

        private void SetNameLayerMask(string nameLayerMask)
        {
            gameObject.layer = LayerMask.NameToLayer(nameLayerMask);
        }
    }
}