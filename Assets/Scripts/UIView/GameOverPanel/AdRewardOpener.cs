using UnityEngine;
using UnityEngine.UI;
using YG;

public class AdRewardOpener : ObjectsChanger
{
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private Button _buttonAdReward;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private LifeService _lifeService;

    private int _idAdReward;

    private void OnEnable()
    {
        _buttonAdReward.onClick.AddListener(ShowRewardAd);

        YandexGame.OpenVideoEvent += EnablePause;

        YandexGame.RewardVideoEvent += Reward;
    }

    private void OnDisable()
    {
        _buttonAdReward.onClick.RemoveListener(ShowRewardAd);

        YandexGame.OpenVideoEvent -= EnablePause;

        YandexGame.RewardVideoEvent -= Reward;
    }

    private void ShowRewardAd()
    {
        _idAdReward = 1;

        OpenAd(_idAdReward);
    }

    private void Reward(int id)
    {
        if (id == _idAdReward)
        {
            EnablePause();

            DisableObject(_gameOverPanel.gameObject);

            EnabledObject(_pausePanel.gameObject);
        }
    }

    private void EnablePause()
    {
        _pauseService.EnablePause();
    }

    private void OpenAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
