using System;
using Services;
using UnityEngine;

namespace PanelGameOver
{
    public class GameOverPanelOpener : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private PauseService _pauseService;
        [SerializeField] private GameOverPanel _gameOverPanel;
        [SerializeField] private LifeService _lifeService;

        public event Action PanelOpened;

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
            _objectsChangerService.EnableObject(_gameOverPanel.gameObject);

            PanelOpened?.Invoke();

            _pauseService.EnablePause();
        }
    }
}
