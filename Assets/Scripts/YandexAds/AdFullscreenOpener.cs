using UnityEngine;
using YG;

public class AdFullscreenOpener : MonoBehaviour
{
    [SerializeField] private PauseService _pauseService;

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += OnOpenFullAdEvent;
        YandexGame.CloseFullAdEvent += OnCloseFullAdEvent;
    }

    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= OnOpenFullAdEvent;
        YandexGame.CloseFullAdEvent -= OnCloseFullAdEvent;
    }

    public void Init()
    {
        TryShowInterstitial();
    }

    private void TryShowInterstitial()
    {
        int maxValueTimerShowAd = 60;

        if (YandexGame.timerShowAd > maxValueTimerShowAd)
        {
            YandexGame.FullscreenShow();
        }
    }

    private void OnOpenFullAdEvent()
    {
        _pauseService.EnablePause();
    }

    private void OnCloseFullAdEvent()
    {
        _pauseService.DisablePause();
    }
}
