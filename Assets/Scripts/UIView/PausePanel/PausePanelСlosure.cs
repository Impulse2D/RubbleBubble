using UnityEngine;
using UnityEngine.UI;

public class PausePanel—losure : ObjectsChanger
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private Button _buttonClosePausePanel;

    private void OnEnable()
    {
        _buttonClosePausePanel.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        _buttonClosePausePanel.onClick.RemoveListener(Hide);
    }

    private void Hide()
    {
        DisableObject(_pausePanel.gameObject);

        _pauseService.DisablePause();
    }
}
