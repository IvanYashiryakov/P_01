using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIButtonBuyMiner : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _buttonText = "Buy Miner";

    private int _price;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        _price = Scores.Instance.StartMinerPrice;
        _text.text = _buttonText + "\n" + _price;
        Scores.Instance.GoldAmountChanged += OnGoldAmountChanged;
        OnGoldAmountChanged(Scores.Instance.Gold);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        Scores.Instance.GoldAmountChanged -= OnGoldAmountChanged;
    }

    private void OnButtonClick()
    {
        if (Scores.Instance.RemoveGold(_price) == true)
        {
            _price = (int)(_price * Scores.Instance.PriceIncreaseRate);
            _text.text = _buttonText + "\n" + _price;
            Game.Instance.OnButtonCreateMiner();
            OnGoldAmountChanged(Scores.Instance.Gold);
        }
    }

    private void OnGoldAmountChanged(float value)
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
