using UnityEngine;
using YG;

public class LanguageDefinition : MonoBehaviour
{
    [SerializeField] private LocalizationSelect _localizationSelect;

    private string _currentLanguage;

    public void Init()
    {
        string emptyValue = "";

        _currentLanguage =  _localizationSelect.GetLanguage();

        if (_currentLanguage == emptyValue)
        {
            if (YandexGame.EnvironmentData.language == _localizationSelect.RussianCodeLanguage)
            {
                _localizationSelect.TranslateToRussian();
            }
            else if (YandexGame.EnvironmentData.language == _localizationSelect.EnglishCodeLanguage)
            {
                _localizationSelect.TranslateToEnglish();
            }
            else if (YandexGame.EnvironmentData.language == _localizationSelect.TurkishCodeLanguage)
            {
                _localizationSelect.TranslateToTurkish();
            }
            else
            {
                _localizationSelect.TranslateToEnglish();
            }
        }
        else
        {
            _localizationSelect.SetInstallableLanguage(_currentLanguage);
        }
    }
}
