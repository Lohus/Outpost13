using System.Collections;
using UnityEngine;
// Controll progressbar
public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject extractionProgress; // Prefab of progressbar
    [SerializeField] float offsetFromBorder = 5;
    RectTransform _panel;
    float _width;
    float duration = 0.5f;
    // Set duration of animation progressbar
    public void Init(float durationAnimation)
    {
        duration = durationAnimation;
    }
    // Start progressbar
    void Start()
    {
        _panel = extractionProgress.GetComponent<RectTransform>();
        _width = gameObject.GetComponent<RectTransform>().sizeDelta.x / 2;
        StartCoroutine(AnimationProgress());
    }
    // Coroutine of animation
    IEnumerator AnimationProgress()
    {
        float _timer = 0;
        Vector2 offsetVector = new Vector2(offsetFromBorder, offsetFromBorder);
        while (true)
        {
            offsetVector.x = (_width - offsetFromBorder) * (duration - _timer) / duration;
            _panel.offsetMin = offsetVector;
            _panel.offsetMax = -offsetVector;
            _timer += Time.deltaTime;
            if (_timer >= duration) _timer = 0f;
            yield return null;
        }
    }

}
