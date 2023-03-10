using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private int _price = 100;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _buttonText = "Create Miner";

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        Scores.Instance.GoldAmountChanged += OnGoldAmountChanged;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        Scores.Instance.GoldAmountChanged -= OnGoldAmountChanged;
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
}
