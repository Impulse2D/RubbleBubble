using SoundsPlayers;
using UnityEngine;

namespace Plate
{
    public class PlateSoundsPlayer : SoundsPlayer
    {
        [SerializeField] private PlateCollisionHandler _collisionHandler;

        private void OnEnable()
        {
            _collisionHandler.CollisionDetected += PlaySound;
            PauseService.PauseEnabled += StopSound;
        }

        private void OnDisable()
        {
            _collisionHandler.CollisionDetected -= PlaySound;
            PauseService.PauseEnabled -= StopSound;
        }

        public override void PlaySound()
        {
            SoundsService.PlaySoundOneShot(AudioSource, AudioClip);
        }
    }
}
