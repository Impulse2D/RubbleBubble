using UnityEngine;
using YG;

public class AdFullscreenOpener : MonoBehaviour
{
    public void OnOpenFullAdEvent()
    {
        YandexGame.FullscreenShow();
    }
}
