
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Firewood : MonoBehaviour
{
    public Transform parentPanel;
    public GameObject buttonPrefabs;
    string nameButton;
    string extraction;
    [SerializeField] GameObject extractionUIPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            nameButton = CreateButton();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(GameObject.Find(nameButton));
            Destroy(GameObject.Find(extraction));
        }
    }
    public void OnButtonClick()
    {
        Destroy(GameObject.Find(nameButton));
        RotatePlayerTo();
        extraction = ExtractionResources();

    }
    string CreateButton()
    {
        GameObject button = Instantiate(buttonPrefabs, parentPanel);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "get a tree";
        Button buttonComponent = button.GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnButtonClick);
        return button.name;
    }

    void RotatePlayerTo() => PlayerController.instance.RotateTo(gameObject.transform);

    string ExtractionResources()
    {
        return Instantiate(extractionUIPrefab, GameObject.FindGameObjectWithTag("MainUI").transform).name;

    }

}
