using System.Collections;
using Services;
using UnityEngine;
using YG;

public class SceneAfterauthorizationLoader : MonoBehaviour
{
    private const string CurrentLevel = "CurrentLevel";

    [SerializeField] private ScenesService _scenesService;

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
        float delay = 3f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        yield return timeWait;

        int cloudSaveLevel = YandexGame.savesData.numberLevel;

        if (_currentLevel > cloudSaveLevel)
        {
            YandexGame.savesData.numberLevel = _currentLevel;

            YandexGame.SaveProgress();
        }
        else if(_currentLevel <= cloudSaveLevel)
        {
            YandexGame.savesData.numberLevel = cloudSaveLevel;

            YandexGame.SaveProgress();
        }

        _scenesService.LoadGameScene();
    }
}
