using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    public class LocalizationSelector : MonoBehaviour
    {
        [SerializeField] private LocalizationSelect _localizationSelect;
        [SerializeField] private Button _buttonTranslateToRussian;
        [SerializeField] private Button _buttonTranslateToEnglish;
        [SerializeField] private Button _buttonTranslateToTurkish;
        [SerializeField] private CanvasSettings _canvasSettings;

        private void OnEnable()
        {
            _buttonTranslateToRussian.onClick.AddListener(_localizationSelect.TranslateToRussian);
            _buttonTranslateToEnglish.onClick.AddListener(_localizationSelect.TranslateToEnglish);
            _buttonTranslateToTurkish.onClick.AddListener(_localizationSelect.TranslateToTurkish);
        }

        private void OnDisable()
        {
            _buttonTranslateToRussian.onClick.RemoveListener(_localizationSelect.TranslateToRussian);
            _buttonTranslateToEnglish.onClick.RemoveListener(_localizationSelect.TranslateToEnglish);
            _buttonTranslateToTurkish.onClick.RemoveListener(_localizationSelect.TranslateToTurkish);
        }
    }
}
