using Canvases;
using Gun;
using Services;
using UnityEngine;

namespace UIPanelsVisibleChanger
{
    public class ShootingChanger : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private CanvasReloadBullets _canvasReloadBullets;
        [SerializeField] private PauseService _pauseService;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private TrajectoryVisualizer _trajectoryVisualizer;

        private void OnEnable()
        {
            _pauseService.PauseEnabled += EnablePause;
            _pauseService.PauseDisabled += DisablePause;
        }

        private void OnDisable()
        {
            _pauseService.PauseEnabled -= EnablePause;
            _pauseService.PauseDisabled -= DisablePause;
        }

        private void EnablePause()
        {
            _objectsChangerService.DisableObject(_trajectoryVisualizer.gameObject);

            _objectsChangerService.DisableObject(_inputReader.gameObject);
        }

        private void DisablePause()
        {
            _objectsChangerService.EnableObject(_inputReader.gameObject);
        }
    }
}
