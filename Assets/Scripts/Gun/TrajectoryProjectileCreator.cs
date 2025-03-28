using Bullets;
using UnityEngine;

namespace Gun
{
    public class TrajectoryProjectileCreator : MonoBehaviour
    {
        [SerializeField] private TrajectoryVisualizer _trajectoryVisualizer;
        [SerializeField] private Gunner _gunner;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private BulletsReloader _projectileReloader;

        private void OnEnable()
        {
            _inputReader.AimingEnabled += EnableTrajectoryProjectile;
            _inputReader.AimingDisabled += DisableTrajectoryProjectile;
        }

        private void OnDisable()
        {
            _inputReader.AimingEnabled -= EnableTrajectoryProjectile;
            _inputReader.AimingDisabled += DisableTrajectoryProjectile;
        }

        private void TryShowTrajectoryProjectile()
        {
            _trajectoryVisualizer.EnableLinear();
            _trajectoryVisualizer.ShowTrajectory(transform.position, _gunner.ForceProjectile);

            if (_projectileReloader.CurrentBullet != null)
            {
                _trajectoryVisualizer.SetColor(_projectileReloader.CurrentBullet.Color);
            }
        }

        private void EnableTrajectoryProjectile()
        {
            _trajectoryVisualizer.EnableLinear();
            TryShowTrajectoryProjectile();
        }

        private void DisableTrajectoryProjectile()
        {
            _trajectoryVisualizer.DisableLinear();
        }
    }
}
