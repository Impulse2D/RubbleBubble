using UnityEngine;
using YG;

namespace Localization
{
    public class LanguageDefinition : MonoBehaviour
    {
        [SerializeField] private LocalizationSelect _localizationSelect;

        private string _emptyValueLanguage;
        private string _currentLanguage;

        public void Init()
        {
            _emptyValueLanguage = string.Empty;

            _currentLanguage = _localizationSelect.GetLanguage();

            if (IsLanguageRussian() == true && IsCurrentLanguageEmpty() == true)
            {
                _localizationSelect.TranslateToRussian();
            }

            if (IsLanguageEnglish() == true && IsCurrentLanguageEmpty() == true)
            {
                _localizationSelect.TranslateToEnglish();
            }

            if (IsLanguageTurkish() == true && IsCurrentLanguageEmpty() == true)
            {
                _localizationSelect.TranslateToTurkish();
            }

            if (IsLanguageRussian() == false && IsLanguageEnglish() == false &&
                IsLanguageTurkish() == false && IsCurrentLanguageEmpty() == true)
            {
                _localizationSelect.TranslateToEnglish();
            }

            if (IsCurrentLanguageEmpty() == false)
            {
                _localizationSelect.SetInstallableLanguage(_currentLanguage);
            }
        }

        private bool IsLanguageRussian()
        {
            return YandexGame.EnvironmentData.language == _localizationSelect.RussianCodeLanguage;
        }

        private bool IsLanguageEnglish()
        {
            return YandexGame.EnvironmentData.language == _localizationSelect.EnglishCodeLanguage;
        }

        private bool IsLanguageTurkish()
        {
            return YandexGame.EnvironmentData.language == _localizationSelect.TurkishCodeLanguage;
        }

        private bool IsCurrentLanguageEmpty()
        {
            return _currentLanguage == _emptyValueLanguage;
        }
    }
}
