// Settings window
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;


public class SettingsUI : MonoBehaviour
{
    [SerializeField] TMP_Dropdown choseLanguage;
    [SerializeField] Button apply;
    [SerializeField] Toggle keyboardToggle, joystickToggle; // Control
    [SerializeField] SettingsGame settings;
    [SerializeField] Slider volumeSlider;

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
        keyboardToggle.isOn = settings.keyboardControl;
        joystickToggle.isOn = !settings.keyboardControl;
        volumeSlider.value = settings.volume;
    }
    void ApplySettings()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[choseLanguage.value];
        settings.keyboardControl = keyboardToggle.isOn;
        settings.volume = volumeSlider.value;
        if (Interface.instance != null) Interface.instance.SetJoystick(joystickToggle.isOn);
        if (PlayerController.instance != null) AudioListener.volume = volumeSlider.value;
    }
}