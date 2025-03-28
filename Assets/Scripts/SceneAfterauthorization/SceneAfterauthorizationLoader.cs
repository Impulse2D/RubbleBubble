using System.Collections;
using Services;
using UnityEngine;
using YG;

namespace SceneAfterauthorization
{
    public class SceneAfterauthorizationLoader : MonoBehaviour
    {
        private const string CurrentLevel = "CurrentLevel";

        [SerializeField] private ScenesService _scenesService;
        [SerializeField] private float _delayCoroutine = 3f;

        private int _currentLevel;

        private void Start()
        {
            _currentLevel = PlayerPrefs.GetInt(CurrentLevel);

            YandexGame.LoadProgress();
        }

        private void OnEnable()
        {
            YandexGame.GetDataEvent += StartSavingLevel;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= StartSavingLevel;
        }

        private void StartSavingLevel()
        {
            StartCoroutine(CountPauseBeforeLoadingGameScene());
        }

        private IEnumerator CountPauseBeforeLoadingGameScene()
        {
            WaitForSeconds timeWait = new WaitForSeconds(_delayCoroutine);

            yield return timeWait;

            int cloudSaveLevel = YandexGame.savesData.numberLevel;

            if (_currentLevel > cloudSaveLevel)
            {
                YandexGame.savesData.numberLevel = _currentLevel;
                YandexGame.SaveProgress();
            }
            else if (_currentLevel <= cloudSaveLevel)
            {
                YandexGame.savesData.numberLevel = cloudSaveLevel;
                YandexGame.SaveProgress();
            }

            _scenesService.LoadGameScene();
        }
    }
}
