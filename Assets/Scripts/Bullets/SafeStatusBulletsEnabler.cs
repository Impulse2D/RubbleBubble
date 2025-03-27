using System;
using LayerSpheres;
using Services;
using UnityEngine;

namespace Bullets
{
    public class SafeStatusBulletsEnabler : MonoBehaviour
    {
        [SerializeField] private LifeService _lifeService;
        [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstLayerSphere;

        private Collider _currentCollider;

        private void OnEnable()
        {
            _lifeService.LivesExhausted += TryRemoveAllProjectile;
        }

        private void OnDisable()
        {
            _lifeService.LivesExhausted -= TryRemoveAllProjectile;
        }

        private void TryRemoveAllProjectile()
        {
            float radius = 1000f;

            Collider[] overlappedColliders = Physics.OverlapSphere(_spawnPointFirstLayerSphere.transform.position, radius);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                _currentCollider = overlappedColliders[i];

                Action interactionWithProjectile = overlappedColliders[i] != null ? TryDisableIsMovedProjectile : null;
            }
        }

        private void TryDisableIsMovedProjectile()
        {
            if (_currentCollider.TryGetComponent(out Bullet projectile) && projectile.IsMoved == true)
            {
                projectile.DisableIsMoved();
            }
        }
    }
}
