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
            switch (YG2.envir.language)
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
            Invoke("OnLocaleChanged", 0.5f);
        }
    }
    void OnLocaleChanged()
            {
                if (image != null)
                    image.SetActive(false);
            }
}