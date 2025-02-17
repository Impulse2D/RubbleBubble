using Services;
using UnityEngine;
using UnityEngine.UI;

namespace PanelGameOver
{
    public class LevelReloader : MonoBehaviour
    {
        [SerializeField] private LevelService _levelService;
        [SerializeField] private Button _buttonReloading;

        private void OnEnable()
        {
            _buttonReloading.onClick.AddListener(Reload);
        }

        private void OnDisable()
        {
            _buttonReloading.onClick.RemoveListener(Reload);
        }

        private void Reload()
        {
            _levelService.ReloadLevel();
        }
    }
}
