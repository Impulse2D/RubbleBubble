using Services;
using UnityEngine;
using UnityEngine.UI;

namespace PausePanelView
{
    public class PausePanelView : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private PausePanel _pausePanel;
        [SerializeField] private PauseService _pauseService;
        [SerializeField] private Button _buttonClosePausePanel;

        private void OnEnable()
        {
            _buttonClosePausePanel.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            _buttonClosePausePanel.onClick.RemoveListener(Hide);
        }

        private void Hide()
        {
            _objectsChangerService.DisableObject(_pausePanel.gameObject);
            _pauseService.DisablePause();
        }
    }
}
