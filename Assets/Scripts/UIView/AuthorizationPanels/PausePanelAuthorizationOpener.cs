using Services;
using UnityEngine;

namespace AuthorizationPanels
{
    public class PausePanelAuthorizationOpener : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private PausePanelAuthorization _pausePanelAuthorization;
        [SerializeField] private AuthorizationView _authorizationOffer;

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
            _objectsChangerService.EnableObject(_pausePanelAuthorization.gameObject);
        }
    }
}
