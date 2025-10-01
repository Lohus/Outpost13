// Joystick
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform background; 
    [SerializeField] private RectTransform stick;
    private Vector2 inputVector; 

    void Start()
    {
        background = GetComponent<RectTransform>();
        stick = transform.GetChild(0).GetComponent<RectTransform>();
    }
    // Drag stick
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / background.sizeDelta.x);
            pos.y = (pos.y / background.sizeDelta.y);

            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            stick.anchoredPosition = new Vector2(
                inputVector.x * (background.sizeDelta.x / 3),
                inputVector.y * (background.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        stick.anchoredPosition = Vector2.zero;
    }

    public float Horizontal() => inputVector.x;
    public float Vertical() => inputVector.y;
}
