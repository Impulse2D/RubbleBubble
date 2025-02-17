using Services;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace AuthorizationPanels
{
    public class PausePanelAuthorizationView : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private PausePanelAuthorization _pausePanelAuthorization;
        [SerializeField] private Button _buttonClosePausePanelAuthorization;
        [SerializeField] private LevelService _levelService;
        [SerializeField] private PauseService _pauseService;
        [SerializeField] private ScenesService _scenesService;

        private void OnEnable()
        {
            _buttonClosePausePanelAuthorization.onClick.AddListener(TakeActionBasedHeAutorizingStatus);
        }

        private void OnDisable()
        {
            _buttonClosePausePanelAuthorization.onClick.RemoveListener(TakeActionBasedHeAutorizingStatus);
        }

        private void TakeActionBasedHeAutorizingStatus()
        {
            if (YandexGame.auth == true)
            {
                _pauseService.DisablePause();

                _scenesService.LoadLoadingScene();
            }
            else
            {
                Hide();
            }
        }

        private void Hide()
        {
            _objectsChangerService.DisableObject(_pausePanelAuthorization.gameObject);

            _pauseService.DisablePause();
        }
    }
}
