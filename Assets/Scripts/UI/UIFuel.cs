using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFuel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _iconFiller;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        Scores.Instance.FuelAmountChanged += OnFuelAmountChanged;
    }

    private void OnDisable()
    {
        Scores.Instance.FuelAmountChanged -= OnFuelAmountChanged;
    }

    private void OnFuelAmountChanged(float currentFuel, float maxFuel)
    {
        _slider.value = currentFuel / maxFuel;
        _iconFiller.fillAmount = currentFuel / maxFuel;
        //_text.text = (int)(_slider.value * 100) + "%";
        _text.text = ((int)currentFuel).ToString();
    }
}
