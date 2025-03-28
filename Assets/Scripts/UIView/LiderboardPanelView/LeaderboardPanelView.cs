using AuthorizationPanels;
using Services;
using SoundsPlayers;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace LiderboardPanelView
{
    public class LeaderboardPanelView : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private LeaderBoardService _leaderboardService;
        [SerializeField] private LeaderboardPanel _liderBoard;
        [SerializeField] private Button _buttonOpenLeaderboardPanel;
        [SerializeField] private Button _buttonCloseLeaderboardPanel;
        [SerializeField] private PauseService _pauseService;
        [SerializeField] private AuthorizationOfferPanel _authorizationOfferPanel;
        [SerializeField] private UIPanelsSoundsPlayer _uIPanelsSoundsPlayer;

        private void OnEnable()
        {
            _buttonOpenLeaderboardPanel.onClick.AddListener(TryShow);
            _buttonCloseLeaderboardPanel.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            _buttonOpenLeaderboardPanel.onClick.RemoveListener(TryShow);
            _buttonCloseLeaderboardPanel.onClick.RemoveListener(Hide);
        }

        private void TryShow()
        {
            if (YandexGame.auth == true)
            {
                ReactToAuthorizationStatus(_liderBoard.gameObject);
            }
            else
            {
                ReactToAuthorizationStatus(_authorizationOfferPanel.gameObject);
            }
        }

        private void Hide()
        {
            _objectsChangerService.DisableObject(_liderBoard.gameObject);
            _pauseService.DisablePause();
        }

        private void ReactToAuthorizationStatus(GameObject gameObject)
        {
            _objectsChangerService.EnableObject(gameObject);
            _pauseService.EnablePause();
            _uIPanelsSoundsPlayer.PlaySound();
        }
    }
}
