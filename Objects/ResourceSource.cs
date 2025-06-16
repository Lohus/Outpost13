
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class ResourceSource : MonoBehaviour
{
    [SerializeField] float interval = 2;
    [SerializeField] int quantityResources;
    [SerializeField] ResourceItem typeResource;
    GameObject extractionButton;
    GameObject extractionUI;
    Coroutine extractionRoutine;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            extractionButton = CreateButton();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(extractionButton);
        }
    }
    public void OnButtonClick()
    {
        Destroy(extractionButton);
        RotatePlayerTo();
        StartExtraction();

    }
    GameObject CreateButton() => Interface.instance.CreateButton("Extract", OnButtonClick);
    void RotatePlayerTo() => PlayerController.instance.RotateTo(gameObject.transform);
    void AddResources(ResourceItem resource, int count) => PlayerInventory.instance.AddResourcesToInvetory(resource, count);


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

    void StartExtraction()
    {
        extractionRoutine = StartCoroutine(ExtractionResource());
        extractionUI = Interface.instance.CreateProgressBar(interval);
        PlayerController.instance.playerIsMove.AddListener(() => StopExtraction(extractionRoutine));
    }
    void StopExtraction(Coroutine cor)
    {
        StopCoroutine(cor);
        Destroy(extractionUI);
        PlayerController.instance.playerIsMove.RemoveListener(() => StopExtraction(extractionRoutine));
    }
}
