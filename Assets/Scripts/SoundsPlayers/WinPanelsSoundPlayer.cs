using LevelPanel;
using UnityEngine;

namespace SoundsPlayers
{
    public class WinPanelsSoundPlayer : SoundsPlayer
    {
        [SerializeField] private WinPanelOpener _winPanelOpener;

        private void OnEnable()
        {
            _winPanelOpener.PanelOpened += PlaySound;
            PauseService.FocusOnPauseNotDetected += StopSound;
        }

        private void OnDisable()
        {
            _winPanelOpener.PanelOpened -= PlaySound;
            PauseService.FocusOnPauseNotDetected -= StopSound;
        }


        public override void PlaySound()
        {
            SoundsService.PlaySoundOneShot(AudioSource, AudioClip);
        }
    }
}
