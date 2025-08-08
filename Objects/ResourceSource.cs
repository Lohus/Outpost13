
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using JetBrains.Annotations;

// Source of some resource
public class ResourceSource : MonoBehaviour
{
    [SerializeField] float interval = 2; // Time extraction
    [SerializeField] int quantityResources; // Amount resource than can be extract from source
    [SerializeField] ResourceItem typeResource; // Rescource that extact from source
    LocalizedString extractLocal = new LocalizedString { TableReference = "Text_UI", TableEntryReference = "ExtractButton_UI" };
    GameObject extractionButton; // Button that start extraction
    GameObject extractionUI; // Progressbar
    Coroutine extractionRoutine; // Corutine extraction
    // Show button extraction
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            extractionButton = CreateButton();
        }
    }
    // Destroy button
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(extractionButton);
        }
    }
    // Start extraction and show progressbar
    public void OnButtonClick()
    {
        Destroy(extractionButton);
        RotatePlayerTo();
        StartExtraction();

    }
    // Create button in canvas on scene
    GameObject CreateButton()
    {
        string localizedTextButton = null;
        extractLocal.StringChanged += (localizedText) =>
        {
            localizedTextButton = localizedText;
        };
        return Interface.instance.CreateButton(localizedTextButton, OnButtonClick);
    }
    // Rotate player to source
    void RotatePlayerTo() => PlayerController.instance.RotateTo(gameObject.transform);
    // Add amount resource to player inventory
    void AddResources(ResourceItem resource, int count) => PlayerInventory.instance.AddResourcesToInvetory(resource, count);

    // Coroutine of extraction resource
    IEnumerator ExtractionResource()
    {
        float timer = 0;
        while (true)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                AddResources(typeResource, quantityResources);
                timer = 0f;
            }
            yield return null;
        }
    }
    // Start coroutine, create progressbas in canvas and rotate player
    void StartExtraction()
    {
        extractionRoutine = StartCoroutine(ExtractionResource());
        extractionUI = Interface.instance.CreateProgressBar(interval);
        PlayerController.instance.playerIsMove.AddListener(() => StopExtraction(extractionRoutine));
    }
    // Stop coroutine, destroy progressbar
    void StopExtraction(Coroutine cor)
    {
        StopCoroutine(cor);
        Destroy(extractionUI);
        PlayerController.instance.playerIsMove.RemoveListener(() => StopExtraction(extractionRoutine));
    }
}
