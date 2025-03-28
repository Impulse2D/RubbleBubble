using LoadingPanelView;
using Services;
using UnityEngine;
using UnityEngine.UI;
using YandexAds;
using YG;

namespace LevelPanel
{
    public class WinPanelView : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private LoadingPanel _loadingPanel;
        [SerializeField] private LevelService _levelService;
        [SerializeField] private Button _buttonNextLevel;
        [SerializeField] private AdFullscreenOpener _adFullscreenOpener;
        [SerializeField] private WinPanel _winPanel;

        private int _maxValueTimerShowAd;

        private void OnEnable()
        {
            _buttonNextLevel.onClick.AddListener(GoNextLevel);

            YandexGame.CloseFullAdEvent += GoNextGameLevel;
        }

        private void OnDisable()
        {
            _buttonNextLevel.onClick.RemoveListener(GoNextLevel);

            YandexGame.CloseFullAdEvent -= GoNextGameLevel;
        }

        private void GoNextLevel()
        {
            _maxValueTimerShowAd = 60;

            if (YandexGame.savesData.numberLevel == 99999999)
            {
                _levelService.IncreaseLevel();
                _levelService.SaveData();
                _levelService.LoadMainScene();
            }
            else if (YandexGame.timerShowAd > _maxValueTimerShowAd)
            {
                _objectsChangerService.DisableObject(_winPanel.gameObject);
                _objectsChangerService.EnableObject(_loadingPanel.gameObject);

                _adFullscreenOpener.OnOpenFullAdEvent();
            }
            else
            {
                GoNextGameLevel();
            }
        }

        private void GoNextGameLevel()
        {
            _levelService.GoNextLevel();
        }
    }
}