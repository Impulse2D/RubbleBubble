using System;
using UnityEngine;

namespace Bullets
{
    [RequireComponent(typeof(Animator))]

    public class Bullet : Ball
    {
        private Vector3 _force;
        private bool _isMoved;
        private bool _isCriticalCollision;
        private bool _isOneColorCollision;
        private bool _isBallCollision;

        public event Action<Bullet> Released;
        public event Action<Bullet> CollisionDetected;

        public bool IsMoved => _isMoved;
        public bool IsCriticalCollision => _isCriticalCollision;

        public bool IsOneColorCollision => _isOneColorCollision;
        public bool IsBallCollision => _isBallCollision;

        private void OnDisable()
        {
            ActivateMeshRenderer();
        }

        public void ReportRelease()
        {
            Released?.Invoke(this);
        }

        public void SetForce(Vector3 force)
        {
            _force = force;
        }

        public void UseForce()
        {
            if (_force != null)
            {
                DisableKinematic();

                EnableIsMoved();

                Rigidbody.AddForce(_force, ForceMode.VelocityChange);
            }
        }

        public void EnableIsOneColorCollision()
        {
            _isOneColorCollision = true;
        }

        public void DisableIsOneColorCollision()
        {
            _isOneColorCollision = false;
        }

        public void DisableIsMoved()
        {
            _isMoved = false;
        }

        public void DeactiveMeshRenderer()
        {
            Renderer.enabled = false;
        }

        public void EnableCriticalCollision()
        {
            _isCriticalCollision = true;
        }

        public void DisableCriticalCollision()
        {
            _isCriticalCollision = false;
        }

        public void ReportCollisionDetected()
        {
            CollisionDetected?.Invoke(this);
        }

        public void EnableIsBallCollision()
        {
            _isBallCollision = true;
        }

        public void DisableIsBallCollision()
        {
            _isBallCollision = false;
        }

        private void EnableIsMoved()
        {
            _isMoved = true;
        }

        private void ActivateMeshRenderer()
        {
            Renderer.enabled = true;
        }
    }
}
