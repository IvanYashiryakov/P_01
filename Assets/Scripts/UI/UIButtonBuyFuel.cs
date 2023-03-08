using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonBuyFuel : MonoBehaviour
{
    [SerializeField] private int _price = 50;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _buttonText = "Buy Fuel";

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        Scores.Instance.GoldAmountChanged += OnGoldAmountChanged;
        Scores.Instance.FuelAmountChanged += OnFuelAmountChanged;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        Scores.Instance.GoldAmountChanged -= OnGoldAmountChanged;
        Scores.Instance.FuelAmountChanged -= OnFuelAmountChanged;
    }

    private void OnButtonClick()
    {
        Scores.Instance.RemoveGold(_price);
        _price = (int)(_price * Scores.Instance.PriceIncreaseRate);
        _text.text = _buttonText + "\n" + _price;
    }

    private void OnGoldAmountChanged(int value)
    {
        if (value >= _price)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }

    private void OnFuelAmountChanged(float current, float max)
    {
        if (Scores.Instance.Gold >= _price)
        {
            if (current < max)
            {
                _button.interactable = true;
                return;
            }
        }

        _button.interactable = false;
    }
}
