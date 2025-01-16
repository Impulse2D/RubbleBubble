using UnityEngine;
using UnityEngine.UI;

public class NextLevelAdapter : MonoBehaviour
{
    [SerializeField] private LevelService _levelService;
    [SerializeField] private Button _buttonNextLevel;
    [SerializeField] private Button _buttonReset;

    private void OnEnable()
    {
        _buttonNextLevel.onClick.AddListener(GoNextLevel);
        _buttonReset.onClick.AddListener(ResetNumberLevel);
    }

    private void OnDisable()
    {
        _buttonNextLevel.onClick.RemoveListener(GoNextLevel);
        _buttonReset.onClick.RemoveListener(ResetNumberLevel);
    }

    private void GoNextLevel()
    {
        _levelService.GoNextLevel();
    }

    private void ResetNumberLevel() //Временно
    {
        _levelService.ResetLevel();
    }
}
