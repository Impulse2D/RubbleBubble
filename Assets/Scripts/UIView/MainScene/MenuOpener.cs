using UnityEngine;
using YG;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private LevelService _levelService;
    [SerializeField] private ObjectsChangerService _objectsChangerService;
    [SerializeField] private CompletedGameMenuPanel _completedGameMenuPanel;
    [SerializeField] private MainMenuPanel _mainMenuPanel;

    public void Init()
    {
        int maxNumberLevel = 100000000;

        if (_levelService.NumberLevel >= maxNumberLevel)
        {
            _objectsChangerService.EnableObject(_completedGameMenuPanel.gameObject);
        }
        else
        {
            _objectsChangerService.EnableObject(_mainMenuPanel.gameObject);
        }
    }
}
