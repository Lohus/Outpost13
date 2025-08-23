using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform bg;      // фон стика
    [SerializeField] private RectTransform handle;  // сам стик
    private Vector2 inputVector;   // куда двигаем палец

    void Start()
    {
        bg = GetComponent<RectTransform>();
        handle = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            bg, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bg.sizeDelta.x);
            pos.y = (pos.y / bg.sizeDelta.y);

            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // двигаем ручку стика
            handle.anchoredPosition = new Vector2(
                inputVector.x * (bg.sizeDelta.x / 3),
                inputVector.y * (bg.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }

    public float Horizontal() => inputVector.x;
    public float Vertical() => inputVector.y;
}
