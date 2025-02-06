using UnityEngine;
using YG;

public class LocalizationSelect : MonoBehaviour
{
    private const string LanguageCode = "LanguageCode";

    private const string RussianCode = "ru";
    private const string EnglishCode = "en";
    private const string TurkishCode = "tr";

    public string RussianCodeLanguage => RussianCode;
    public string EnglishCodeLanguage => EnglishCode;
    public string TurkishCodeLanguage => TurkishCode;

    public void TranslateToRussian()
    {
        SetInstallableLanguage(RussianCode);
    }

    public void TranslateToEnglish()
    {
        SetInstallableLanguage(EnglishCode);
    }
    public void TranslateToTurkish()
    {
        SetInstallableLanguage(TurkishCode);
    }

    public void SetInstallableLanguage(string languageCode)
    {
        YandexGame.SwitchLanguage(languageCode);

        SaveLanguage(languageCode);
    }

    public string GetLanguage()
    {
        return PlayerPrefs.GetString(LanguageCode);
    }

    private void SaveLanguage(string language)
    {
        PlayerPrefs.SetString(LanguageCode, language);
        PlayerPrefs.Save();
    }
}
