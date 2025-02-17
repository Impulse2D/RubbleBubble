using UnityEngine;

namespace Bullets
{
    public class BulletsDisabler : MonoBehaviour
    {
        [SerializeField] private SpawnerBullets _spawnerBullets;
        [SerializeField] private BulletsPool _bulletsPool;

        private void OnEnable()
        {
            _spawnerBullets.ProjectileCreated += SetProjectile;
        }

        private void OnDisable()
        {
            _spawnerBullets.ProjectileCreated -= SetProjectile;
        }

        private void SetProjectile(Bullet projectile)
        {
            projectile.Released += RemoveProjectile;
        }

        private void RemoveProjectile(Bullet projectile)
        {
            projectile.Released -= RemoveProjectile;

            _bulletsPool.ReturnObject(projectile);
        }
    }
}
