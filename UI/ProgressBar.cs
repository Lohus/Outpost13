using System.Collections;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject extractionProgress;
    RectTransform _panel;
    float _width;
    float duration = 0.5f;

    public void Init(float durationAnimation)
    {
        duration = durationAnimation;
    }
    void Start()
    {
        _panel = extractionProgress.GetComponent<RectTransform>();
        _width = _panel.sizeDelta.x;
        StartCoroutine(AnimationProgress());
    }
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
