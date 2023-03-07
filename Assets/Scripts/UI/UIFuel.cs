using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFuel : MonoBehaviour
{
    [SerializeField] private Slider _slider;

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
    }
}
