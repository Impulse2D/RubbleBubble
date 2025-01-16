using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelService : MonoBehaviour
{
    private const string CurrentLevel = "CurrentLevel";

    private int _numberLevel;

    public event Action<string> LeveliInstalled;

    public int NumberLevel => _numberLevel;

    public void Init()
    {
        LoadData();
    }

    public void LoadData()
    {
        _numberLevel = YandexGame.savesData.numberLevel;

        PlayerPrefs.SetInt(CurrentLevel, _numberLevel);

        LeveliInstalled?.Invoke(_numberLevel.ToString());
    }

    public void SaveData()
    {
        YandexGame.savesData.numberLevel = _numberLevel;

        YandexGame.SaveProgress();
    }

    public void IncreaseLevel()
    {
        _numberLevel++;
    }

    public void GoNextLevel()
    {
        IncreaseLevel();

        SaveData();

        ReloadLevel();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetRecord() // временно
    {
        _numberLevel = 1;

        YandexGame.savesData.currentRecord = YandexGame.savesData.numberLevel;

        YandexGame.SaveProgress();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetLevel() // временно
    {
        _numberLevel = 1;

        YandexGame.savesData.numberLevel = _numberLevel;

        YandexGame.SaveProgress();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
