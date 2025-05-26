using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Item : MonoBehaviour
{
    [SerializeField] GameObject textForDescription;
    TextMeshProUGUI textDescription;
    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        textDescription = textForDescription.GetComponent<TextMeshProUGUI>();
    }

    public void OnButtonClick()
    {
        textDescription.text = "test string";
    }
}
