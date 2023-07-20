using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private RectTransform _rectTransform;

    private const float StartYPosition = 1.29f;
    private const float EndYPosition = 2.1f;
    private const float TimeStep = 0.03f;
    private WaitForSeconds _delay = new WaitForSeconds(TimeStep);

    public void Init(float value, Sprite sprite, Vector3 position)
    {
        _image.sprite = sprite;
        _text.text = "+" + value.ToString("F1");
        _rectTransform.position = new Vector3(position.x, StartYPosition, position.z);
        gameObject.SetActive(true);
        StartCoroutine(Animate());
    }

    [ContextMenu("Animate")]
    private void StartAnimate()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        float distance = EndYPosition - StartYPosition;
        float positionStep = distance / (1f / TimeStep) * 2;
        float alphaStep = TimeStep * 6;
        _canvasGroup.alpha = 1;

        while (_canvasGroup.alpha > 0)
        {
            _rectTransform.position = new Vector3(_rectTransform.position.x, _rectTransform.position.y + positionStep, _rectTransform.position.z);
            
            if ((EndYPosition - _rectTransform.position.y) < distance / 4)
            {
                _canvasGroup.alpha -= alphaStep;
            }

            yield return _delay;
        }

        gameObject.SetActive(false);
    }
}
