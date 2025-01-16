using UnityEngine;

public class GameOverPanelOpener : ObjectsChanger
{
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private LifeService _lifeService;

    private void OnEnable()
    {
        _lifeService.LivesExhausted += Show;
    }

    private void OnDisable()
    {
        _lifeService.LivesExhausted -= Show;
    }

    private void Show()
    {
        EnabledObject(_gameOverPanel.gameObject);

        _pauseService.EnablePause();
    }
}
