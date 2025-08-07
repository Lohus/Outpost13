using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using Unity.VisualScripting;
using TMPro;


public class SettingsUI : MonoBehaviour
{
    [SerializeField] TMP_Dropdown choseLanguage;
    [SerializeField] Button apply;

    void Start()
    {
        apply.onClick.AddListener(ApplySettings);
        choseLanguage.options.Clear();
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            choseLanguage.options.Add(new TMP_Dropdown.OptionData(locale.Identifier.CultureInfo.NativeName));
        }

        var currentLocale = LocalizationSettings.SelectedLocale;
        int index = LocalizationSettings.AvailableLocales.Locales.IndexOf(currentLocale);
        choseLanguage.value = index;
        choseLanguage.RefreshShownValue();
    }
    void ApplySettings()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[choseLanguage.value];
    }
}