using System.Collections.Generic;
using UnityEngine;

namespace SoundsPlayers
{
    public class LevelsBackgroundMusicPlayer : BackgroundMusicPlayer
    {
        [SerializeField] private List<AudioClip> _audioClips;

        public void Init()
        {
            float minIndexAudioClip = 0f;
            float maxIndexAudioClip = _audioClips.Count;

            float randomAudioClip = Random.Range(minIndexAudioClip, maxIndexAudioClip);

            AudioSource.clip = _audioClips[(int)randomAudioClip];

            PlayMusic();
        }
    }

}