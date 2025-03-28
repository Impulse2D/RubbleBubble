using Bullets;
using UnityEngine;

namespace SoundsPlayers
{
    public class BulletsSoundsPlayer : SoundsPlayer
    {
        [SerializeField] private SpawnerBullets _spawnerBullets;
        [SerializeField] private float _minValuePitch = 0.9f;
        [SerializeField] private float _maxValuePitch = 1.1f;

        private void OnEnable()
        {
            _spawnerBullets.ProjectileCollisionDetected += PlaySound;
            PauseService.PauseDisabled += StopSound;
        }

        private void OnDisable()
        {
            _spawnerBullets.ProjectileCollisionDetected -= PlaySound;
            PauseService.PauseDisabled -= StopSound;
        }

        public override void PlaySound()
        {
            AudioSource.pitch = Random.Range(_minValuePitch, _maxValuePitch);
            SoundsService.PlaySoundOneShot(AudioSource, AudioClip);
        }
    }
}
