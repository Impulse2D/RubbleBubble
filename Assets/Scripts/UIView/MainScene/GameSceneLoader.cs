using Services;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class GameSceneLoader : ObjectsChangerService
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private ScenesService _scenesService;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(GoSceneGame);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(GoSceneGame);
        }

        private void GoSceneGame()
        {
            _scenesService.LoadGameScene();
        }
    }
}
