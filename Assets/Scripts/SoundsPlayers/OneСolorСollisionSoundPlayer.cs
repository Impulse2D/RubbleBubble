using ColoredBalls;
using UnityEngine;

namespace SoundsPlayers
{
    public class OneСolorСollisionSoundPlayer : SoundsPlayer
    {
        [SerializeField] private ColoredBallsSeparator _coloredBallsSeparator;

        private void OnEnable()
        {
            _coloredBallsSeparator.AttemptedTearOffEnabled += PlaySound;

            PauseService.PauseEnabled += StopSound;
        }

        private void OnDisable()
        {
            _coloredBallsSeparator.AttemptedTearOffEnabled -= PlaySound;

            PauseService.PauseEnabled -= StopSound;
        }

        public override void PlaySound()
        {
            float minValuePitch = 0.9f;
            float maxValuePitch = 1.1f;

            StopSound();

            AudioSource.pitch = Random.Range(minValuePitch, maxValuePitch);

            SoundsService.PlaySound(AudioSource);
        }
    }
}
