using UnityEngine;

public class WinPanelOpener : ObjectsChanger
{
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private GamePointsIndicator _gamePointsIndicator;
    [SerializeField] private PauseService _pauseService;

    private void OnEnable()
    {
        _gamePointsIndicator.Filled += Show;
    }

    private void OnDisable()
    {
        _gamePointsIndicator.Filled -= Show;
    }

    private void Show()
    {
        EnabledObject(_winPanel.gameObject);

        _pauseService.EnablePause();
    }
}
