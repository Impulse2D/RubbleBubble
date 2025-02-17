using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using Services;

namespace SoundsPlayers
{
    public class SoundsCustomizer : MonoBehaviour
    {
        private const string MusicVolume = nameof(MusicVolume);
        private const string EffectsVolume = nameof(EffectsVolume);
        private const string MuteMusicVolumeStatus = nameof(MuteMusicVolumeStatus);
        private const string MuteEffectsVolumeStatus = nameof(MuteEffectsVolumeStatus);
        private const string MuteEnabled = nameof(MuteEnabled);
        private const string MuteDisabled = nameof(MuteDisabled);

        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private AudioMixerGroup _mixer;
        [SerializeField] private Toggle _toggleSwitchMusicVolume;
        [SerializeField] private Toggle _toggleSwitchEffectsVolume;
        [SerializeField] private Image _enabledMuteImageMusicVolume;
        [SerializeField] private Image _disabledMuteImageMusicVolume;
        [SerializeField] private Image _enabledMuteImageEffectsVolume;
        [SerializeField] private Image _disabledMuteImageEffectsVolume;

        private float _minValueVolumeSounds = -80f;
        private float _maxValueVolumeSounds = 0f;

        private string _statusMuteMusicVolume;
        private string _statusMuteEffectsVolume;

        private void OnEnable()
        {
            _toggleSwitchMusicVolume.onValueChanged.AddListener(SwitchMusicVolume);
            _toggleSwitchEffectsVolume.onValueChanged.AddListener(SwitchEffectsVolume);
        }

        private void OnDisable()
        {
            _toggleSwitchMusicVolume.onValueChanged.RemoveListener(SwitchMusicVolume);
            _toggleSwitchEffectsVolume.onValueChanged.RemoveListener(SwitchEffectsVolume);
        }

        public void Init()
        {
            _statusMuteMusicVolume = PlayerPrefs.GetString(MuteMusicVolumeStatus);
            _statusMuteEffectsVolume = PlayerPrefs.GetString(MuteEffectsVolumeStatus);

            LoadSavedDataMusicVolumeSettings();
            LoadSavedDataEffectsVolumeSettings();
        }

        private void LoadSavedDataMusicVolumeSettings()
        {
            if (_statusMuteMusicVolume == MuteEnabled)
            {
                SetIsOnToggleSwitchVolume(_toggleSwitchMusicVolume, false);

                EnableMute(MusicVolume, _enabledMuteImageMusicVolume, _disabledMuteImageMusicVolume);
            }
            else
            {
                SetIsOnToggleSwitchVolume(_toggleSwitchMusicVolume, true);

                DisableMute(MusicVolume, _enabledMuteImageMusicVolume, _disabledMuteImageMusicVolume);
            }
        }

        private void LoadSavedDataEffectsVolumeSettings()
        {
            if (_statusMuteEffectsVolume == MuteEnabled)
            {
                SetIsOnToggleSwitchVolume(_toggleSwitchEffectsVolume, false);

                EnableMute(EffectsVolume, _enabledMuteImageEffectsVolume, _disabledMuteImageEffectsVolume);
            }
            else
            {
                SetIsOnToggleSwitchVolume(_toggleSwitchEffectsVolume, true);

                DisableMute(EffectsVolume, _enabledMuteImageEffectsVolume, _disabledMuteImageEffectsVolume);
            }
        }

        private void SetIsOnToggleSwitchVolume(Toggle toggle, bool isOnToggleSwitchMusicVolume)
        {
            toggle.isOn = isOnToggleSwitchMusicVolume;
        }

        private void SwitchMusicVolume(bool enabled)
        {
            SwitchVolume(MusicVolume, MuteMusicVolumeStatus, _enabledMuteImageMusicVolume, _disabledMuteImageMusicVolume, enabled);
        }

        private void SwitchEffectsVolume(bool enabled)
        {
            SwitchVolume(EffectsVolume, MuteEffectsVolumeStatus, _enabledMuteImageEffectsVolume, _disabledMuteImageEffectsVolume, enabled);
        }

        private void SwitchVolume(string nameMixerParametr, string statusMute, Image enabledMute, Image disabledMute, bool isEnabled)
        {
            if (isEnabled == true)
            {
                DisableMute(nameMixerParametr, enabledMute, disabledMute);

                SaveToggleVolumeData(statusMute, MuteDisabled);
            }
            else
            {
                EnableMute(nameMixerParametr, enabledMute, disabledMute);

                SaveToggleVolumeData(statusMute, MuteEnabled);
            }
        }

        private void DisableMute(string nameMixerParametr, Image enabledMute, Image disabledMute)
        {
            SetFloatMixer(nameMixerParametr, _maxValueVolumeSounds);

            SwitchImages(enabledMute, disabledMute);
        }

        private void EnableMute(string nameMixerParametr, Image enabledMute, Image disabledMute)
        {
            SetFloatMixer(nameMixerParametr, _minValueVolumeSounds);

            SwitchImages(disabledMute, enabledMute);
        }

        private void SwitchImages(Image firstStatusMuteImage, Image secondtStatusMuteImage)
        {
            _objectsChangerService.DisableObject(firstStatusMuteImage.gameObject);
            _objectsChangerService.EnableObject(secondtStatusMuteImage.gameObject);
        }

        private void SaveToggleVolumeData(string statusMute, string nameStatusMute)
        {
            PlayerPrefs.SetString(statusMute, nameStatusMute);
            PlayerPrefs.Save();
        }

        private void SetFloatMixer(string nameMixerParametr, float valueVolumeSound)
        {
            _mixer.audioMixer.SetFloat(nameMixerParametr, valueVolumeSound);
        }
    }
}
