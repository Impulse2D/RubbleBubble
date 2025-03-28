using System.Collections.Generic;
using UnityEngine;

namespace SoundsPlayers
{
    public class LevelsBackgroundMusicPlayer : BackgroundMusicPlayer
    {
        [SerializeField] private List<AudioClip> _audioClips;
        [SerializeField] private float _minIndexAudioClip = 0f;

        private float _maxIndexAudioClip;

        public void Init()
        {
            _maxIndexAudioClip = _audioClips.Count;

            float randomAudioClip = Random.Range(_minIndexAudioClip, _maxIndexAudioClip);

            AudioSource.clip = _audioClips[(int)randomAudioClip];
            PlayMusic();
        }
    }
}