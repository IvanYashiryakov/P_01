using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonMergeMiner : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _buttonText = "Merge Miners";

    private int _price;

    private void OnEnable()
    {
        Scores.Instance.GoldAmountChanged += OnGoldAmountChanged;
        Game.Instance.TwoOfAKindMinersAppeared += OnTwoOfAKindMinersAppeared;
        _button.onClick.AddListener(OnButtonClick);

        _price = Scores.Instance.StartMergePrice;
        _text.text = _buttonText + "\n" + _price;
        OnGoldAmountChanged(Scores.Instance.Gold);
    }

    private void OnDisable()
    {
        Scores.Instance.GoldAmountChanged -= OnGoldAmountChanged;
        Game.Instance.TwoOfAKindMinersAppeared -= OnTwoOfAKindMinersAppeared;
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (Scores.Instance.RemoveGold(_price) == true)
        {
            _price = (int)(_price * Scores.Instance.PriceIncreaseRate);
            _text.text = _buttonText + "\n" + _price;
            Game.Instance.OnButtonMergeMiners();
            OnGoldAmountChanged(Scores.Instance.Gold);
        }
    }

    private void OnTwoOfAKindMinersAppeared()
    {
        if (Scores.Instance.Gold >= _price)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }

    private void OnGoldAmountChanged(float value)
    {
        if (value >= _price && Game.Instance.IsTwoOfAKindMinersAppear() == true)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
