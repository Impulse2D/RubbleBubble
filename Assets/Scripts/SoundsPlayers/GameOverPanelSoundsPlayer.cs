using PanelGameOver;
using UnityEngine;

namespace SoundsPlayers
{
    public class GameOverPanelSoundsPlayer : SoundsPlayer
    {
        [SerializeField] private GameOverPanelOpener _gameOverPanelOpener;

        private void OnEnable()
        {
            _gameOverPanelOpener.PanelOpened += PlaySound;
            PauseService.FocusOnPauseNotDetected += StopSound;
        }

        private void OnDisable()
        {
            _gameOverPanelOpener.PanelOpened -= PlaySound;
            PauseService.FocusOnPauseNotDetected -= StopSound;
        }

        public override void PlaySound()
        {
            SoundsService.PlaySoundOneShot(AudioSource, AudioClip);
        }
    }
}
