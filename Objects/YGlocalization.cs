// YG set localization
using UnityEngine.Localization.Settings;
using UnityEngine;
using YG;
using System.Collections;


public class YGlocalization : MonoBehaviour
{
    [SerializeField] GameObject image;
    IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;
        if (YG2.isSDKEnabled)
        {
            switch (YG2.envir.language) // Get localization
            {
                case "ru":
                    LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
                    break;
                case "en":
                    LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                    break;
                default:
                    LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                    break;

            }
            Invoke("OnLocaleChanged", 1f);
        }
    }
    void OnLocaleChanged()
    {
        if (image != null)
            image.SetActive(false);
        YG2.GameReadyAPI();
    }

}