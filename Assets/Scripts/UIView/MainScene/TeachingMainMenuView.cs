using Services;
using SoundsPlayers;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class TeachingMainMenuView : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private TeachingPanelCanvas _teachingPanelCanvas;
        [SerializeField] private Button _teachingPanelOpenerButton;
        [SerializeField] private Button _teachingPanelCloserButton;
        [SerializeField] private PauseService _pauseService;
        [SerializeField] private UIPanelsSoundsPlayer _uIPanelsSoundsPlayer;

        private void OnEnable()
        {
            _teachingPanelOpenerButton.onClick.AddListener(Show);
            _teachingPanelCloserButton.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            _teachingPanelOpenerButton.onClick.RemoveListener(Show);
            _teachingPanelCloserButton.onClick.RemoveListener(Hide);
        }

        private void Show()
        {
            _objectsChangerService.EnableObject(_teachingPanelCanvas.gameObject);

            _pauseService.EnablePause();

            _uIPanelsSoundsPlayer.PlaySound();
        }

        private void Hide()
        {
            _objectsChangerService.DisableObject(_teachingPanelCanvas.gameObject);

            _pauseService.DisablePause();
        }
    }
}
