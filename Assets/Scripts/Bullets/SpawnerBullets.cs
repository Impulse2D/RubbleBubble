using System;
using UnityEngine;

namespace Bullets
{
    public class SpawnerBullets : Spawner<BulletsPool>
    {
        [SerializeField] private MaterialsDispenser _materialsDispenser;
        [SerializeField] private int _valueLengthSubtracted;
        [SerializeField] private int _minValueIndex;

        private int _index;

        public event Action<Bullet> ProjectileCreated;
        public event Action CriticalCollisionProjectileReported;
        public event Action ProjectileCollisionDetected;

        public Bullet GetCreatedProjectile(Vector3 position, Quaternion rotation)
        {
            if (_index >= _materialsDispenser.MaterialsColoredBalls.Count - _valueLengthSubtracted)
            {
                ResetIndexMaterialsColoredBalls(_minValueIndex);
            }
            else
            {
                _index++;
            }

            Bullet newProjectile = ObjectsPool.GetObject(position, rotation);

            newProjectile.SetMaterial(_materialsDispenser.MaterialsColoredBalls[_index]);
            newProjectile.DisableIsMoved();
            newProjectile.CollisionDetected += ReportCollisionDetectedProjectile;

            ReportProjectileCreated(newProjectile);

            return newProjectile;
        }

        private void ResetIndexMaterialsColoredBalls(int minValueIndex)
        {
            _index = minValueIndex;
        }

        private void ReportProjectileCreated(Bullet newProjectile)
        {
            ProjectileCreated?.Invoke(newProjectile);
        }

        private void ReportCollisionDetectedProjectile(Bullet newProjectile)
        {
            newProjectile.CollisionDetected -= ReportCollisionDetectedProjectile;

            if (newProjectile.IsCriticalCollision == true)
            {
                CriticalCollisionProjectileReported?.Invoke();
            }

            if (newProjectile.IsBallCollision == true)
            {
                ProjectileCollisionDetected?.Invoke();
            }
        }
    }
}
