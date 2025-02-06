using UnityEngine;
using UnityEngine.UI;

public class LevelResetter : MonoBehaviour
{
    [SerializeField] private Button _numberLevelResetterButton;
    [SerializeField] private LevelService _levelService;

    private void OnEnable()
    {
        _numberLevelResetterButton.onClick.AddListener(ResetNubmerLevel);
    }

    private void OnDisable()
    {
        _numberLevelResetterButton.onClick.RemoveListener(ResetNubmerLevel);
    }

    private void ResetNubmerLevel()
    {
        _levelService.ResetLevel();
    }
}
