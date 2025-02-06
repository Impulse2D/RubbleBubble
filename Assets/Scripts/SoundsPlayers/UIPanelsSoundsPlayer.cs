public class UIPanelsSoundsPlayer : SoundsPlayer
{
    private void OnEnable()
    {
        PauseService.FocusOnPauseNotDetected += StopSound;
    }

    private void OnDisable()
    {
        PauseService.FocusOnPauseNotDetected -= StopSound;
    }

    public override void PlaySound()
    {
        SoundsService.PlaySound(AudioSource);
    }
}
