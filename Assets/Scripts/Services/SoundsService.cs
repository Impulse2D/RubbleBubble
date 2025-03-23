using UnityEngine;

namespace Services
{
    public class SoundsService : MonoBehaviour
    {
        public void PlaySoundOneShot(AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }

        public void PlaySound(AudioSource audioSource)
        {
            audioSource.Play();
        }

        public void EnablePauseAudio(AudioSource audioSource)
        {
            audioSource.Pause();
        }

        public void StopSound(AudioSource audioSource)
        {
            audioSource.Stop();
        }
    }
}
