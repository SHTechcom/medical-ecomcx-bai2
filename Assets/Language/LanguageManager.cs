using System.Collections;
using Frank;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManager : Singleton<LanguageManager>
{
    private UISetting UISetting => GameViewManager.Instance.GetView<UISetting>();

    private IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;
        SetLocale(1);
        UISetting.SetIconLang(1);
        UISetting.OnClickedLang(ChangeLanguage);
    }

    private void ChangeLanguage()
    {
        // 🔹 Nếu đang là tiếng Anh -> chuyển sang tiếng Việt
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
        {
            SetLocale(1);
            UISetting.SetIconLang(1);
        }
        // 🔹 Ngược lại (đang là tiếng Việt) -> chuyển sang tiếng Anh
        else
        {
            SetLocale(0);
            UISetting.SetIconLang(0);
        }
        Debug.Log("Current Locale: " + LocalizationSettings.SelectedLocale.Identifier.Code);
    }

    public void SetLocale(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
