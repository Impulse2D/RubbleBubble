using Services;
using UnityEngine;

namespace SoundsPlayers
{
    public class BackgroundMusicPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsService _soundsService;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private PauseService _pauseService;

        public AudioSource AudioSource => _audioSource;
        private void OnEnable()
        {
            _pauseService.PauseEnabled += PauseEnable;
            _pauseService.PauseDisabled += PauseDisable;
        }

        private void OnDisable()
        {
            _pauseService.PauseEnabled -= PauseEnable;
            _pauseService.PauseDisabled -= PauseDisable;
        }

        protected void PlayMusic()
        {
            _soundsService.PlaySound(_audioSource);
        }

        private void PauseEnable()
        {
            _soundsService.EnablePauseAudio(_audioSource);
        }

        private void PauseDisable()
        {
            _soundsService.PlaySound(_audioSource);
        }
    }
}