using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionResources : MonoBehaviour
{
    RectTransform extractionProgress;
    PlayerController playerController;
    public ResourceItem wood;
    float width;
    void Start()
    {
        extractionProgress = GameObject.Find("Scale").GetComponentInChildren<RectTransform>();
        width = extractionProgress.sizeDelta.x;
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        ChangeWidthScale();
        CheckPlayerPosition();
    }

    void ChangeWidthScale()
    {
        extractionProgress.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, extractionProgress.sizeDelta.x - 80 * Time.deltaTime);
        if (extractionProgress.sizeDelta.x < 1)
        {
            AddResources();
            extractionProgress.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }
    }
    void CheckPlayerPosition()
    {
        if (playerController.playerIsMove == true)
            Destroy(gameObject);
    }

    void AddResources()
    {
        if (playerController.inventory.ContainsKey(wood))
        {
            playerController.inventory[wood] += 10;
        }
        else
        {
            playerController.inventory.Add(wood, 10);
        }
    }
    // Написать дестурктор для получения ресурсов от добычи
}
