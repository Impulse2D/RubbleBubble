using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LeaderboardPanelChanger : ObjectsChanger
{
    [SerializeField] private LeaderBoardService _leaderboardService;
    [SerializeField] private LeaderboardPanel _liderBoard;
    [SerializeField] private Button _buttonOpenLeaderboardPanel;
    [SerializeField] private Button _buttonCloseLeaderboardPanel;
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private AuthorizationOfferPanel _authorizationOfferPanel;

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
        DisableObject(_liderBoard.gameObject);

        _pauseService.DisablePause();
    }

    private void ReactToAuthorizationStatus(GameObject gameObject)
    {
        EnabledObject(gameObject);

        _pauseService.EnablePause();
    }
}
