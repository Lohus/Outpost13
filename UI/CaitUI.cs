using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization;

public class CaitUI : MonoBehaviour
{
    [SerializeField] Button close;
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI message;
    LocalizedString localizedString;
    float delay = 0.02f;
    void Awake()
    {
        close.interactable = false;
        close.onClick.AddListener(() => Destroy(gameObject));
    }
    public void Init(Sprite emotion, LocalizedString localizedText)
    {
        icon.sprite = emotion;
        localizedString = localizedText;
        localizedString.StringChanged += LocalizeMessage;
    }
    IEnumerator ShowText(string localizedText)
    {
        message.text = ""; // очистка
        for (int i = 0; i < localizedText.Length; i++)
        {
            message.text += localizedText[i];
            yield return new WaitForSeconds(delay);
        }
        close.interactable = true;
        localizedString.StringChanged -= LocalizeMessage;
    }
    void LocalizeMessage(string localizedText)
    {
        StartCoroutine(ShowText(localizedText));
    }
}