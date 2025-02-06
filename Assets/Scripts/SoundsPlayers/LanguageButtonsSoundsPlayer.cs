using UnityEngine;
using UnityEngine.UI;

public class LanguageButtonsSoundsPlayer : SoundsPlayer
{
    [SerializeField] private ObjectsChangerService _objectsChangerService;
    [SerializeField] private Button _ruLanguageButton;
    [SerializeField] private Button _enLanguageButton;
    [SerializeField] private Button _trLanguageButton;

    private void OnEnable()
    {
        _ruLanguageButton.onClick.AddListener(PlaySound);
        _enLanguageButton.onClick.AddListener(PlaySound);
        _trLanguageButton.onClick.AddListener(PlaySound);

        PauseService.FocusOnPauseNotDetected += StopSound;
    }

    private void OnDisable()
    {
        _ruLanguageButton.onClick.RemoveListener(PlaySound);
        _enLanguageButton.onClick.RemoveListener(PlaySound);
        _trLanguageButton.onClick.RemoveListener(PlaySound);

        PauseService.FocusOnPauseNotDetected -= StopSound;
    }

    public override void PlaySound()
    {
        SoundsService.PlaySoundOneShot(AudioSource, AudioClip);
    }
}
