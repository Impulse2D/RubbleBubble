using ColoredBalls;
using UnityEngine;

namespace SoundsPlayers
{
    public class OneСolorСollisionSoundPlayer : SoundsPlayer
    {
        [SerializeField] private ColoredBallsSeparator _coloredBallsSeparator;

        [SerializeField] float _minValuePitch = 0.9f;
        [SerializeField] float _maxValuePitch = 1.1f;

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
            StopSound();    

            AudioSource.pitch = Random.Range(_minValuePitch, _maxValuePitch);
            SoundsService.PlaySound(AudioSource);
        }
    }
}
