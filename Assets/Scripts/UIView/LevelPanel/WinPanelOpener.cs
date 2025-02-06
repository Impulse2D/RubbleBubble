using System;
using UnityEngine;
using YG;

public class WinPanelOpener : MonoBehaviour
{
    [SerializeField] private ObjectsChangerService _objectsChangerService;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private GamePointsIndicator _gamePointsIndicator;
    [SerializeField] private PauseService _pauseService;

    public event Action PanelOpened;

    private bool _isPanelOpened;

    private void OnEnable()
    {
        _isPanelOpened = false;

        _gamePointsIndicator.Filled += Show;
    }

    private void OnDisable()
    {
        _gamePointsIndicator.Filled -= Show;
    }

    private void Show()
    {
        if (_isPanelOpened == false)
        {
            _isPanelOpened = true;

            _objectsChangerService.EnableObject(_winPanel.gameObject);

            PanelOpened?.Invoke();

            _pauseService.EnablePause();
        }
    }
}
