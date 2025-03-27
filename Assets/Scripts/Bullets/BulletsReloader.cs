using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets
{
    public class BulletsReloader : MonoBehaviour
    {
        [SerializeField] private SpawnerBullets _spawnerBullets;
        [SerializeField] private List<SpawnPointBullet> _spawnPointBullets;
        [SerializeField] private BulletsPool _bulletsPool;

        private Bullet _currentBullet;
        private List<Bullet> _bullets;
        private Coroutine _coroutine;
        private Vector3 _mainBulletPosition;
        private Vector3 _nextBulletPosition;
        public Bullet CurrentBullet => _currentBullet;

        public void Init()
        {
            _bullets = new List<Bullet>();

            _mainBulletPosition = _spawnPointBullets[0].transform.position;
            _nextBulletPosition = _spawnPointBullets[1].transform.position;

            for (int i = 0; i < _spawnPointBullets.Count; i++)
            {
                Bullet bullet = _spawnerBullets.GetCreatedProjectile(_spawnPointBullets[i].transform.position, Quaternion.identity);

                _bullets.Add(bullet);
            }

            SetCurrentProjectile(_bullets[0]);
        }

        public void Recharge()
        {
            _bullets.Remove(_bullets[0]);

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(MoveProjectile(_bullets[0]));

            SetCurrentProjectile(_bullets[0]);

            CreateNewProjectile();
        }

        private IEnumerator MoveProjectile(Bullet projectiles)
        {
            float speedMovementProjectile = 15f;

            while (projectiles.transform.position != _mainBulletPosition)
            {
                projectiles.transform.position = Vector3.Lerp(projectiles.transform.position, _mainBulletPosition, speedMovementProjectile * Time.deltaTime);

                yield return null;
            }
        }

        private void CreateNewProjectile()
        {
            Bullet newBullet = _spawnerBullets.GetCreatedProjectile(_nextBulletPosition, Quaternion.identity);

            _bullets.Add(newBullet);
        }

        private void SetCurrentProjectile(Bullet projectile)
        {
            _currentBullet = projectile;
        }
    }
}
