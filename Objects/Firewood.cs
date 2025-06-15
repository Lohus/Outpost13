
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Firewood : MonoBehaviour
{
    GameObject extractionButton;
    string extraction;
    [SerializeField] GameObject extractionUIPrefab;

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
            Destroy(GameObject.Find(extraction));
        }
    }
    public void OnButtonClick()
    {
        Destroy(extractionButton);
        RotatePlayerTo();
        extraction = ExtractionResources();

    }
    GameObject CreateButton() => Interface.instance.CreateButton("Extract", OnButtonClick);

    void RotatePlayerTo() => PlayerController.instance.RotateTo(gameObject.transform);

    string ExtractionResources()
    {
        return Instantiate(extractionUIPrefab, GameObject.FindGameObjectWithTag("MainUI").transform).name;

    }

}
