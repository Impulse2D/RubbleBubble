using UnityEngine;

public class PausePanelOpener : ObjectsChanger
{
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private LevelService _levelService;

    private void OnEnable()
    {
        _pauseService.FocusNotDetected += Show;
    }

    private void OnDisable()
    {
        _pauseService.FocusNotDetected -= Show;
    }

    private void Show()
    {
        EnabledObject(_pausePanel.gameObject);

        _pauseService.EnablePause();
    }
}
