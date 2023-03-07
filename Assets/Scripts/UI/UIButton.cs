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
        Score.Instance.GoldAmountChanged += OnGoldAmountChanged;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Score.Instance.GoldAmountChanged -= OnGoldAmountChanged;
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Score.Instance.RemoveGold(_price);
        _price = (int)(_price * 1.2f);
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
