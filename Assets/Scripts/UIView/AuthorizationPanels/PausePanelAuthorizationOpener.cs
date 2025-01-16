using UnityEngine;

public class PausePanelAuthorizationOpener : ObjectsChanger
{
    [SerializeField] private PausePanelAuthorization _pausePanelAuthorization;
    [SerializeField] private AuthorizationOffer _authorizationOffer;

    private void OnEnable()
    {
        _authorizationOffer.AuthorizationOfferPanelClosed += Show;
    }

    private void OnDisable()
    {
        _authorizationOffer.AuthorizationOfferPanelClosed -= Show;
    }

    private void Show()
    {
        EnabledObject(_pausePanelAuthorization.gameObject);
    }
}
