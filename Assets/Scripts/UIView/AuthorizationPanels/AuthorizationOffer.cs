using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationOffer : ObjectsChanger
{
    [SerializeField] private Button _authDialogButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private AuthorizationService _authorizationService;
    [SerializeField] private AuthorizationOfferPanel _authorizationOfferPanel;
    [SerializeField] private PauseService _pauseService;

    public event Action AuthorizationOfferPanelClosed;

    protected void OnEnable()
    {
        _authDialogButton.onClick.AddListener(LogIn);
        _closeButton.onClick.AddListener(Hide);
    }

    protected void OnDisable()
    {
        _authDialogButton.onClick.RemoveListener(LogIn);
        _closeButton.onClick.RemoveListener(Hide);
    }

    private void LogIn()
    {
        _authorizationService.ShowAuthDialog();

        DisableAuthorizationOfferPanel();

        AuthorizationOfferPanelClosed?.Invoke();
    }

    private void Hide()
    {
        DisableAuthorizationOfferPanel();

        _pauseService.DisablePause();
    }

    private void DisableAuthorizationOfferPanel()
    {
        DisableObject(_authorizationOfferPanel.gameObject);
    }
}
