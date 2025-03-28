using Bullets;
using UnityEngine;

namespace Gun
{
    public class Gunner : MonoBehaviour
    {
        [SerializeField] private float _power = 12;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private BulletsReloader _projectileReloader;
        [SerializeField] private Vector3 _direction;

        private Camera _mainCamera;
        private Vector3 _forceProjectile;
        private Vector3 _endPositionProjectile;

        public Vector3 ForceProjectile => _forceProjectile;

        public void Init()
        {
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            _inputReader.AimingReleased += SetTrajectoryPath;
            _inputReader.ShootReleased += TryReleaseProjectile;
            _inputReader.ReloadReleased += TryChangeProjectile;
            _inputReader.AimingCanceled += TryChangeProjectile;
        }

        private void OnDisable()
        {
            _inputReader.AimingReleased -= SetTrajectoryPath;
            _inputReader.ShootReleased -= TryReleaseProjectile;
            _inputReader.ReloadReleased -= TryChangeProjectile;
            _inputReader.AimingCanceled -= TryChangeProjectile;
        }

        private void TryChangeProjectile()
        {
            if (IsCurrentProjectile())
            {
                _projectileReloader.CurrentBullet.DisableKinematic();

                _projectileReloader.CurrentBullet.DeactiveMeshRenderer();

                _projectileReloader.Recharge();
            }
        }

        private void SetTrajectoryPath(Vector3 position)
        {
            float enter;

            Ray ray = _mainCamera.ScreenPointToRay(position);

            new Plane(_direction, transform.position).Raycast(ray, out enter);

            _endPositionProjectile = ray.GetPoint(enter);

            _forceProjectile = (_endPositionProjectile - transform.position) * _power;
        }

        private void TryReleaseProjectile()
        {
            if (IsCurrentProjectile())
            {
                _projectileReloader.CurrentBullet.SetForce(_forceProjectile);
                _projectileReloader.CurrentBullet.UseForce();

                _projectileReloader.Recharge();
            }
        }

        private bool IsCurrentProjectile()
        {
            return _projectileReloader.CurrentBullet != null;
        }
    }
}