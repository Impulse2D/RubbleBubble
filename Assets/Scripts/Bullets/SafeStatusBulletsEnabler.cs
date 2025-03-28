using LayerSpheres;
using Services;
using UnityEngine;

namespace Bullets
{
    public class SafeStatusBulletsEnabler : MonoBehaviour
    {
        [SerializeField] private LifeService _lifeService;
        [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstLayerSphere;

        private float _radius;

        private void OnEnable()
        {
            _radius = 1000;

            _lifeService.LivesExhausted += TryRemoveAllProjectile;
        }

        private void OnDisable()
        {
            _lifeService.LivesExhausted -= TryRemoveAllProjectile;
        }

        private void TryRemoveAllProjectile()
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(_spawnPointFirstLayerSphere.transform.position, _radius);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                if (overlappedColliders[i] == null) continue;
                if (overlappedColliders[i].TryGetComponent(out Bullet projectile) == false) continue;
                if (projectile.IsMoved == false) continue;

                projectile.DisableIsMoved();
            }
        }
    }
}
