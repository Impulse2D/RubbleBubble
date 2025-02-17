using UnityEngine;
using YG;

namespace Services
{
    public class AuthorizationService : MonoBehaviour
    {
        public void ShowAuthDialog()
        {
            YandexGame.AuthDialog();
        }
    }
}
