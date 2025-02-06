using UnityEngine;

public class PausePanelOpener : MonoBehaviour
{
    [SerializeField] private ObjectsChangerService _objectsChangerService;
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private PausePanel _pausePanel;

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
        _objectsChangerService.EnableObject(_pausePanel.gameObject);

        _pauseService.EnablePause();
    }
}
