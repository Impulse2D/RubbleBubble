using Services;
using SoundsPlayers;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsPanelView : MonoBehaviour
    {
        [SerializeField] private Button _buttonSettingsOpener;
        [SerializeField] private Button _buttonSettingsClose;
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private CanvasSettings _canvasSettings;
        [SerializeField] private PauseService _pauseService;
        [SerializeField] private UIPanelsSoundsPlayer _uIPanelsSoundsPlayer;

        private void OnEnable()
        {
            _buttonSettingsOpener.onClick.AddListener(Show);
            _buttonSettingsClose.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            _buttonSettingsOpener.onClick.RemoveListener(Show);
            _buttonSettingsClose.onClick.RemoveListener(Hide);
        }

        private void Show()
        {
            _objectsChangerService.EnableObject(_canvasSettings.gameObject);
            _pauseService.EnablePause();
            _uIPanelsSoundsPlayer.PlaySound();
        }

        private void Hide()
        {
            _objectsChangerService.DisableObject(_canvasSettings.gameObject);
            _pauseService.DisablePause();
        }
    }
}
