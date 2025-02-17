using Services;
using TMPro;
using UnityEngine;

namespace LevelPanel
{
    public class LevelsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textLevel;
        [SerializeField] private LevelService _levelService;

        private void OnEnable()
        {
            _levelService.LeveliInstalled += Show;
        }

        private void OnDisable()
        {
            _levelService.LeveliInstalled -= Show;
        }

        private void Show(string numberLevel)
        {
            _textLevel.text = numberLevel;
        }
    }
}
