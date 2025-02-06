using UnityEngine;

public class BulletsReloaderSoundsPlayer : SoundsPlayer
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        PauseService.PauseDisabled += StopSound;
        _inputReader.ReloadReleased += PlaySound;
    }

    private void OnDisable()
    {
        PauseService.PauseDisabled -= StopSound;
        _inputReader.ReloadReleased -= PlaySound;
    }

    public override void PlaySound()
    {
        SoundsService.PlaySoundOneShot(AudioSource, AudioClip);
    }
}
