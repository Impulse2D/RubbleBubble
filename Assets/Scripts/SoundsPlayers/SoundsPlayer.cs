using Services;
using UnityEngine;

namespace SoundsPlayers
{
    public abstract class SoundsPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsService _soundsService;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private PauseService _pauseService;

        public SoundsService SoundsService => _soundsService;
        public AudioSource AudioSource => _audioSource;
        public AudioClip AudioClip => _audioClip;
        public PauseService PauseService => _pauseService;

        public abstract void PlaySound();

        protected void StopSound()
        {
            _soundsService.StopSound(_audioSource);
        }
    }
}
