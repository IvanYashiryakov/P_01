using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonMergeMiner : MonoBehaviour
{
    [SerializeField] private int _price = 200;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _buttonText = "Merge Miners";

    private void OnEnable()
    {
        Scores.Instance.GoldAmountChanged += OnGoldAmountChanged;
        Game.Instance.TwoOfAKindMinersAppeared += OnTwoOfAKindMinersAppeared;
        _button.onClick.AddListener(OnButtonClick);
        _text.text = _buttonText + "\n" + _price;
    }

    private void OnDisable()
    {
        Scores.Instance.GoldAmountChanged -= OnGoldAmountChanged;
        Game.Instance.TwoOfAKindMinersAppeared -= OnTwoOfAKindMinersAppeared;
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Scores.Instance.RemoveGold(_price);
        _price = (int)(_price * 1.2f);
        _text.text = _buttonText + "\n" + _price;
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

    private void OnGoldAmountChanged(int value)
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
