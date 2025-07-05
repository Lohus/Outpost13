using System.Collections;
using UnityEngine;
// Controll progressbar
public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject extractionProgress; // Prefab of progressbar
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
        _width = _panel.sizeDelta.x;
        StartCoroutine(AnimationProgress());
    }
    // Coroutine of animation
    IEnumerator AnimationProgress()
    {
        float _timer = 0;
        while (true)
        {
            _panel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _width * _timer / duration);
            _timer += Time.deltaTime;
            if (_timer >= duration) _timer = 0f;
            yield return null;
        }
    }

}
