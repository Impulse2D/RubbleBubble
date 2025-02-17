using UnityEngine;
using YG;

namespace YandexAds
{
    public class AdFullscreenOpener : MonoBehaviour
    {
        public void OnOpenFullAdEvent()
        {
            YandexGame.FullscreenShow();
        }
    }
}
